namespace DataBaseConsoleApp;

internal static class Program 
{
    public static void Main(string[] args)
    {
        const string sdb = "Data Source=db_console_test.db";
        var db = new DataBase(sdb);
        
        // db.CreateTable();
        // db.InsertData("Alex", "Bell", 2000);
        db.ReadData();
        
    }
}