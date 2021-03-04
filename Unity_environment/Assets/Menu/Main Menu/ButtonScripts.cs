using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu.Main_Menu
{
    public class ButtonScripts : MonoBehaviour
    {
        public GameObject toggleGroupObject;

        private GameObject _selectedScene;
        
        

        public void nextButton()
        {
            var toggleGroup = toggleGroupObject.GetComponent<ToggleGroup>();
            var selectedScene = toggleGroup.ActiveToggles().First().GetComponent<SceneRelation>().scene;
            SceneManager.LoadScene(selectedScene);

        }
    }
}
