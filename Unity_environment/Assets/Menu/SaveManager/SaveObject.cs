using System.Collections.Generic;
using static Menu.Scene_Config_Menu.CameraScripts.SaveLoadCameraAngles;

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
