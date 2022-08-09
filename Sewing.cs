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
            while(true)
            {
                Console.WriteLine("Langat:");
                Console.WriteLine("X - Palaa takaisin");

                string selection = Console.WriteLine();

                if(selection.ToLower() == "x")
                {
                    break;
                }
            }
        }

        private static void Patterns()
        {
            while(true)
            {
                Console.WriteLine("Kaavat:");
                Console.WriteLine("X - Palaa takaisin");

                string selection = Console.WriteLine();

                if(selection.ToLower() == "x")
                {
                    break;
                }
            }
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
                else if(selection == "2")
                {
                    Console.WriteLine("Kuvioidut");
                    SewingFabricsSubSelect("Kuvioitu");
                }
                else if(selection == "3")
                {
                    Console.WriteLine("Yksiväriset");
                    SewingFabricsSubSelect("Yksiväriset");
                }
                else if(selection == "4")
                {
                    Console.WriteLine("Puuvilla");
                    SewingFabricsSubSelect("Puuvilla");
                }
                else if(selection == "5")
                {
                    Console.WriteLine("Lisää kangas: ");
                    SewingFabric sewingFabric = new SewingFabric();
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
                case "Kuvioitu":
                    Console.WriteLine("Kuvioidut kankaat: ");
                    GetSewingFabricData(subCat);
                    break;
                case "Yksiväriset":
                    Console.WriteLine("Yksiväriset kankaat: ");
                    GetSewingFabricData(subCat);
                    break;
                case "Puuvilla":
                    Console.WriteLine("Puuvilla kankaat: ");
                    GetSewingFabricData(subCat);
                    break;
                default:
                    Console.WriteLine("Valintaa ei tunnistettu.");
                    break;
            }
        }

        private static void GetSewingFabricData(string mainType)
        {
            string tableName = "sewingFabrics";
            string query = $"SELECT * FROM {tableName} WHERE mainType = '{mainType}' ORDER BY subType DESC";
            Database.GetTableData(tableName, query);
        }
    }
}