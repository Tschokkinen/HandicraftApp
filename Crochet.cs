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
                    GetCrochetData("crochetHooks");
                    continue;
                }
                else if (selection == "2")
                {
                    GetCrochetData("crochetThreads");
                    continue;
                }
                else if (selection == "3")
                {
                    AddCrochetHook();
                    continue;
                }
                else if (selection == "4")
                {
                    AddCrochetThread();
                    continue;
                }
                else if (selection.ToLower() == "x")
                {
                    break;
                }
            }
            Console.WriteLine("\n");
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
            //Get crochet hook size and material from user.
            Console.WriteLine("Virkkuukoukun koko: ");
            string size = Console.ReadLine();
            Console.WriteLine("Virkkuukoukun materiaali: ");
            string material = Console.ReadLine();
            
            CrochetHook current = new CrochetHook(Int16.Parse(size), material);

            string tableEntry = $"INSERT INTO crochetHooks (size, material) values ({current.Size}, '{current.Material}')";
            Database.AddTableEntry(tableEntry);
        }

        private static void AddCrochetThread ()
        {
            //Get crochet thread size and material and colour from user.
            Console.WriteLine("Virkkuulangan koko: ");
            string size = Console.ReadLine();
            Console.WriteLine("Virkkuulangan materiaali: ");
            string material = Console.ReadLine();
            Console.WriteLine("Virkkuulangan väri: ");
            string colour = Console.ReadLine();
            
            Thread current = new Thread(Int16.Parse(size), material, colour);

            string tableEntry = $"INSERT INTO crochetThreads (size, material, colour) values ({current.Size}, '{current.Material}', '{current.Colour}')";
            Database.AddTableEntry(tableEntry);
        }        
    }
}
