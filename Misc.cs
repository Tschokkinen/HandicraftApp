using System;
using System.Collections.Generic;

namespace HandicraftApp
{
    public class Misc
    {
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
                    GetMiscData("misc");
                    Console.WriteLine();
                    continue;
                }
                else if(selection == "2")
                {
                    Console.WriteLine();
                    AddMiscItem();
                    Console.WriteLine();
                    continue;
                }
                else if(selection == "3")
                {
                    Console.WriteLine();
                    DeleteEntry();
                    Console.WriteLine();
                    continue;
                }
                else if(selection.ToLower() == "x")
                {
                    break;
                }
            }
        }

        private static void GetMiscData(string tableName)
        {
            string query = $"SELECT * FROM {tableName} ORDER BY name DESC";
            Database.GetTableData(tableName, query);
        }

        private static void AddMiscItem()
        {
            //Get id.
            string id = CollectData.GenerateRandomId("misc");
            //Get item name.
            string itemName = CollectData.AskForString("Esineen nimi: ");
            //Get optional info.
            string optionalInfo = CollectData.AskForString("Lisätietoja (paina enter jättääksesi kenttä tyhjäksi): ");

            MiscItem current = new MiscItem(itemName, optionalInfo);

            string tableEntry = $"INSERT INTO misc (id, name, optionalInfo) values ('{id}', '{current.ItemName}', '{current.OptionalInfo}')";
            Database.AddTableEntry(tableEntry);
        }

        private static void DeleteEntry()
        {
            string tableName = "misc";
            string id;

            //Get item id.
            Console.WriteLine("Anna poistettavan tiedon tunniste: ");
            id = Console.ReadLine();

            Database.RemoveTableData(tableName, id);
        } 
    }

    
}
