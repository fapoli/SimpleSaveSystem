using System;
using UnityEngine;

namespace MoodyLib.SimpleSaveSystem {
    [Serializable]
    public class SVector2 {
        public float x;
        public float y;

        public SVector2(float x, float y) {
            this.x = x;
            this.y = y;
        }

        public SVector2(Vector2 vector) {
            this.x = vector.x;
            this.y = vector.y;
        }
        
        public Vector2 ToVector2() {
            return new Vector2(x, y);
        }
    }
    
    [Serializable]
    public class SVector3 : SVector2 {
        public float z;

        public SVector3(float x, float y, float z) : base(x, y) {
            this.z = z;
        }
        
        public SVector3(float x, float y) : base(x, y) {
            this.z = 0f;
        }
        
        public SVector3() : base(0f, 0f) {
            this.z = 0f;
        }
        
        public SVector3(Vector3 vector) : base(vector.x, vector.y) {
            this.z = vector.z;
        }
        
        public Vector3 ToVector3() {
            return new Vector3(x, y, z);
        }
 
    }
    
    [Serializable]
    public class SQuaternion {
        public float x;
        public float y;
        public float z;
        public float w;
        
        public SQuaternion(float x, float y, float z, float w) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        
        public SQuaternion(Quaternion quaternion) {
            this.x = quaternion.x;
            this.y = quaternion.y;
            this.z = quaternion.z;
            this.w = quaternion.w;
        }
        
        public Quaternion ToQuaternion() {
            return new Quaternion(x, y, z, w);
        }
    }
    
    [Serializable]
    public class SColor {
        public float r;
        public float g;
        public float b;
        public float a;

        public SColor(float r, float g, float b, float a = 1f) {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
        
        public SColor(Color color) {
            this.r = color.r;
            this.g = color.g;
            this.b = color.b;
            this.a = color.a;
        }
        
        public Color ToColor() {
            return new Color(r, g, b, a);
        }
    }
    
    [Serializable]
    public class SRect {
        public float x;
        public float y;
        public float width;
        public float height;

        public SRect(float x, float y, float width, float height) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        
        public SRect(Rect rect) {
            this.x = rect.x;
            this.y = rect.y;
            this.width = rect.width;
            this.height = rect.height;
        }
        
        public Rect ToRect() {
            return new Rect(x, y, width, height);
        }
    }
}