using Menu.Env_Setup_HUD;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.SaveManager
{

    public class SaveAPI : MonoBehaviour
    {
        
        public GameObject cam = null;
        public GameObject optionalComponentContainer;
        
        private static string _testFileName = "test.txt";


        void Update()
        {

            if (Input.GetKeyDown(KeyCode.K))
            {
                SaveSceneSettings(_testFileName);
            }
            
        }


        public void SaveSceneSettings(string saveName)
        {
            var save = new SaveObject {mapName = SceneManager.GetActiveScene().name};

            foreach (Transform child in optionalComponentContainer.transform)
            {   
                GameObject optionalComponent = child.gameObject;
                if (optionalComponent.activeSelf)
                {
                    ComponentInfo info = optionalComponent.GetComponent<ComponentInfo>();
                    save.activeComponents.Add(info.internalName);
                }   
            }

            save.cameraPositions = cam.GetComponent<SaveLoadCameraAngles>().cameraPositions;
            
            
            SaveUtils.Save(save, saveName);
        }
    }
}
