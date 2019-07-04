using SQLite4Unity3d;

public class Person  {

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public int Age { get; set; }
    public int Score { get; set; }

	public override string ToString ()
	{
		return string.Format ("{0}, {1}, {2}, {3}, {4}", Id, Name, Surname, Age, Score);
	}
}

public class Highscore
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }

    public override string ToString()
    {
        return string.Format("{0}, {1}, {2}", Id, Name, Score);
    }
}

public class Nickname
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }

    public override string ToString()
    {
        return string.Format("{0}, {1}, {2}", Id, Name, Score);
    }
}
