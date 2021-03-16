using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SaveObject
{

    [System.Serializable]
    public struct savedCameraPosition 
        {
            public Vector3 position;
            public float rotationx;
            public float rotationy;
        }

    public string mapName;
    public savedCameraPosition[] cameraPositions = new savedCameraPosition[11];
    public List<string> activeComponents = new List<string>();
    
}
