using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getBoolean : MonoBehaviour
{
    public Text name;
    private string testphrase;
    private string playerName;
    private string fireBooleanValue;
    private string holyBooleanValue;
    private bool fireBooleanStatus;
    private bool holyBooleanStatus;

    // Use this for initialization
    void Start()
    {
        var getBoolean = new DataService("booleanholder.db");
        string nickname2 = (PlayerPrefs.GetString("tutorialTextKeyName"));
        //getBoolean.ChangeFireBoolean("false", nickname2);
        //getBoolean.ChangeHolyBoolean("true", nickname2);
        //getBoolean.CreateDB ();
        //getBoolean.CreateDB();
        //var people = ds.GetPersons ();
        //ToConsole (people);

        //CREATE A PERSON!
        //ds.CreatePerson ();
        //ToConsole("New person has been created");
        //getBoolean.CreateBooleanHolder(nickname2);

        var boolval = getBoolean.GetHolyBooleanValue(nickname2);
        Debug.Log(boolval);
        testphrase = boolval.ToString();
        Debug.Log(testphrase);
        string[] testzin = testphrase.Split(',');
        Debug.Log(testzin[3]);
        Debug.Log(testzin[4]);
        fireBooleanValue = testzin[3];
        holyBooleanValue = testzin[4];

        if (fireBooleanValue == "true")
        {
            fireBooleanStatus = true;
        }
        else
        {
            if (fireBooleanValue == "false")
            {
                fireBooleanStatus = false;
            }
        }

        if (holyBooleanValue == "true")
        {
            holyBooleanStatus = true;
        }
        else
        {
            if (holyBooleanValue == "false")
            {
                holyBooleanStatus = false;
            }
        }

        //Debug.Log(playerName);
        //name.text = playerName;

        //score.text = playerScore;
        //scoreholder = testzin[4].ToString();

        //score.text = scoreholder;
        //Debug.Log(scoreholder);
    }

    private void ToConsole(IEnumerable<Person> people)
    {
        foreach (var person in people)
        {
            ToConsole(person.ToString());
        }
    }

    private void ToConsole(string msg)
    {
        Debug.Log(msg);
    }
}

