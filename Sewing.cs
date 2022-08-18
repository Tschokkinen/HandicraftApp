using System;

namespace HandicraftApp
{
    //Contains all menu selections for sewing.
    public class Sewing
    {
        public static void SewingSelection()
        {
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine(MenuCommands.SewingTitle);
                Console.WriteLine(MenuCommands.SelectSewingThreads);
                Console.WriteLine(MenuCommands.SelectSewingPatterns);
                Console.WriteLine(MenuCommands.SelectSewingFabrics);
                Console.WriteLine(MenuCommands.BackToMainMenu);

                string selection = Console.ReadLine();

                if(selection == "1")
                {
                    SewingThreads();
                    continue;
                }
                else if(selection == "2")
                {
                    SewingPatterns();
                    continue;
                }
                else if(selection == "3")
                {
                    SewingFabrics();
                    continue;
                }
                else if(selection.ToLower() == "x") //Back to main
                {
                    break;
                }
            }
        }

        private static void SewingThreads()
        {
            string tableName = "sewingThreads";

            while(true)
            {
                Console.WriteLine();
                Console.WriteLine(MenuCommands.SewingThreadsTitle);
                Console.WriteLine(MenuCommands.ShowEntries);
                Console.WriteLine(MenuCommands.AddEntry);
                Console.WriteLine(MenuCommands.DeleteEntry);
                Console.WriteLine(MenuCommands.BackToPrevious);

                string selection = Console.ReadLine();

                if(selection.ToLower() == "s") //Show entries
                {
                    Console.WriteLine();
                    
                    string query = $"SELECT * FROM {tableName} ORDER BY colour DESC";
                    Database.GetTableData(tableName, query);
                    continue;
                }
                else if(selection.ToLower() == "a") //Add entry
                {
                    Console.WriteLine();
                    SewingThread sewingThread = new SewingThread();
                    continue;
                }
                else if(selection.ToLower() == "d") //Delete entry
                {
                    Database.RemoveTableData(tableName);
                }
                else if(selection.ToLower() == "x")
                {
                    break;
                }
            }
        }

        private static void SewingPatterns()
        {
            string tableName = "sewingPatterns";

            while(true)
            {
                Console.WriteLine();
                Console.WriteLine(MenuCommands.SewingPatternsTitle);
                Console.WriteLine(MenuCommands.ShowEntries);
                Console.WriteLine(MenuCommands.AddEntry);
                Console.WriteLine(MenuCommands.DeleteEntry);
                Console.WriteLine(MenuCommands.BackToPrevious);

                string selection = Console.ReadLine();

                if(selection.ToLower() == "s") //Show entries
                {
                    Console.WriteLine();
                    string query = $"SELECT * FROM {tableName} ORDER BY patternModel DESC";
                    Database.GetTableData(tableName, query);
                    Console.WriteLine();
                    continue;
                }
                else if(selection.ToLower() == "a") //Add entry
                {
                    Console.WriteLine();
                    SewingPattern sewingPattern = new SewingPattern();
                    Console.WriteLine();
                    continue;
                }
                else if(selection.ToLower() == "d") //Delete entry
                {
                    Console.WriteLine();
                    Database.RemoveTableData(tableName);
                }
                else if(selection.ToLower() == "x") //Back to previous
                {
                    break;
                }
            }
        }

        private static void SewingFabrics()
        {
            string tableName = "sewingFabrics";

            while(true)
            {
                Console.WriteLine();
                Console.WriteLine(MenuCommands.SewingFabricsTitle);
                Console.WriteLine(MenuCommands.ShowEntries);
                Console.WriteLine(MenuCommands.AddEntry);
                Console.WriteLine(MenuCommands.DeleteEntry);
                Console.WriteLine(MenuCommands.BackToPrevious);

                string selection = Console.ReadLine();

                if(selection.ToLower() == "s") //Leotard
                {
                    SewingFabricsSelect();
                    continue;
                }
                else if(selection.ToLower() == "a") //Add entry
                {
                    Console.WriteLine("Lisää kangas: ");
                    SewingFabric sewingFabric = new SewingFabric();
                    Console.WriteLine();
                }
                else if(selection.ToLower() == "d") //Delete entry
                {
                    Console.WriteLine();
                    Database.RemoveTableData(tableName);
                    Console.WriteLine();
                }
                else if(selection.ToLower() == "x") //Back to previous
                {
                    break;
                }
            }
        }

        private static void SewingFabricsSelect()
        {
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine(MenuCommands.SelectSewingFabricTitle);
                Console.WriteLine(MenuCommands.SelectSewingFabricLeotard);
                Console.WriteLine(MenuCommands.SelectSewingFabricCotton);
                Console.WriteLine(MenuCommands.BackToPrevious);

                string selection = Console.ReadLine();

                if(selection == "1") //Leotard
                {
                    SewingFabricsSubSelect("Trikoo");
                    continue;
                }
                else if(selection == "2") //Cotton
                {
                    SewingFabricsSubSelect("Puuvilla");
                    continue;
                }
                else if(selection.ToLower() == "x")
                {
                    break;
                }
            }
        }

        private static void SewingFabricsSubSelect(string mainType)
        {
            string subType;

            while(true)
            {
                Console.WriteLine();
                Console.WriteLine(MenuCommands.SelectSewingFabricSubTitle);
                Console.WriteLine("1 - Yksiväriset");
                Console.WriteLine("2 - Kuvioidut");
                Console.WriteLine(MenuCommands.BackToPrevious);

                string selection = Console.ReadLine();

                if(selection == "1")
                {
                    subType = "Yksivärinen";
                    Console.WriteLine();
                    GetSewingFabricData(mainType, subType);
                    continue;
                }
                else if(selection == "2")
                {
                    subType = "Kuvioitu";
                    Console.WriteLine();
                    GetSewingFabricData(mainType, subType);
                }
                else if(selection.ToLower() == "x")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Valintaa ei tunnistettu.");
                    continue;
                }
            }
        }

        private static void GetSewingFabricData(string mainType, string subType)
        {
            string tableName = "sewingFabrics";
            string query = $"SELECT * FROM {tableName} WHERE mainType = '{mainType}' AND subType = '{subType}' ORDER BY subType DESC";
            Database.GetTableData(tableName, query);
        }
    }
}