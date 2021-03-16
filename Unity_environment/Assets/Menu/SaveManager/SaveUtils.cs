using System.IO;
using UnityEngine;

namespace Menu.SaveManager
{
    public static class SaveUtils
    {
        private const string SaveFolderName = "/Saves/";

        public static void Save(SaveObject saveObject, string fileName)
        {
            string saveFolderDirectory = Application.persistentDataPath + SaveFolderName;
            
            if (!Directory.Exists(saveFolderDirectory)) {
                Directory.CreateDirectory(saveFolderDirectory);
            }

            string jsonSaveData = JsonUtility.ToJson(saveObject);
            File.WriteAllText(saveFolderDirectory + fileName, jsonSaveData);
        }


        public static SaveObject Load(string fileName)
        {
            string loadFileDirectory = Application.persistentDataPath + SaveFolderName + fileName;
            SaveObject saveObject = new SaveObject();

            if (File.Exists(loadFileDirectory)) {
                string json = File.ReadAllText(loadFileDirectory);
                saveObject = JsonUtility.FromJson<SaveObject>(json);
            }

            return saveObject;
        }


    }
}
