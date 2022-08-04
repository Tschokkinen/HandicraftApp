using System;
using System.Data.SQLite;
using System.Collections.Generic;

namespace HandicraftApp
{
    public class Crochet
    {
        private static Dictionary<string, string> queryDict = new Dictionary<string, string>();

        public static void InitializeDict()
        {
            queryDict.Add("crochetHooks", "SELECT * FROM crochetHooks ORDER BY SIZE DESC");
            queryDict.Add("crochetThreads", "SELECT * FROM crochetThreads ORDER BY SIZE DESC");
        }

        public static void CrochetSelection ()
        {
            while (true)
            {
                Console.WriteLine("Virkkaus");
                Console.WriteLine("1 - Näytä virkkuukoukut");
                Console.WriteLine("2 - Näytä virkkuulangat");
                Console.WriteLine("3 - Lisää virkkuukoukku");
                Console.WriteLine("4 - Lisää virkkuulanka");
                Console.WriteLine("5 - Poista tieto");
                Console.WriteLine("X - Palaa päävalikkoon");

                string selection = Console.ReadLine();

                if (selection == "1")
                {
                    Console.WriteLine("\nVirkkuukoukut:");
                    GetCrochetData("crochetHooks");
                    Console.WriteLine();
                    continue;
                }
                else if (selection == "2")
                {
                    Console.WriteLine("\nVirkkuulangat:");
                    GetCrochetData("crochetThreads");
                    Console.WriteLine();
                    continue;
                }
                else if (selection == "3")
                {
                    Console.WriteLine();
                    AddCrochetHook();
                    Console.WriteLine();
                    continue;
                }
                else if (selection == "4")
                {
                    Console.WriteLine();
                    AddCrochetThread();
                    Console.WriteLine();
                    continue;
                }
                else if (selection == "5")
                {
                    Console.WriteLine();
                    DeleteEntry();
                    Console.WriteLine();
                    continue;
                }
                else if (selection.ToLower() == "x")
                {
                    break;
                }
            }
            Console.WriteLine();
        } 

        private static void GetCrochetData(string selection)
        {
            if(queryDict.ContainsKey(selection))
            {
                string query = queryDict[selection];
                string tableName = selection;
                Database.GetTableData(query, tableName);
            }
        }

        private static void AddCrochetHook ()
        {
            //Get id.
            string id = CollectData.GenerateRandomId();
            //Get size.
            int size = CollectData.AskForSize("Virkkuukoukun koko: ");
            //Get material.
            string material = CollectData.AskForMaterial("Virkkuukoukun materiaali: ");

            CrochetHook current = new CrochetHook(size, material);

            string tableEntry = $"INSERT INTO crochetHooks (id, size, material) values ('{id}', {current.Size}, '{current.Material}')";
            Database.AddTableEntry(tableEntry);
        }

        private static void AddCrochetThread ()
        {
            //Get id.
            string id = CollectData.GenerateRandomId();
            //Get size.
            int size = CollectData.AskForSize("Virkkuulangan koko: ");
            //Get material
            string material = CollectData.AskForMaterial("Virkkuulangan materiaali: ");
            //Get colour. 
            string colour = CollectData.AskForColour("Virkkuulangan väri: ");
            
            Thread current = new Thread(size, material, colour);

            string tableEntry = $"INSERT INTO crochetThreads (id, size, material, colour) values ('{id}', {current.Size}, '{current.Material}', '{current.Colour}')";
            Database.AddTableEntry(tableEntry);
        }

        private static void DeleteEntry()
        {
            string tableName;
            string id;

            //Get table name.
            while (true)
            {
                Console.WriteLine("Minkä tiedon haluat poistaa: ");
                Console.WriteLine("1 - Poista virkkuukoukku");
                Console.WriteLine("2 - POista virkkuulanka");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    tableName = "crochetHooks";
                    break;
                }
                else if (input == "2")
                {
                    tableName = "crochetThreads";
                    break;
                }
            }

            //Get item id.
            Console.WriteLine("Anna poistettavan tiedon tunniste: ");
            id = Console.ReadLine();

            Database.RemoveTableData(tableName, id);
        }        
    }
}
