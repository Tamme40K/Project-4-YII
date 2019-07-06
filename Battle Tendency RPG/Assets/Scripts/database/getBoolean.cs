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
    public bool fireBooleanStatus;
    public bool holyBooleanStatus;

    public bool fireValue;
    public bool holyValue;

    // Use this for initialization
    void Start()
    {
        var getBoolean = new DataService("booleanholder.db");
        string nickname2 = (PlayerPrefs.GetString("tutorialTextKeyName"));
        getBoolean.CreateBooleanHolder(nickname2);

        //getBoolean.ChangeFireBoolean("false", nickname2);
        //getBoolean.ChangeFireBoolean("true", nickname2);
        //getBoolean.CreateDB ();
        //getBoolean.CreateDB();
        //var people = ds.GetPersons ();
        //ToConsole (people);

        //CREATE A PERSON!
        //ds.CreatePerson ();
        //ToConsole("New person has been created");
        //getBoolean.CreateBooleanHolder(nickname2);

        var getFireValue = getBoolean.GetFireBooleanValue(nickname2);
        //Debug.Log(getFireValue);
        testphrase = getFireValue.ToString();
        //Debug.Log(testphrase);
        string[] testzin = testphrase.Split(',');
        //fireValue = bool.Parse(testzin[3]);
        //holyValue = bool.Parse(testzin[4]);
        //Debug.Log(fireValue.ToString());
        //Debug.Log(holyValue.ToString());
        Debug.Log(GetFireValue());
        //fireBooleanValue = testzin[3];
        //holyBooleanValue = testzin[4];

        //string t1 = TestFireValue().ToString();
        //Debug.Log(t1);
        //string t2 = TestHolyValue().ToString();
        //Debug.Log(t2);

        //Debug.Log(playerName);
        //name.text = playerName;

        //score.text = playerScore;
        //scoreholder = testzin[4].ToString();

        //score.text = scoreholder;
        //Debug.Log(scoreholder);
    }

    public void ChangeFireValue(bool value)
    {
        var getBoolean2 = new DataService("booleanholder.db");
        string nickname2 = (PlayerPrefs.GetString("tutorialTextKeyName"));

        getBoolean2.ChangeFireBoolean(value.ToString(), nickname2);
    }

    public void ChangeHolyValue(bool value)
    {
        var getBoolean2 = new DataService("booleanholder.db");
        string nickname2 = (PlayerPrefs.GetString("tutorialTextKeyName"));

        getBoolean2.ChangeHolyBoolean(value.ToString(), nickname2);
    }

    public string GetFireValue()
    {
        var getBoolean2 = new DataService("booleanholder.db");
        string nickname2 = (PlayerPrefs.GetString("tutorialTextKeyName"));

        string testphrase = getBoolean2.GetFireBooleanValue(nickname2);
        string[] testzin = testphrase.Split(',');
        string value = testzin[3];

        return value;
    }

    public string GetHolyValue()
    {
        var getBoolean2 = new DataService("booleanholder.db");
        string nickname2 = (PlayerPrefs.GetString("tutorialTextKeyName"));

        string testphrase = getBoolean2.GetHolyBooleanValue(nickname2);
        string[] testzin = testphrase.Split(',');
        string value = testzin[4];

        return value;
    }

    //public bool TestFireValue()
    //{
    //    var getBoolean = new DataService("booleanholder.db");
    //    string nickname2 = (PlayerPrefs.GetString("tutorialTextKeyName"));

    //    var getFireValue = getBoolean.GetFireBooleanValue(nickname2);
    //    Debug.Log(getFireValue);
    //    testphrase = getFireValue.ToString();
    //    Debug.Log(testphrase);
    //    string[] testzin = testphrase.Split(',');
    //    Debug.Log(testzin[3]);
    //    fireBooleanValue = testzin[3];

    //    if (fireBooleanValue == "true")
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //public bool TestHolyValue()
    //{
    //    var getBoolean = new DataService("booleanholder.db");
    //    string nickname2 = (PlayerPrefs.GetString("tutorialTextKeyName"));

    //    var getBoolValue = getBoolean.GetHolyBooleanValue(nickname2);
    //    Debug.Log(getBoolValue);
    //    testphrase = getBoolValue.ToString();
    //    Debug.Log(testphrase);
    //    string[] testzin = testphrase.Split(',');
    //    Debug.Log(testzin[4]);
    //    holyBooleanValue = testzin[4];

    //    if (holyBooleanValue == "true")
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //private void StartGetBoolean()
    //{
    //    var getBoolean = new DataService("booleanholder.db");
    //    string nickname2 = (PlayerPrefs.GetString("tutorialTextKeyName"));
    //    getBoolean.CreateBooleanHolder(nickname2);
    //}

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

