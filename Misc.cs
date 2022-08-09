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
                Console.WriteLine("Sekalaiset");
                Console.WriteLine("1 - Näytä sekalaiset");
                Console.WriteLine("2 - Lisää uusi");
                Console.WriteLine("3 - Poista tieto");
                Console.WriteLine("X - Palaa päävalikkoon");

                string selection = Console.ReadLine();

                if(selection == "1")
                {
                    Console.WriteLine();
                    query = $"SELECT * FROM {tableName} ORDER BY name DESC";;
                    Database.GetTableData(tableName, query);
                    Console.WriteLine();
                    continue;
                }
                else if(selection == "2")
                {
                    Console.WriteLine();
                    MiscItem miscItem = new MiscItem();
                    Console.WriteLine();
                    continue;
                }
                else if(selection == "3")
                {
                    Console.WriteLine();
                    Database.RemoveTableData("misc");
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
