using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SaveObject
{
    public string mapName;
    public List<string> cameraAngles = new List<string>();
    public List<string> activeComponents = new List<string>();
    
}
