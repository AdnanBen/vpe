using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LoadScenes : MonoBehaviour
{
    public List<(string, string)> saved = new List<(string mapName, string fileName)>
    {
        ("Grand LT", "teaching"),
        ("Conference Room", "meetings"),
        ("Small LT", "tutorials"),
        ("Exam Room", "exams"),
        ("Conference Panel", "discussion")
    };

    // public List<string, string> savedScenes;
    public RectTransform panel;
    public GameObject togglePrefab;
    ToggleGroup togGroup;

    public Toggle currentSelection
    {
        get { return togGroup.ActiveToggles().FirstOrDefault(); }
    }

    // Start is called before the first frame update
    void Start()
    {
        togGroup = GetComponent<ToggleGroup>();
        ToggleCreation(panel, saved);
    }

    // Update is called once per frame
    void Update()
    {
        ReturnChosenScene(saved);
    }

    public void ToggleCreation(RectTransform panelGameObj, List<(string, string)> savedScenes)
    {
        // stretching the scroll panel depending on how many elements in the list

        if (savedScenes.Count > 4)
        {
            panelGameObj.offsetMin = new Vector2(panelGameObj.offsetMin.x, (savedScenes.Count - 4) * -75);
        }


        // for each tuple in list
        // create a toggle with corrosponding text

        foreach (var scene in savedScenes)
        {

            GameObject toggle = (GameObject)Instantiate(togglePrefab);
            toggle.transform.SetParent(panelGameObj.transform);
            toggle.GetComponentInChildren<Text>().text = $"{scene.Item1} |\n {scene.Item2}";
            toggle.name = scene.Item1 + "|" + scene.Item2;

        }
    }

    public (string, string) ReturnChosenScene(List<(string, string)> savedScenes)
    {
        // if the chosen toggle name matches the scene tuple elements that scene is returned

        foreach (var scene in savedScenes)
        {
            if (currentSelection.name == scene.Item1 + "|" + scene.Item2)
            {
                // Debug.Log(scene);
                return scene;
            }
        }
        return (null, null);
    }
}