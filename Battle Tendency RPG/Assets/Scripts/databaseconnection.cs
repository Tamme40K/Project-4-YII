using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.UI;

public class databaseconnection : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

        // Create database
        string connection = @"data source=D:\GitHub\Project4-YII\Project-4-YII\Battle Tendency RPG\Assets\database\my_database; Version=3;";

        // Open connection
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        // Create table
        IDbCommand dbcmd;
        dbcmd = dbcon.CreateCommand();
        string q_createTable = "CREATE TABLE IF NOT EXISTS my_table (id INTEGER PRIMARY KEY, name VARCHAR, score INTEGER )";

        dbcmd.CommandText = q_createTable;
        dbcmd.ExecuteReader();

        // Insert values in table
        //IDbCommand cmnd = dbcon.CreateCommand();
        //cmnd.CommandText = "INSERT INTO my_table (id, name, score) VALUES (1,'Pieter', 10)";
        //cmnd.ExecuteNonQuery();

        // Read and print all values in table
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;
        string query = "SELECT * FROM my_table";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        //while (reader.Read())
        //{
        //    Debug.Log("id: " + reader[0].ToString());
        //    Debug.Log("name: " + reader[1].ToString());
        //    Debug.Log("score: " + reader[2].ToString());
        //}

        // Close connection
        dbcon.Close();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}