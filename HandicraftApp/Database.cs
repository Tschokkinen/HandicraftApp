using System;
using System.Data.SQLite;
using System.Collections.Generic;

//Class handling everything related to the database.
public class Database
{
    //Checks database for tables during startup and creates them if neccessary.
    public static void CreateDatabase ()
    {
        //Table list.
        var tableNames = new List<string>();
        tableNames.Add("crochetHooks");
        tableNames.Add("crochetThreads");
        tableNames.Add("misc");
        tableNames.Add("sewingFabrics");
        tableNames.Add("sewingThreads");
        tableNames.Add("sewingPatterns");

        using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db"))
        {
            connection.Open(); //Open database connection.

            foreach (string tableName in tableNames)
            {
                string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'";
                string tableData = "";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader result = cmd.ExecuteReader())
                    {
                        //If result is empty create corresponding table.
                        if (!result.HasRows)
                        {
                            switch (tableName)
                            {
                                case "sewingPatterns": 
                                    tableData = $"CREATE TABLE {tableName} (id VARCHAR(20) PRIMARY KEY, patternModel VARCHAR(20), patternSizes VARCHAR(20), optionalInfo VARCHAR(20))";
                                    CreateTable(tableData, connection);
                                    break;
                                case "sewingFabrics": 
                                    tableData = $"CREATE TABLE {tableName} (id VARCHAR(20) PRIMARY KEY, mainType VARCHAR(20), subType VARCHAR(20), width REAL, height REAL)";
                                    CreateTable(tableData, connection);
                                    break;
                                case "sewingThreads": 
                                    tableData = $"CREATE TABLE {tableName} (id VARCHAR(20) PRIMARY KEY, colour VARCHAR(20), optionalInfo VARCHAR(20))";
                                    CreateTable(tableData, connection);
                                    break;
                                case "crochetHooks": 
                                    tableData = $"CREATE TABLE {tableName} (id VARCHAR(20) PRIMARY KEY, size REAL, material VARCHAR(20))";
                                    CreateTable(tableData, connection);
                                    break;
                                case "crochetThreads": 
                                    tableData = $"CREATE TABLE {tableName} (id VARCHAR(20) PRIMARY KEY, size REAL, material VARCHAR(20), colour VARCHAR(20))";
                                    CreateTable(tableData, connection);
                                    break;
                                case "misc": 
                                    tableData = $"CREATE TABLE {tableName} (id VARCHAR(20) PRIMARY KEY, name VARCHAR(20), optionalInfo VARCHAR(20))";
                                    CreateTable(tableData, connection);
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }

    //Creates a new table.
    private static void CreateTable (string tableData, SQLiteConnection connection)
    {
        using (SQLiteCommand cmd = new SQLiteCommand(tableData, connection))
        {
            cmd.ExecuteNonQuery();
        }
    }

    //Adds a new entry to a table.
    public static void AddTableEntry (string tableEntry)
    {
        using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db"))
        {
            connection.Open();

            using (SQLiteCommand cmd = new SQLiteCommand(tableEntry, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    //Gets table data and presents it according to the table columns.
    //Used when showing data from database.
    public static void GetTableData (string tableName, string query)
    {
        using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db"))
        {
            connection.Open();

            using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    //Print results from database.
                    while(reader.Read())
                    {
                        switch (tableName)
                        {
                            case "sewingPatterns":
                                Console.WriteLine($"Kaavan malli: {reader["patternModel"]} / Kaavan koot: {reader["patternSizes"]} / Lisätietoja: {reader["optionalInfo"]}");
                                Console.WriteLine("- - - - - -");
                                break;
                            case "sewingFabrics":
                                Console.WriteLine($"Kankaan luokka: {reader["mainType"]} / Alaluokka: {reader["subType"]} / Koko: Leveys {reader["width"]}cm - Korkeus {reader["height"]}cm");
                                Console.WriteLine("- - - - - -");
                                break;
                            case "sewingThreads":
                                Console.WriteLine($"Väri: {reader["colour"]} / Lisätietoja: {reader["optionalInfo"]}");
                                Console.WriteLine("- - - - - -");
                                break;
                            case "crochetHooks": 
                                Console.WriteLine($"Koko: {reader["size"]} / Materiaali: {reader["material"]}");
                                Console.WriteLine("- - - - - -");
                                break;
                            case "crochetThreads": 
                                Console.WriteLine($"Koko: {reader["size"]} / Materiaali: {reader["material"]} / Väri: {reader["colour"]}");
                                Console.WriteLine("- - - - - -");
                                break;
                            case "misc":
                                Console.WriteLine($"Nimi: {reader["name"]} / Lisätietoja: {reader["optionalInfo"]}");
                                Console.WriteLine("- - - - - -");
                                break;
                            default:
                            Console.WriteLine("Tietoja ei löytynyt.");
                                break;
                        }
                    }
                }
            }
        }
    }

    //Gets table data with ids and presents it according to the table columns.
    //Used when removing an entry from database.
    public static void GetTableDataWithId (string tableName)
    {
        using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db"))
        {
            connection.Open();

            string query = $"SELECT * FROM {tableName}";

            using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    //Print results from database.
                    while(reader.Read())
                    {
                        switch (tableName)
                        {
                            case "sewingPatterns":
                                Console.WriteLine($"Tunniste: {reader["id"]} / Kaavan malli: {reader["patternModel"]} / Kaavan koot: {reader["patternSizes"]} / Lisätietoja: {reader["optionalInfo"]}");
                                Console.WriteLine("- - - - - -");
                                break;
                            case "sewingFabrics":
                                Console.WriteLine($"Tunniste: {reader["id"]} / Kankaan luokka: {reader["mainType"]} / Alaluokka: {reader["subType"]} / Koko: Leveys {reader["width"]}cm - Korkeus {reader["height"]}cm");
                                Console.WriteLine("- - - - - -");
                                break;
                            case "sewingThreads":
                                Console.WriteLine($"Tunniste: {reader["id"]} / Väri: {reader["colour"]} / Lisätietoja: {reader["optionalInfo"]}");
                                Console.WriteLine("- - - - - -");
                                break;
                            case "crochetHooks": 
                                Console.WriteLine($"Tunniste: {reader["id"]} / Koko: {reader["size"]} / Materiaali: {reader["material"]}");
                                Console.WriteLine("- - - - - -");
                                break;
                            case "crochetThreads": 
                                Console.WriteLine($"Tunniste: {reader["id"]} / Koko: {reader["size"]} / Materiaali: {reader["material"]} / Väri: {reader["colour"]}");
                                Console.WriteLine("- - - - - -");
                                break;
                            case "misc":
                                Console.WriteLine($"Tunniste: {reader["id"]} / Nimi: {reader["name"]} / Lisätietoja: {reader["optionalInfo"]}");
                                Console.WriteLine("- - - - - -");
                                break;
                            default:
                            Console.WriteLine("Tietoja ei löytynyt.");
                                break;
                        }
                    }
                }
            }
        }
    }

    //Removes data from a given table based on the item id.
    public static void RemoveTableData(string tableName)
    {
        GetTableDataWithId(tableName);

        //Get item id.
        Console.WriteLine("Anna poistettavan tiedon tunniste (kirjasin koolla ei ole väliä): ");
        string id = Console.ReadLine();

        using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db"))
        {
            connection.Open();

            string query = $"DELETE FROM {tableName} WHERE id = '{id.ToUpper()}'";

            using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
            {
                cmd.ExecuteNonQuery();

                using (SQLiteCommand vacuum = new SQLiteCommand("VACUUM", connection))
                {
                    vacuum.ExecuteNonQuery();
                }
            }
        }
    }

    //Checks if existing item on a table has the same id as the one generated by the id generator in the CollectData.
    public static bool CheckForColumn (string generatedId, string tableName)
    {
        using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db"))
        {
            connection.Open();

            string query = $"SELECT 1 FROM {tableName} WHERE id='{generatedId}'";
   
            using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
            {
                using(SQLiteDataReader result = cmd.ExecuteReader())
                {
                    if(result.HasRows)
                    {
                        //Console.WriteLine("ID does exist");
                        return false;
                    }
                    else
                    {
                        //Console.WriteLine("ID doesn't exist.");
                        return true;
                    }
                }
            }
        }
    }
}