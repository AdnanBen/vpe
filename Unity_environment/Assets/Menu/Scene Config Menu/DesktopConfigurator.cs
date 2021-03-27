using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Scene_Config_Menu
{
    public class DesktopConfigurator : MonoBehaviour, IComponentConfigurator
    {
        public GameObject desktopSelectionPrefab;

        public int GetUISize()
        {
            return 50;
        }
        
        public void DrawConfigUI(GameObject parentUI)
        {
            var configUI = Instantiate(desktopSelectionPrefab, parentUI.transform, false);
            configUI.transform.position += new Vector3(30, -50, 0);
            var dropDown = configUI.GetComponentsInChildren<Dropdown>()[0];
            
            foreach (var m in Enumerable.Range(0, GetTotalMonitors()+1))
            {
                dropDown.options.Add(new Dropdown.OptionData(m.ToString()));
            }
            
            dropDown.onValueChanged.AddListener(delegate
            {
                UpdateConfigurationChange(dropDown.value);
            });

        }
        
        private int GetTotalMonitors()
        {
            return Display.displays.Length;
        }
        
        private void UpdateConfigurationChange(int newMonitor)
        {
            var texture = GetComponent<uDesktopDuplication.Texture>();
            texture.monitorId = newMonitor;
        }
        
    }
}