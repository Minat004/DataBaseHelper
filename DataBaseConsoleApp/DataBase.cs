using System.Data.SQLite;

namespace DataBaseConsoleApp;

public class DataBase
{
    public DataBase(string dataSource)
    {
        Connection = new SQLiteConnection(dataSource);
        Connection.Open();

        Command = new SQLiteCommand(Connection);
    }

    public void CreateTable()
    {
        Command.CommandText = $"CREATE TABLE IF NOT EXISTS workers(" + 
                              $"id INTEGER PRIMARY KEY AUTOINCREMENT," +
                              $"first_name TEXT," +
                              $"last_name TEXT," +
                              $"salary INTEGER," +
                              $"over_hours INTEGER DEFAULT 0" +
                              $")";

        Command.ExecuteNonQuery();
    }

    public void InsertData(string firstName, string lastName, int salary, int overHours = 0)
    {
        Command.CommandText = $"INSERT INTO workers(first_name, last_name, salary, over_hours) " +
                              $"VALUES(" +
                              $"'{firstName}', " +
                              $"'{lastName}', " +
                              $"{salary}, " +
                              $"{overHours}" +
                              $")";

        Command.ExecuteNonQuery();
    }

    public void ReadData()
    {
        Command.CommandText = "SELECT * FROM workers";
        var dataReader = Command.ExecuteReader();

        while (dataReader.Read())
        {
            Console.WriteLine($"{dataReader.GetInt32(0)} " +
                              $"{dataReader.GetString(1)} " +
                              $"{dataReader.GetString(2)} " +
                              $"{dataReader.GetInt32(3)} " +
                              $"{dataReader.GetInt32(4)}");
        }
    }

    private SQLiteConnection Connection { get; }
    
    private SQLiteCommand Command { get; }
}