using UnityEngine;

namespace Menu.Main_Menu
{
    public class TargetFrameRateSetter : MonoBehaviour
    {

        void Start()
        {
            // Sets vSync to half frames
            // Most displays are 60hz, -> application will run at 30fps
            QualitySettings.vSyncCount = 2;
        }
        
    }
}
