using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.Env_Setup_HUD
{

    public class SaveTest : MonoBehaviour
    {

        public GameObject camera = null;
        public SaveObject saveObject;
        public GameObject optionalComponentContainer;

        private SaveLoadCameraAngles script;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {


            if (Input.GetKeyDown(KeyCode.S))
            {
                saveObject.mapName = "";
                saveObject.activeComponents.Clear();

                saveObject.mapName = SceneManager.GetActiveScene().name;
                foreach (Transform child in optionalComponentContainer.transform)
                {   
                    GameObject optionalComponent = child.gameObject;
                    if (optionalComponent.activeSelf == true)
                    {
                        ComponentInfo info = optionalComponent.GetComponent<ComponentInfo>();
                        saveObject.activeComponents.Add(info.componentName);
                    }   
                }

            script = camera.GetComponent<SaveLoadCameraAngles>();

            for (int i = 0; i < 11; i++)
            {
                //saveObject.cameraAngles.Add();

                saveObject.cameraPositions[i].position = camera.GetComponent<SaveLoadCameraAngles>().cameraPositions[i].position;
                saveObject.cameraPositions[i].rotationx = camera.GetComponent<SaveLoadCameraAngles>().cameraPositions[i].rotationx;
                saveObject.cameraPositions[i].rotationy = camera.GetComponent<SaveLoadCameraAngles>().cameraPositions[i].rotationy;

            }

                SaveManager.Save(saveObject);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                saveObject = SaveManager.Load();
            }
        }
    }

}
