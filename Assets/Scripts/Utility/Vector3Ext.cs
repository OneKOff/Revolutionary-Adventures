using UnityEngine;

namespace Utility
{
    public static class Vector3Ext
    {
        public static Vector3 Set(this Vector3 vec, float addedX, float addedY, float addedZ)
        {
            vec = new Vector3(addedX, addedY, addedZ);
            
            return vec;
        }
        
        public static Vector3 Append(this Vector3 vec, Vector3 addedVec)
        {
            vec = new Vector3(vec.x + addedVec.x, vec.y + addedVec.y, vec.z + addedVec.z);
            
            return vec;
        }
        
        public static Vector3 Append(this Vector3 vec, float addedX, float addedY, float addedZ)
        {
            vec = new Vector3(vec.x + addedX, vec.y + addedY, vec.z + addedZ);
            
            return vec;
        }
    }
}