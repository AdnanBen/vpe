using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu.Main_Menu
{
    public class UIScript : MonoBehaviour
    {

        public void NewScene()
        {
            SceneManager.LoadScene("Selection Scene");
        }
    }
}
