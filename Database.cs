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

        using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db"))
        {
            connection.Open(); //Open database connection.

            foreach (string tableName in tableNames)
            {
                string query = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader result = cmd.ExecuteReader())
                    {
                        //If result is empty create corresponding table.
                        if (!result.HasRows)
                        {
                            switch (tableName)
                            {
                                case "crochetHooks": //Cases for INT, VARCHAR tables.
                                    string tableData = $"CREATE TABLE {tableName} (id VARCHAR(20) PRIMARY KEY, size INT, material VARCHAR(20))";
                                    CreateTable(tableData, connection);
                                    break;
                                case "crochetThreads": //Cases for INT, VARCHAR, VARCHAR tables.
                                    tableData = $"CREATE TABLE {tableName} (id VARCHAR(20) PRIMARY KEY, size INT, material VARCHAR(20), colour VARCHAR(20))";
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

    public static void GetTableData (string query, string tableName)
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
                            case "crochetHooks": //Cases for INT, VARCHAR tables.
                                Console.WriteLine($"Tunniste: {reader["id"]} / Koko: {reader["size"]} / Materiaali: {reader["material"]}");
                                Console.WriteLine("- - - - - -");
                                break;
                            case "crochetThreads": //Cases for INT, VARCHAR, VARCHAR tables.
                                Console.WriteLine($"Tunniste: {reader["id"]} / Koko: {reader["size"]} / Materiaali: {reader["material"]} / Väri: {reader["colour"]}");
                                Console.WriteLine("- - - - - -");
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


/*
    public static bool CheckForColumn (string newId)
    {
        using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db"))
        {
            connection.Open();

            string query = $"SELECT {newId} FROM sqlite_master WHERE type='column'";

            using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader result = cmd.ExecuteReader())
                {
                    if (result.HasRows)
                    {
                        Console.WriteLine("Has ROws");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Doesn't have rows.");
                        return false;
                    }
                }
            }
        }
    }
    */
}