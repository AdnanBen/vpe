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
        uiComponent.SetActive(!uiComponent.activeSelf);
    }
}
