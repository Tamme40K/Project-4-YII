using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ExistingDBScript : MonoBehaviour {

    public Text nickname;
    public Text score;
    private string testphrase;
    private string nicknameholder;
    private string scoreholder;

	// Use this for initialization
	void Start () {
		var ds = new DataService ("existing.db");
		//ds.CreateDB ();
		//var people = ds.GetPersons ();
		//ToConsole (people);

        //CREATE A PERSON!
		//ds.CreatePerson ();
		//ToConsole("New person has been created");

		var p = ds.GetNickname();
        testphrase = p.ToString();
        string[] testzin = testphrase.Split(',');

        nicknameholder = testzin[1].ToString();
        scoreholder = testzin[4].ToString();

        Debug.Log(testzin[1]);
        Debug.Log(testzin[4]);

        nickname.text = nicknameholder;
        score.text = scoreholder;

        //Debug.Log(testphrase);
        //ToConsole(p.ToString());
        //TestText.text = p.ToString();
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
