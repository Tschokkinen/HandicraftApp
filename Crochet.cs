using System;
using System.Collections.Generic;

namespace HandicraftApp
{
    public class Crochet
    {
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

        private static void GetCrochetData(string tableName)
        {
            string query = $"SELECT * FROM {tableName} ORDER BY size DESC";
            Database.GetTableData(tableName, query);
        }

        private static void AddCrochetHook ()
        {
            //Get id.
            string id = CollectData.GenerateRandomId("crochetHooks");
            //Get size.
            int size = CollectData.AskForInt("Virkkuukoukun koko: ");
            //Get material.
            string material = CollectData.AskForString("Virkkuukoukun materiaali: ");

            CrochetHook current = new CrochetHook(size, material);

            string tableEntry = $"INSERT INTO crochetHooks (id, size, material) values ('{id}', {current.Size}, '{current.Material}')";
            Database.AddTableEntry(tableEntry);
        }

        private static void AddCrochetThread ()
        {
            //Get id.
            string id = CollectData.GenerateRandomId("crochetThreads");
            //Get size.
            int size = CollectData.AskForInt("Virkkuulangan koko: ");
            //Get material
            string material = CollectData.AskForString("Virkkuulangan materiaali: ");
            //Get colour. 
            string colour = CollectData.AskForString("Virkkuulangan väri: ");
            
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
                Console.WriteLine("2 - Poista virkkuulanka");
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
