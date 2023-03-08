using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Daydream
{
    public static class SOUtil
    {
        public static T Find<T>()
            where T : ScriptableObject
        {
            if (Application.isPlaying)
            {
                Debug.LogError("SOUtil.Find should only be used in the editor (eg. in Reset)");
            }
            string[] guids = AssetDatabase.FindAssets(string.Format("t:{0}", typeof(T).Name));
            foreach (var guid in guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                T asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
                if (asset != null) return asset;
            }
            return null;
        }
    }
}
