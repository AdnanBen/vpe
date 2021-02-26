using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.Selection_Menu
{
    public class SelectionMenuScript : MonoBehaviour
    {
        public void MainMenu()
        {
            SceneManager.LoadScene("Main Menu Scene");
        }

        public void SceneSettings()
        {
            SceneManager.LoadScene("Lecture Hall");
        }
    
    }
}
