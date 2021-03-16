using System.Collections.Generic;
using static Menu.Env_Setup_HUD.SaveLoadCameraAngles;

namespace Menu.SaveManager
{
    [System.Serializable]
    public class SaveObject
    {
        public string mapName;
        public CameraPosition[] cameraPositions = new CameraPosition[11];
        public List<string> activeComponents = new List<string>();
    }
}
