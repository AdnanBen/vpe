using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMenuOptions : MonoBehaviour
{
    
	public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void onToggleSceneComponentsButton() {

    }

    public void onHelpButton() {

    }

    public void onMultiplePresentersButton() {
        Application.OpenURL("https://presentr-video-chat.herokuapp.com");
        Debug.Log("fse");
    }
}
