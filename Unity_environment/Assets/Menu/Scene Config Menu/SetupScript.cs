using System.Collections.Generic;
using Menu.SaveManager;
using Menu.Scene_Config_Menu.CameraScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

namespace Menu.Scene_Config_Menu
{
    public class SetupScript : MonoBehaviour
    {
        
        public GameObject optionalComponentContainer;
        public Camera sceneCamera;
        public GameObject configParent;
        public GameObject sceneConfigHud;
        public GameObject dropDownMenuButton;
        public GameObject togglePrefab;

        private bool _hudInitDone;
        private readonly Dictionary<GameObject, GameObject> _toggleComponentMap = new Dictionary<GameObject, GameObject>();
        
        private const int DefaultToggleSpacing = -70;

        void Start()
        {
            Application.targetFrameRate = 30;
            SceneConfig();
        }

        void SceneConfig()
        {
            EnableSceneConfigHud();
        }
        
        
        public void EnableSceneConfigHud()
        {
            if (!_hudInitDone)
            {
                HudSetup();
                _hudInitDone = true;
            }

            if (!sceneConfigHud.activeSelf)
            {
                sceneConfigHud.SetActive(true);
            }
        }

        public void LoadCameraAngles(SaveLoadCameraAngles.CameraPosition[] angles)
        {
            sceneCamera.GetComponent<SaveLoadCameraAngles>().cameraPositions = angles;
        }
        
        

        private void HudSetup()
        {
            SaveObject saveObj = null;
            if (LoadSettings.settingsPresent)
            {
                saveObj = SaveUtils.Load(LoadSettings.loadFileName);
                var cameraAngles = saveObj.cameraPositions;
                LoadCameraAngles(cameraAngles);
            }
            
            // Holds vertical offset amount, applied before next element drawn 
            Vector3 nextComponentOffset = Vector3.zero;
            
            foreach (Transform child in optionalComponentContainer.transform)
            {   
                
                GameObject optionalComponent = child.gameObject;
                ComponentInfo info = optionalComponent.GetComponent<ComponentInfo>();
                
                // Create new ui toggle
                var toggle = Instantiate(togglePrefab, configParent.transform, false);
                toggle.transform.position += nextComponentOffset;

                // Draw configurator settings if present 
                var config = optionalComponent.GetComponent<IComponentConfigurator>();
                if (config != null)
                {
                    nextComponentOffset += new Vector3(0, -config.GetUISize(), 0);
                    config.DrawConfigUI(configParent);
                }
                
                toggle.GetComponentsInChildren<Text>()[0].text = info.componentName;
                toggle.SetActive(true);
                
                // Record mapping from ui toggle to optional component 
                _toggleComponentMap[toggle] = optionalComponent;
                
                // Set offset for next UI component 
                nextComponentOffset += new Vector3(0, DefaultToggleSpacing, 0);
                
                // Assign listener to toggle
                Toggle toggleUIObject = toggle.GetComponent<Toggle>();
                toggleUIObject.onValueChanged.AddListener(delegate(bool arg0)
                {
                    // Toggle corresponding optional component
                    var obj = _toggleComponentMap[toggle];
                    obj.SetActive(!obj.activeSelf);
                });
        
                // Enable if component in save config else if on by default
                bool enable;
                if (LoadSettings.settingsPresent && saveObj != null)
                {
                    enable = saveObj.activeComponents.Contains(info.internalName);
                }
                else
                {
                    enable = info.enabledByDefault;
                }
                toggleUIObject.isOn = enable;
            }
            
            ResetLoadSettings();
            
        }

        private void ResetLoadSettings()
        {
            LoadSettings.settingsPresent = false;
            LoadSettings.loadFileName = null;
        }
        
        
        public void HudLoadPrevScene()
        {
            SceneManager.LoadScene("Welcome");
        }

        public void HudConfirmSceneConfig()
        {
            DisableSceneConfigHud();
            RotateMoveCamera.EnableMovement();
            dropDownMenuButton.SetActive(true);
        }
        
        private void DisableSceneConfigHud()
        {
            if (_hudInitDone)
            {
                sceneConfigHud.SetActive(false);
            }
        }
    }
}
