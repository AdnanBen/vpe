using UnityEngine;

namespace Menu.Main_Menu
{
    public class TargetFrameRateSetter : MonoBehaviour
    {

        void Start()
        {
            Application.targetFrameRate = 30;
        }
        
    }
}
