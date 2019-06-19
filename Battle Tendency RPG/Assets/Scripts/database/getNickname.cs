using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class getNickname : MonoBehaviour
{
    public Text name;
    private string testphrase;
    private string playerName;

    // Use this for initialization
    void Start()
    {
        var getNickname = new DataService("nickname.db");
        getNickname.CreateDB ();
        //var people = ds.GetPersons ();
        //ToConsole (people);

        //CREATE A PERSON!
        //ds.CreatePerson ();
        //ToConsole("New person has been created");

        var nickname = getNickname.GetNickname();
        Debug.Log(nickname);
        testphrase = nickname.ToString();
        Debug.Log(testphrase);
        string[] testzin = testphrase.Split(',');
        Debug.Log(testzin[1]);
        playerName = testzin[1];
        Debug.Log(playerName);
        name.text = playerName;

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

