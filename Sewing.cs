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
                Console.WriteLine("Ompelu");
                Console.WriteLine("1 - Lankasävyt");
                Console.WriteLine("2 - Kaavat");
                Console.WriteLine("3 - Kankaat");
                Console.WriteLine("X - Palaa päävalikkoon");

                string selection = Console.ReadLine();

                if(selection == "1")
                {
                    Console.WriteLine();
                    continue;
                }
                else if(selection == "2")
                {
                    Console.WriteLine();
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

                string selection = Console.ReadLine();

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

                string selection = Console.ReadLine();

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
                Console.WriteLine("2 - Puuvilla");
                Console.WriteLine("3 - Lisää uusi");
                Console.WriteLine("4 - Poista tieto");
                Console.WriteLine("X - Palaa takaisin");

                string selection = Console.ReadLine();

                if(selection == "1")
                {
                    Console.WriteLine();
                    SewingFabricsSubSelect("Trikoo");
                    Console.WriteLine();
                    continue;
                }
                else if(selection == "2")
                {
                    Console.WriteLine();
                    SewingFabricsSubSelect("Puuvilla");
                    Console.WriteLine();
                    continue;
                }
                else if(selection == "3")
                {
                    Console.WriteLine("Lisää kangas: ");
                    SewingFabric sewingFabric = new SewingFabric();
                    Console.WriteLine();
                }
                else if(selection == "4")
                {
                    Console.WriteLine();
                    Database.RemoveTableData("sewingFabrics");
                    Console.WriteLine();
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
                Console.WriteLine($"Alaluokat: {mainType}");
                Console.WriteLine("1 - Yksiväriset");
                Console.WriteLine("2 - Kuvioidut");
                Console.WriteLine("X - Palaa takaisin");

                string selection = Console.ReadLine();

                if(selection == "1")
                {
                    subType = "Yksivärinen";
                    GetSewingFabricData(mainType, subType);
                    continue;
                }
                else if(selection == "2")
                {
                    subType = "Kuvioitu";
                    GetSewingFabricData(mainType, subType);
                }
                else if(selection.ToLower() == "x")
                {
                    Console.WriteLine("Valintaa ei tunnistettu.");
                    break;
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