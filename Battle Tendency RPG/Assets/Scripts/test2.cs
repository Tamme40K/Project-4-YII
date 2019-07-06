    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test2 : MonoBehaviour
{
    public Text score;
    private string testphrase;
    private string playerScore;

    // Use this for initialization
    void Start()
    {
        ReadPoints();
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

    public void UpdatePoints(int score_worth)
    {
        var getScore = new DataService("highschore.db");
        string nickname2 = (PlayerPrefs.GetString("tutorialTextKeyName"));
        getScore.ChangePoints(score_worth, nickname2);// DIT WERKT
    }

    public void ReadPoints()
    {
        var getScore = new DataService("highschore.db");
        string nickname2 = (PlayerPrefs.GetString("tutorialTextKeyName"));
        getScore.CreateHighscore(nickname2);
        Debug.Log("dit word geraakt");
        //getScore.ChangePoints(); DIT WERKT
        //UpdatePoints(); DIT WERKT 
        //getScore.CreateDB ();
        //var people = ds.GetPersons ();
        //ToConsole (people);

        //CREATE A PERSON!
        //ds.CreatePerson ();
        //ToConsole("New person has been created");

        //var score2 = getScore.GetScore();
        //Debug.Log(score2);
        //testphrase = score2.ToString();
        //Debug.Log(testphrase);
        //string[] testzin = testphrase.Split(',');
        //Debug.Log(testzin[2]);
        //playerScore = testzin[2];
        //Debug.Log(playerScore);
        //score.text = playerScore;
        //scoreholder = testzin[4].ToString();

        //score.text = scoreholder;
        //Debug.Log(scoreholder);
    }
}
