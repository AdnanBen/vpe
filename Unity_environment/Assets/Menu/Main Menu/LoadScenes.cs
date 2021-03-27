using System.Collections.Generic;
using System.Linq;
using Menu.SaveManager;
using Menu.Scene_Config_Menu;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu.Main_Menu
{
    public class LoadScenes : MonoBehaviour
    {
        private readonly List<(string, string)> _testFileList = new List<(string mapName, string fileName)>
        {
            ("Grand LT", "teaching"),
            ("Conference Room", "meetings"),
            ("Small LT", "tutorials"),
            ("Exam Room", "exams"),
            ("Conference Panel", "discussion"),
            ("Grand LT", "teaching"),
            ("Conference Room", "meetings"),
            ("Small LT", "tutorials"),
            ("Exam Room", "exams"),
            ("Conference Panel", "discussion")
        };
        
        private const char MapNameSaveNameSeparator = ':';
        
        public RectTransform panel;
        public GameObject togglePrefab;
        
        private ToggleGroup _togGroup;

        private Toggle currentSelection => _togGroup.ActiveToggles().FirstOrDefault();

        // Start is called before the first frame update
        void Start()
        {
            _togGroup = GetComponent<ToggleGroup>();
            GenerateUIOptions(panel, SaveUtils.ReadAvailableSaves());
        }
    

        private void GenerateUIOptions(RectTransform panelGameObj, IReadOnlyCollection<(string, string)> savedScenes)
        {
            // stretching the scroll panel depending on how many elements in the list
            panelGameObj.offsetMin = new Vector2(panelGameObj.offsetMin.x, savedScenes.Count * -40);
            
            // for each tuple in list
            // create a toggle with corresponding text

            foreach (var (item1, item2) in savedScenes)
            {
                // Create new option 
                GameObject toggle = Instantiate(togglePrefab, panelGameObj, false);
                toggle.transform.SetParent(panelGameObj.transform);
                
                // Set option name
                var formattedOptionName = $"{item1}{MapNameSaveNameSeparator} {item2}";
                toggle.GetComponentInChildren<Text>().text = formattedOptionName;
                toggle.name = formattedOptionName;
                
                // Set toggle group
                toggle.GetComponent<Toggle>().group = _togGroup;
            }
        }
        
        
        public void LoadButtonPressed()
        {
            if (currentSelection == null) return;
            
            var p = currentSelection.name.Split(MapNameSaveNameSeparator);
            var mapName = p[0];
            var saveFileName = p[1].Substring(1);
            LoadSettings.settingsPresent = true;
            LoadSettings.loadFileName = saveFileName;
            SceneManager.LoadScene(mapName);
        }

        
        public void OnShowInExplorerButton()
        {
            SaveUtils.EnsureSaveDirectoryExists();
            // Windows needs black slashes in path 
            var pathBackslashed = SaveUtils.SaveFolderDirectory.Replace(@"/", @"\");
            System.Diagnostics.Process.Start("explorer.exe", "/select,"+pathBackslashed);
        }
        
    }
}