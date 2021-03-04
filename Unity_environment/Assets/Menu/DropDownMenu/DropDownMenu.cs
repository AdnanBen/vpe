using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMenu : MonoBehaviour
{
	public Button cog;
    public GameObject selectedCog;
	public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onButtonPress() {
    	panel.SetActive(!panel.activeSelf);
        selectedCog.SetActive(!selectedCog.activeSelf);
    }
}
