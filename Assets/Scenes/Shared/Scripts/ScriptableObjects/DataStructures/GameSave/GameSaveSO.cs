using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;


namespace Kulip
{
    public class GameSave<T>: ScriptableObject
    {
        [SerializeField] T _defaultValue;
        private string JsonData = "";
        private byte[] JsonByte;
        private List<Tuple<StaticSO<T>,string>> Data = new List<Tuple<StaticSO<T>,string>>();
        private string tempPath = System.IO.Path.Combine(Application.persistentDataPath, "data","Game Save.txt");

        // Method to add StaticSOs to list to be serialized
        public void AddItem(StaticSO<T> Item, string Name )
        {
            Data.Add(Tuple.Create(Item, Name));
        }

        // Method to serialize the list
        public void Save()
        {
            JsonData = JsonUtility.ToJson(Data ,true);
            JsonByte = Encoding.ASCII.GetBytes(JsonData);

            // Create directory if not exists
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(tempPath)))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(tempPath));
            }

            // Writing serialized data to file specified above
            try
            {
                System.IO.File.WriteAllBytes(tempPath, JsonByte);
                Debug.Log("Saved Data to: " + tempPath.Replace("/", "\\"));
            }
            catch (Exception e)
            {
                Debug.LogWarning("Failed To PlayerInfo Data to: " + tempPath.Replace("/", "\\"));
                Debug.LogWarning("Error: " + e.Message);
            }
        }
    }
}