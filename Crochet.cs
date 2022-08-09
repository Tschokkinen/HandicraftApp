using System;
using System.Collections.Generic;

namespace HandicraftApp
{
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
                Console.WriteLine("1 - Virkkuukoukut");
                Console.WriteLine("2 - Virkkuulangat");
                Console.WriteLine("X - Palaa päävalikkoon");

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
                Console.WriteLine("Virkkuukoukut");
                Console.WriteLine("1 - Näytä virkkuukoukut");
                Console.WriteLine("2 - Lisää virkkuukoukku");
                Console.WriteLine("3 - Poista tieto");
                Console.WriteLine("X - Palaa virkkuun päävalikkoon");

                string selection = Console.ReadLine();

                if(selection == "1")
                {
                    tableName = "crochetHooks";
                    query = $"SELECT * FROM {tableName} ORDER BY size DESC";
                    Database.GetTableData(tableName, query);
                    continue;
                }
                else if(selection == "2")
                {
                    Console.WriteLine();
                    CrochetHook crochetHook = new CrochetHook();
                    continue;
                }
                else if(selection == "3")
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
                Console.WriteLine("Virkkuulangat");
                Console.WriteLine("1 - Näytä virkkuulangat");
                Console.WriteLine("2 - Lisää virkkuulanka");
                Console.WriteLine("3 - Poista tieto");
                Console.WriteLine("X - Palaa virkkuun päävalikkoon");

                string selection = Console.ReadLine();

                if(selection == "1")
                {
                    tableName = "crochetThreads";
                    query = $"SELECT * FROM {tableName} ORDER BY size DESC";
                    Database.GetTableData(tableName, query);
                    continue;
                }
                else if(selection == "2")
                {
                    Console.WriteLine();
                    Thread thread = new Thread();
                    continue;
                }
                else if(selection == "3")
                {
                    Database.RemoveTableData("crochetThread");
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
