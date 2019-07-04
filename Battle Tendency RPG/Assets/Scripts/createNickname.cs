using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class createNickname : MonoBehaviour {

    public InputField inputText;
    public string tutorialText;
    // Start is called before the first frame update
    void Start()
    {
        //tutorialText = PlayerPrefs.GetString("tutorialTextKeyName");
        //inputText.text = tutorialText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveThis()
    {
        tutorialText = inputText.text;
        PlayerPrefs.SetString("tutorialTextKeyName", tutorialText);
        Debug.Log(tutorialText);
    }
}
