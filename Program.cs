using System;
using System.Data.SQLite;

namespace HandicraftApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true; //Keeps the program running.
            Database.CreateDatabase(); //Check database and create tables if neccessary.
           
            Console.WriteLine("Tervetuloa käyttämään 'Käsityöhässäkkä-sovellusta'\n");

            do
            {
                //Select action.
                Console.WriteLine("Valitse toiminto: ");
                Console.WriteLine("1 - Virkkaus"); //Crochet materials
                Console.WriteLine("2 - Ompelu"); //Sewing materials
                Console.WriteLine("3 - Sekalaiset"); //Miscellaneous materials (scissors etc.)
                Console.WriteLine("X - Lopeta sovellus"); //Quit program

                string input = Console.ReadLine();

                if (input.ToLower() == "x")
                {
                    Console.WriteLine("Sovellus lopetetaan.\n");
                    keepRunning = false;
                }
                else if (input == "1")
                {
                    Crochet.CrochetSelection();
                }
                else if (input == "2")
                {
                    Sewing.SewingSelection();
                }
                else if (input == "3")
                {
                    Misc.MiscSelection();
                }
                else
                {
                    continue;
                }
            } while (keepRunning);

        }
    }
}