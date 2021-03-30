using System.IO;
using UnityEngine;

namespace Menu.Main_Menu
{
    public class ConfigManager : MonoBehaviour
    {

        private static string _configFolder;
        private const string ConfigFileName = "config.json";
        
        void Start()
        {
            _configFolder = Application.dataPath + "/Config/";
            CreateConfigFilesIfAbsent();
        
        }

        private static void CreateConfigFilesIfAbsent()
        {
            if (Directory.Exists(_configFolder)) return;
            
            Directory.CreateDirectory(_configFolder);
            var jsonSaveObject = JsonUtility.ToJson(new ConfigObject());
            File.WriteAllText(_configFolder + ConfigFileName, jsonSaveObject);
        }

        public static ConfigObject GetConfig()
        {
            var saveObject = new ConfigObject();
            
            if (File.Exists(_configFolder + ConfigFileName)) {
                string json = File.ReadAllText(_configFolder + ConfigFileName);
                saveObject = JsonUtility.FromJson<ConfigObject>(json);
                
            }

            return saveObject;
        }
    
    }
    
    
    [System.Serializable]
    public class ConfigObject
    {
        [SerializeField]
        public string WebAppURL = "https://vpe-video-chat.herokuapp.com/";
    }
}
