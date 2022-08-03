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
                                    string tableData = $"CREATE TABLE {tableName} (size INT, material VARCHAR(20))";
                                    CreateTable(tableData, connection);
                                    break;
                                case "crochetThreads": //Cases for INT, VARCHAR, VARCHAR tables.
                                    tableData = $"CREATE TABLE {tableName} (size INT, material VARCHAR(20), colour VARCHAR(20))";
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
                                Console.WriteLine($"Koko: {reader["size"]}\t Materiaali: {reader["material"]}");
                                break;
                            case "crochetThreads": //Cases for INT, VARCHAR, VARCHAR tables.
                                Console.WriteLine($"Koko: {reader["size"]}\t Materiaali: {reader["material"]}\t Väri: {reader["colour"]}");
                                break;
                        }
                    }
                }
            }
        }
    }
}