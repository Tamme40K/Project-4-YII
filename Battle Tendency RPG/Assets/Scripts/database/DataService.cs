using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;
using System.Linq;

public class DataService  {

	private SQLiteConnection _connection;

	public DataService(string DatabaseName){

#if UNITY_EDITOR
            var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
            _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);     

	}

	public void CreateDB(){
		_connection.DropTable<BooleanHolder> ();
		_connection.CreateTable<BooleanHolder> ();

		_connection.InsertAll (new[]{
			new BooleanHolder{
				Id = 1,
				Name = "Tom",
				Score = 0, 
                FireBoolHolder = "false", 
                HolyBoolHolder = "false"
			}
		});
	}

	public IEnumerable<Person> GetPersons(){
		return _connection.Table<Person>();
	}

	public IEnumerable<Person> GetPersonsNamedRoberto(){
		return _connection.Table<Person>().Where(x => x.Name == "Roberto");
	}

	public Person GetJohnny(){
		return _connection.Table<Person>().Where(x => x.Name == "Johnny").FirstOrDefault();
	}

    public string GetScore(string nickname)
    {
        var p = _connection.Table<Highscore>().Where(x => x.Name == nickname).FirstOrDefault();

        return p.ToString();
    }

    public string GetNickname(string nickname)
    {
        var p = _connection.Table<Nickname>().Where(x => x.Name == nickname).FirstOrDefault();

        return p.ToString();
    }

    public string GetFireBooleanValue(string nickname)
    {
        var p = _connection.Table<BooleanHolder>().Where(x => x.Name == nickname).FirstOrDefault();

        return p.ToString();
    }

    public string GetHolyBooleanValue(string nickname)
    {
        var p = _connection.Table<BooleanHolder>().Where(x => x.Name == nickname).FirstOrDefault();

        return p.ToString();
    }

    public void ChangeFireBoolean(string boolean, string nickname)
    {
        var tp = _connection.Query<BooleanHolder>("UPDATE BooleanHolder SET FireBoolHolder = '" + boolean + "' WHERE name = '" + nickname + "';").FirstOrDefault();

        _connection.Update(tp);
    }

    public void ChangeHolyBoolean(string boolean, string nickname)
    {
        var tp = _connection.Query<BooleanHolder>("UPDATE BooleanHolder SET HolyBoolHolder = '" + boolean + "' WHERE name = '" + nickname + "';").FirstOrDefault();

        _connection.Update(tp);
    }

    public void AddPoints()
    {
        _connection.Table<Highscore>().Where(x => x.Name == "Tom");
    }

    public void ChangePoints(int score_worth, string nickname)
    {
        var tp = _connection.Query<Highscore>("UPDATE Highscore SET score = score + " + score_worth + " WHERE name = '"+nickname+"';").FirstOrDefault();

        _connection.Update(tp);
    }


    public Person CreatePerson(){
		var p = new Person{
				Name = "Johnny",
				Surname = "Mnemonic",
				Age = 21,
                Score = 50
		};
		_connection.Insert (p);
		return p;
	}

    public Nickname CreateNickname(string name)
    {
        var p = new Nickname
        {
            Name = name,
            Score = 0
        };
        _connection.Insert(p);
        return p;
    }

    public Highscore CreateHighscore(string name)
    {
        var p = new Highscore
        {
            Name = name,
            Score = 0
        };
        _connection.Insert(p);
        return p;
    }

    public BooleanHolder CreateBooleanHolder(string name)
    {
        var p = new BooleanHolder
        {
            Name = name,
            Score = 0,
            FireBoolHolder = "false", 
            HolyBoolHolder = "false"
        };
        _connection.Insert(p);
        return p;
    }
}
