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
                Console.WriteLine("X - Palaa päävalikkoon");

                string selection = Console.ReadLine();

                if (selection == "1")
                {
                    Console.WriteLine();
                    GetCrochetData("crochetHooks");
                    Console.WriteLine();
                    continue;
                }
                else if (selection == "2")
                {
                    Console.WriteLine();
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
            int size; //Size of the hook.
            string material; //Hook material.

            //Get crochet hook size and material from user.
            while (true)
            {
                Console.WriteLine("Virkkuukoukun koko: ");
                string sizeStr = Console.ReadLine();
                bool isNumber = int.TryParse(sizeStr, out size);

                if (isNumber) //Check if user entered a number.
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nAnna numeraali.\n");
                }
            }

            Console.WriteLine("\nVirkkuukoukun materiaali: ");
            material = Console.ReadLine();

            CrochetHook current = new CrochetHook(size, material);

            string tableEntry = $"INSERT INTO crochetHooks (size, material) values ({current.Size}, '{current.Material}')";
            Database.AddTableEntry(tableEntry);
        }

        private static void AddCrochetThread ()
        {
            int size;
            string material;
            string colour;

            //Get crochet thread size and material and colour from user.
            while (true)
            {
                Console.WriteLine("Virkkuulangan koko: ");
                string sizeStr = Console.ReadLine();
                bool isNumber = int.TryParse(sizeStr, out size);

                if (isNumber) //Check if user entered a number.
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nAnna numeraali.\n");
                }
            }
            
            Console.WriteLine("Virkkuulangan materiaali: ");
            material = Console.ReadLine();
            Console.WriteLine("Virkkuulangan väri: ");
            colour = Console.ReadLine();
            
            Thread current = new Thread(size, material, colour);

            string tableEntry = $"INSERT INTO crochetThreads (size, material, colour) values ({current.Size}, '{current.Material}', '{current.Colour}')";
            Database.AddTableEntry(tableEntry);
        }        
    }
}
