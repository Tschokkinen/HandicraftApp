using System;
using System.Collections.Generic;

namespace HandicraftApp
{
    public class Misc
    {
        private static string query;
        private static string tableName = "misc";

        public static void MiscSelection()
        {
            while(true)
            {
                Console.WriteLine(MenuCommands.MiscTitle);
                Console.WriteLine(MenuCommands.ShowEntries);
                Console.WriteLine(MenuCommands.AddEntry);
                Console.WriteLine(MenuCommands.DeleteEntry);
                Console.WriteLine(MenuCommands.BackToMainMenu);

                string selection = Console.ReadLine();

                if(selection.ToLower() == "s")
                {
                    Console.WriteLine();
                    query = $"SELECT * FROM {tableName} ORDER BY name DESC";
                    Database.GetTableData(tableName, query);
                    Console.WriteLine();
                    continue;
                }
                else if(selection.ToLower() == "a")
                {
                    Console.WriteLine();
                    MiscItem miscItem = new MiscItem();
                    Console.WriteLine();
                    continue;
                }
                else if(selection.ToLower() == "d")
                {
                    Console.WriteLine();
                    Database.RemoveTableData(tableName);
                    Console.WriteLine();
                    continue;
                }
                else if(selection.ToLower() == "x")
                {
                    break;
                }
            }
        }
    }
}
