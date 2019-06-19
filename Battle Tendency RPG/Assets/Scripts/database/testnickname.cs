using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.UI;

public class testnickname : MonoBehaviour
{
    public Text nickname;
    public string storename;
    private string connectionString;
    private string path;

    private string dbPath;
    // Start is called before the first frame update
    void Start()
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
        string query = "SELECT name FROM my_table WHERE name = 'Gregory'";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        //while (reader.Read())
        //{
        //    Debug.Log("id: " + reader[0].ToString());
        //    Debug.Log("name: " + reader[1].ToString());
        //    Debug.Log("score: " + reader[2].ToString());
        //}

        //store value in a variable so you can use the variable even after database connection closes
        storename = (reader[0].ToString());

        // Close connection
        dbcon.Close();
        nickname.text = storename;
        Debug.Log(storename);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

