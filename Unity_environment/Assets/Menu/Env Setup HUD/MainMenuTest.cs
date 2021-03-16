using System.Collections;
using System.Collections.Generic;
using Menu.Env_Setup_HUD;
using UnityEngine;

public class MainMenuTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadSettings.settingsPresent = true;
        LoadSettings.loadFileName = "test.txt";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
