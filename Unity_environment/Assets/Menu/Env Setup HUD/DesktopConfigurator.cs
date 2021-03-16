using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Menu.Env_Setup_HUD
{
    public class DesktopConfigurator : ComponentConfigurator
    {
        public GameObject desktopSelectionPrefab;
        public GameObject parent;
        
        public void DrawConfigurationUI(GameObject parentUI, Vector3 pos)
        {
            pos.x += 100;
            var configUI = Instantiate(desktopSelectionPrefab, pos, Quaternion.identity, parentUI.transform);
            var dropDown = configUI.GetComponentsInChildren<Dropdown>()[0];
            Debug.Log(GetTotalMonitors());
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