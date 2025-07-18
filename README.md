# Simple Save System

A Unity Component to manage saving and loading state. Files are encrypted using an encryption key for better security. It provides a SaveManager class that saves encrypted save files into your game's data folder. It also provides some useful serializable classes that are transformed from the non-serializable Unity clases, like for example Vector2, Vector3, Quaternion... 

This package contains the necessary elements to serialize and deserialize data in an encrypted format, and adds some helpers. The state management (and restoring that state) is not covered by this library because it may be completely different from game to game.

## Contents
- **SaveManager Monobehaviour**: This behaviour is attached to the SaveManager prefab, and should be unique (since it's accessed as a singleton). It allows to define an encryption key for your save files (should be unique for your project) and Saving/Loading state.
- **SerializableTypes classes**: This is a set of Serializable classes that mirror some of Unity's classes such as Vector2, Vector3, Quaternion, Color and Rectangle. They can be easily converted back and forth between types.
- **SaveSlot enum**: This is a set of predefined names for your savefiles (Like QuickSave, Autosave, Slot1, Slot2...).
- **SaveManager prefab**: This prefab need to be placed on the scene, and an *encryption key* needs to be set in order to make the save files secure.

## How to use
1. Place the SaveManager prefab inside your Unity scene
2. Create a data model for your save files. The data model must be **fully serializable**. To aid in this, some Types are provided to convert Unity's non serializable types into serializable ones.
3. You can now
    1. Fill the data class with the game state you wish to save and call the *SaveManager.instance.Save(SaveSlot slot, T data)* method to save the file.
    2. Load the state by using the *SaveManager.instance.Load(SaveSlot slot)* method.
  
## Example Usage

**GameData.cs**
```cs
[System.Serializable]
public class GameData {
    public SVector3 playerPosition;
    public int playerHealth;        
}
```
**GameManager.cs**
```cs
public class GameManager : MonoBehaviour {
    public Player player;

    [...]
    public void SaveState() {
        var gameData = new GameData {
            playerPosition = new SVector3(player.transform.position),
            playerHealth = player.health
        }
        SaveManager.instance.Save(SaveSlot.AutoSave, gameData);
    }

    public void LoadState() {
        var gameData = SaveManager.instance.LoadState<GameData>(SaveSlot.AutoSave);
        player.transform.position = gameData.playerPosition.ToVector3();
        player.health = gamedata.playerHealth;
    }
    [...]
}
```


Check the documentation inside the corresponding classes to learn about the different parameters you can send to the methods described above.
