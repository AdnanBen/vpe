using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToggleImage : MonoBehaviour
{
    public Toggle tog;
    public GameObject uiComponent;
    
    // Start is called before the first frame update
    void Start()
    {
        tog = GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onToggleChange() {
        // checks if image is active, and does the opposite on a toggle change
        // incorrect, needs to be set active when toggle is on and inactive when toggle is off.
        if(tog.isOn){
            uiComponent.SetActive(true);
        }
        else {
            uiComponent.SetActive(false);
        }
        
    }
}
