using System;
using System.Collections.Generic;

namespace HandicraftApp
{
    //Contains all menu selections for crochet.
    public class Crochet
    {
        private static string query;
        private static string tableName;

        public static void CrochetSelection ()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Virkkaus");
                Console.WriteLine(MenuCommands.SelectCrochetHooks);
                Console.WriteLine(MenuCommands.SelectCrochetThreads);
                Console.WriteLine(MenuCommands.BackToMainMenu);

                string selection = Console.ReadLine();

                if (selection == "1")
                {
                    CrochetHooks();
                    continue;
                }
                else if (selection == "2")
                {
                    CrochetThreads();
                    continue;
                }
                else if (selection.ToLower() == "x")
                {
                    Console.WriteLine();
                    break;
                }
            }
        } 

        private static void CrochetHooks()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(MenuCommands.CrochetHooksTitle);
                Console.WriteLine(MenuCommands.ShowEntries);
                Console.WriteLine(MenuCommands.AddEntry);
                Console.WriteLine(MenuCommands.DeleteEntry);
                Console.WriteLine(MenuCommands.BackToPrevious);

                string selection = Console.ReadLine();

                if(selection.ToLower() == "s")
                {
                    tableName = "crochetHooks";
                    query = $"SELECT * FROM {tableName} ORDER BY size DESC";
                    Database.GetTableData(tableName, query);
                    continue;
                }
                else if(selection.ToLower() == "a")
                {
                    Console.WriteLine();
                    CrochetHook crochetHook = new CrochetHook();
                    continue;
                }
                else if(selection.ToLower() == "d")
                {
                    Database.RemoveTableData("crochetHooks");
                    continue;
                }
                else if(selection.ToLower() == "x")
                {
                    break;
                }
            }
        }

        private static void CrochetThreads()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(MenuCommands.CrochetThreadsTitle);
                Console.WriteLine(MenuCommands.ShowEntries);
                Console.WriteLine(MenuCommands.AddEntry);
                Console.WriteLine(MenuCommands.DeleteEntry);
                Console.WriteLine(MenuCommands.BackToPrevious);

                string selection = Console.ReadLine();

                if(selection.ToLower() == "s")
                {
                    Console.WriteLine();
                    tableName = "crochetThreads";
                    query = $"SELECT * FROM {tableName} ORDER BY size DESC";
                    Database.GetTableData(tableName, query);
                    continue;
                }
                else if(selection.ToLower() == "a")
                {
                    Console.WriteLine();
                    CrochetThread crochetThread = new CrochetThread();
                    continue;
                }
                else if(selection.ToLower() == "d")
                {
                    Database.RemoveTableData("crochetThreads");
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
