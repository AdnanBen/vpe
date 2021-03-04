using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using University_Classroom.Scripts;

namespace Menu.Env_Setup_HUD
{
    public class SetupScript : MonoBehaviour
    {
        
        public GameObject optionalComponentContainer;
        public Camera sceneCamera;
        public GameObject hudToggleParent;
        public GameObject sceneConfigHud;
        
        private bool _hudInitDone;
        private readonly Dictionary<GameObject, GameObject> _toggleComponentMap = new Dictionary<GameObject, GameObject>();

        private static Vector3 defaultCameraPos = new Vector3(10f, 2f, 8f);
        
        private int _toggleCount = 1;
        
        // Start is called before the first frame update
        void Start()
        {
            SceneConfig();
        }

        void SceneConfig()
        {
            EnableSceneConfigHud();
        }
        
        
        private void EnableSceneConfigHud()
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

        private void HudSetup()
        {

            foreach (Transform child in optionalComponentContainer.transform)
            {   
                
                GameObject optionalComponent = child.gameObject;
                ComponentInfo info = optionalComponent.GetComponent<ComponentInfo>();
                
                // Get next ui toggle to populate
                GameObject toggle = hudToggleParent.transform.GetChild(_toggleCount++ - 1).gameObject;
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
                
                // Enable if component on by default
                toggleUIObject.isOn = info.enabledByDefault;

            }
        }
        

        
        private void DisableSceneConfigHud()
        {
            if (_hudInitDone)
            {
                sceneConfigHud.SetActive(false);
            }
        }
        
        
        public void HudLoadPrevScene()
        {
            SceneManager.LoadScene("Welcome");
        }

        public void HudConfirmSceneConfig()
        {
            DisableSceneConfigHud();
            // sceneCamera.transform.position = defaultCameraPos;
            sceneCamera.GetComponent<RotateMoveCamera>().EnableMovement();
        }
        

        // Update is called once per frame
        void Update()
        {
        
        }
        
        
    }
}
