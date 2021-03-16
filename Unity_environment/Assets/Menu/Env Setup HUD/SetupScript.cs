using System.Collections.Generic;
using Menu.SaveManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using University_Classroom.Scripts;
using static Menu.SaveManager.SaveObject;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Menu.Env_Setup_HUD
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
        
        private const int DefaultToggleSpacing = -120;
        private const int ConfigSpacing = -70;

        void Start()
        {
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
            LoadSettings.settingsPresent = true;
            LoadSettings.loadFileName = "test.txt";
            
            SaveObject saveObj = null;
            if (LoadSettings.settingsPresent)
            {
                saveObj = SaveUtils.Load(LoadSettings.loadFileName);
                var cameraAngles = saveObj.cameraPositions;
                LoadCameraAngles(cameraAngles);
                
                // reset load settings
                LoadSettings.settingsPresent = false;
                LoadSettings.loadFileName = null;
            }

            Vector3 nextComponentPos = togglePrefab.transform.position;
            
            foreach (Transform child in optionalComponentContainer.transform)
            {   
                
                GameObject optionalComponent = child.gameObject;
                ComponentInfo info = optionalComponent.GetComponent<ComponentInfo>();
                
                // Create new ui toggle
                var toggle = Instantiate(togglePrefab, nextComponentPos, 
                    Quaternion.identity, configParent.transform);


                var config = optionalComponent.GetComponent<ComponentConfigurator>();
                if (config != null)
                {
                    nextComponentPos += new Vector3(0, ConfigSpacing, 0);
                    if (config is DesktopConfigurator deskConf)
                    {
                        deskConf.DrawConfigurationUI(configParent, nextComponentPos);
                    }
                }
                nextComponentPos += new Vector3(0, DefaultToggleSpacing, 0);
                
                toggle.GetComponentsInChildren<Text>()[0].text = info.componentName;
                toggle.SetActive(true);
                
                // Record mapping from ui toggle to optional component 
                _toggleComponentMap[toggle] = optionalComponent;
                
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
            
        }
        
        
        public void HudLoadPrevScene()
        {
            SceneManager.LoadScene("Welcome");
        }

        public void HudConfirmSceneConfig()
        {
            DisableSceneConfigHud();
            sceneCamera.GetComponent<RotateMoveCamera>().EnableMovement();
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
