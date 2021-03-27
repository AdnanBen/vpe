using UnityEngine;
using UnityEngine.UI;

namespace Menu.Main_Menu
{
    public class ToggleImage : MonoBehaviour
    {
        
        public GameObject uiComponent;
        
        private Toggle tog;
        
        void Start()
        {
            tog = GetComponent<Toggle>();
        }
        

        public void onToggleChange() {
            uiComponent.SetActive(!uiComponent.activeSelf);
        }
    }
}
