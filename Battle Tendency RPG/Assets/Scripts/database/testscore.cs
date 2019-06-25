using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.UI;

public class testscore : MonoBehaviour
{
    public Text score;
    public string storescore;

    // Start is called before the first frame update
    void Start()
    {
        ReadScore();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //    AddPoints(5);
        //    ReadScore();
        //}
    }

    public void AddPoints(int score_worth)
    {
        string connection = @"data source=D:\GitHub\Project4-YII\Project-4-YII\Battle Tendency RPG\Assets\database\my_database; Version=3;";

        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;
        string query = "UPDATE my_table SET score = score + " + score_worth + " WHERE name = 'Gregory'";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        dbcon.Close();

        Debug.Log("Points have been added");
    }

    public void ReadScore()
    {
        // Create database
        string connection = @"data source=D:\GitHub\Project4-YII\Project-4-YII\Battle Tendency RPG\Assets\database\my_database; Version=3;";// <-- deze werkt voor Windows
        //string connection = "URI=file:" + Application.dataPath + "/StreamingAssets/my_database.db";

        // Open connection
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        // Read and print all values in table
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;
        string query = "SELECT score FROM my_table WHERE name = 'Gregory'";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        //while (reader.Read())
        //{
        //    Debug.Log("id: " + reader[0].ToString());
        //    Debug.Log("name: " + reader[1].ToString());
        //    Debug.Log("score: " + reader[2].ToString());
        //}

        //store value in a variable so you can use the variable even after database connection closes
        storescore = (reader[0].ToString());

        // Close connection
        dbcon.Close();
        score.text = storescore;
        Debug.Log(storescore);
    }
}
