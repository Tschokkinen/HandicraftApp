using System;

namespace HandicraftApp
{
    public class Sewing
    {
        public static void SewingSelection()
        {
            while(true)
            {
                Console.WriteLine("Ompelu");
                Console.WriteLine("1 - Lankasävyt");
                Console.WriteLine("2 - Kaavat");
                Console.WriteLine("3 - Kankaat");
                Console.WriteLine("X - Palaa päävalikkoon");

                string selection = Console.ReadLine();

                if(selection == "1")
                {
                    continue;
                }
                else if(selection == "2")
                {
                    continue;
                }
                else if(selection == "3")
                {
                    SewingFabrics();
                    continue;
                }
                else if(selection.ToLower() == "x")
                {
                    break;
                }
            }
        }

        private static void Threads()
        {

        }

        private static void SewingFabrics()
        {
            while(true)
            {
                Console.WriteLine("Kankaat:");
                Console.WriteLine("1 - Trikoo");
                Console.WriteLine("2 - Kuvioidut");
                Console.WriteLine("3 - Yksiväriset");
                Console.WriteLine("4 - Puuvilla");
                Console.WriteLine("5 - Lisää kangas");
                Console.WriteLine("X - Palaa takaisin");

                string selection = Console.ReadLine();

                if(selection == "1")
                {
                    Console.WriteLine("Trikoo");
                    SewingFabricsSubSelect("Trikoo");
                    continue;
                }
                else if(selection == "5")
                {
                    Console.WriteLine("Lisää kangas: ");
                    AddSewingFabric();
                }
                else if(selection.ToLower() == "x")
                {
                    break;
                }
            }

        }

        private static void SewingFabricsSubSelect(string subCat)
        {
            switch(subCat)
            {
                case "Trikoo":
                    Console.WriteLine("Trikoo kankaat: ");
                    GetSewingFabricData(subCat);
                    break;
                default:
                    break;
            }
        }

        private static void GetSewingFabricData(string mainType)
        {
            string tableName = "sewingFabrics";
            string query = $"SELECT * FROM {tableName} WHERE mainType = '{mainType}' ORDER BY subType DESC";
            Database.GetTableData(tableName, query);
        }

        private static void AddSewingFabric()
        {
            //Get id.
            string id = CollectData.GenerateRandomId("sewingFabrics");
            //Get fabric main type.
            Console.WriteLine("Valitse kankaan luokka: ");
            string mainType = CollectData.AskForFabricMainType();
            //Get fabric subtype.
            string subType = CollectData.AskForString("Materiaalin alaluokka: ");
            //Get fabric size.
            Console.WriteLine("Kangas palan koko: ");
            double width = CollectData.AskForDouble("Leveys (cm): ");
            double height = CollectData.AskForDouble("Korkeus (cm): ");

            SewingFabric current = new SewingFabric(mainType, subType, width, height);

            string tableEntry = $"INSERT INTO sewingFabrics (id, mainType, subType, width, height) values ('{id}', '{current.MainType}', '{current.SubType}', {current.Width}, {current.Height})";
            Database.AddTableEntry(tableEntry);
        }
    }
}