using System;
using System.Data.SQLite;
using System.Collections.Generic;

public class Database
{
    //Checks database for tables and creates them if neccessary.
    public static void CreateDatabase ()
    {
        //Table list.
        var tableNames = new List<string>();
        tableNames.Add("crochetHooks");
        tableNames.Add("crochetThreads");
        tableNames.Add("misc");
        tableNames.Add("sewingFabrics");

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
                                case "sewingFabrics": 
                                    tableData = $"CREATE TABLE {tableName} (id VARCHAR(20) PRIMARY KEY, mainType VARCHAR(20), subType VARCHAR(20), width REAL, height REAL)";
                                    CreateTable(tableData, connection);
                                    break;
                                case "crochetHooks": 
                                    tableData = $"CREATE TABLE {tableName} (id VARCHAR(20) PRIMARY KEY, size INT, material VARCHAR(20))";
                                    CreateTable(tableData, connection);
                                    break;
                                case "crochetThreads": 
                                    tableData = $"CREATE TABLE {tableName} (id VARCHAR(20) PRIMARY KEY, size INT, material VARCHAR(20), colour VARCHAR(20))";
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

    private static void CreateTable (string tableData, SQLiteConnection connection)
    {
        using (SQLiteCommand cmd = new SQLiteCommand(tableData, connection))
        {
            cmd.ExecuteNonQuery();
        }
    }

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
                            case "sewingFabrics":
                                Console.WriteLine($"Tunniste: {reader["id"]} / Kankaan luokka: {reader["mainType"]} / Alaluokka: {reader["subType"]} / Koko: {reader["width"]}cm {reader["height"]}cm");
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

    public static void RemoveTableData(string tableName, string id)
    {
        using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db"))
        {
            connection.Open();

            string query = $"DELETE FROM {tableName} WHERE id = '{id}'";

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