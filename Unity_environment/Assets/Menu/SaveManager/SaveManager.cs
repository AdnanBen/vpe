using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string saveFolderName = "/Saves/";
    public static string fileName = "test.txt";
    
    public static void Save(SaveObject saveObject)
    {

        string saveFolderDirectory = Application.persistentDataPath + saveFolderName;

        // Check if folder exists yet, if not, create
        if (!Directory.Exists(saveFolderDirectory)) {
            Directory.CreateDirectory(saveFolderDirectory);
        }

        string jsonSaveData = JsonUtility.ToJson(saveObject);
        File.WriteAllText(saveFolderDirectory + fileName, jsonSaveData);
    }


    public static SaveObject Load()
    {
        string loadFileDirectory = Application.persistentDataPath + saveFolderName + fileName;
        SaveObject saveObject = new SaveObject();

        if (File.Exists(loadFileDirectory)) {
            string json = File.ReadAllText(loadFileDirectory);
            saveObject = JsonUtility.FromJson<SaveObject>(json);
        }

        return saveObject;
        
    }


}
