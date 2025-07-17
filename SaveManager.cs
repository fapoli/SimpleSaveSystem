using System.IO;
using UnityEngine;

namespace Modules.SimpleSaveSystem {
    public class SaveManager : MonoBehaviour {
        private const string SavePrefix = "SaveFile_";
        
        public static SaveManager instance { get; private set; }
        
        public string encryptionKey = "encryption_key";
        
        private void Awake() {
            instance = this;
        }

        /// <summary>
        /// Saves the provided data to a file with the specified name.
        /// The data is serialized to JSON and encrypted before saving.
        /// </summary>
        /// <typeparam name="T">The type of the data to save.</typeparam>
        /// <param name="fileName">The name of the file to save the data to.</param>
        /// <param name="saveData">The data to save.</param>
        public void Save<T>(string fileName, T saveData) {
            var jsonData = JsonUtility.ToJson(saveData);
            var path = Application.persistentDataPath + "/" + fileName + ".sav";
            File.WriteAllText(path, EncryptDecrypt(jsonData));
            Debug.Log($"Save file {fileName} saved at {path}");
        }
        
        /// <summary>
        /// Saves the provided data to a file with a name based on the specified save slot.
        /// The data is serialized to JSON and encrypted before saving.
        /// </summary>
        /// <typeparam name="T">The type of the data to save.</typeparam>
        /// <param name="slot">The save slot to use for the file name.</param>
        /// <param name="saveData">The data to save.</param>
        public void Save<T>(SaveSlot slot, T saveData) {
            Save(SavePrefix + slot, saveData);
        }
        
        /// <summary>
        /// Loads data of the specified type from a file with the given name.
        /// The data is read from the file, decrypted, and deserialized from JSON.
        /// </summary>
        /// <typeparam name="T">The type of the data to load.</typeparam>
        /// <param name="fileName">The name of the file to load the data from.</param>
        /// <returns>The loaded data of type T, or default if the file does not exist.</returns>
        public T Load<T>(string fileName) {
            var path = Application.persistentDataPath + "/" + fileName + ".sav";
            if (!File.Exists(path)) {
                Debug.LogWarning($"Save file {fileName} does not exist at {path}");
                return default;
            }
            
            var jsonData = File.ReadAllText(path);
            var saveData = JsonUtility.FromJson<T>(EncryptDecrypt(jsonData));
            Debug.Log($"Save file {fileName} loaded from {path}");
            return saveData;
        }
        
        /// <summary>
        /// Loads data of the specified type from a file based on the provided save slot.
        /// The data is read from the file, decrypted, and deserialized from JSON.
        /// </summary>
        /// <typeparam name="T">The type of the data to load.</typeparam>
        /// <param name="slot">The save slot to use for the file name.</param>
        /// <returns>The loaded data of type T, or default if the file does not exist.</returns>
        public T Load<T>(SaveSlot slot) {
            return Load<T>(SavePrefix + slot);
        }

        private string EncryptDecrypt(string text) {
            var key = encryptionKey.ToCharArray();
            var input = text.ToCharArray();
            for (var i = 0; i < input.Length; i++) {
                input[i] ^= key[i % key.Length];
            }
            return new string(input);
        }
    }

    public enum SaveSlot {
        AutoSave,
        QuickSave,
        Slot1,
        Slot2,
        Slot3
    }
}