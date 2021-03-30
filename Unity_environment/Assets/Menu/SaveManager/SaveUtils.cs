using System.Collections.Generic;
using System.IO;
using System.Linq;
using Menu.Scene_Config_Menu;
using Menu.Scene_Config_Menu.CameraScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.SaveManager
{
    public static class SaveUtils
    {
        private const string SaveFolderName = "/Saves/";
        public static readonly string SaveFolderDirectory = Application.persistentDataPath + SaveFolderName;
        
        public static List<(string, string)> ReadAvailableSaves()
        {
            EnsureSaveDirectoryExists();
            
            var savesList = new List<(string, string)>();
            string[] files = Directory.GetFiles(SaveFolderDirectory, "*", SearchOption.TopDirectoryOnly);
            foreach (var f in files)
            {
                var fileName = f.Split('/').Last();
                SaveObject saveObject = Load(fileName);
                savesList.Add((saveObject.mapName, fileName));
            }

            return savesList;
        }
        
        public static void SaveSceneSettings(string saveName, GameObject cam, GameObject optionalComponentContainer)
        {
            var save = new SaveObject {mapName = SceneManager.GetActiveScene().name};

            foreach (Transform child in optionalComponentContainer.transform)
            {   
                var optionalComponent = child.gameObject;
                if (optionalComponent.activeSelf)
                {
                    var info = optionalComponent.GetComponent<ComponentInfo>();
                    save.activeComponents.Add(info.internalName);
                }   
            }

            save.cameraPositions = cam.GetComponent<SaveLoadCameraAngles>().cameraPositions;
            
            Save(save, saveName);
        }

        public static void EnsureSaveDirectoryExists()
        {
            if (!Directory.Exists(SaveFolderDirectory)) {
                Directory.CreateDirectory(SaveFolderDirectory);
            }
        }
        
        private static void Save(SaveObject saveObject, string fileName)
        {
            EnsureSaveDirectoryExists();
            string jsonSaveData = JsonUtility.ToJson(saveObject);
            File.WriteAllText(SaveFolderDirectory + fileName, jsonSaveData);
        }


        public static SaveObject Load(string fileName)
        {
            string loadFileDirectory = SaveFolderDirectory + fileName;
            SaveObject saveObject = new SaveObject();

            if (File.Exists(loadFileDirectory)) {
                string json = File.ReadAllText(loadFileDirectory);
                saveObject = JsonUtility.FromJson<SaveObject>(json);
                
            }

            return saveObject;
        }

    }
}
