using System;

namespace HandicraftApp
{
    //Class containing collection of functions related to data collection
    //from user when new items are entered into the database.
    public class CollectData
    {
        //Used to get an int from user and to check if given value is int.
        public static int AskForInt (string question)
        {
            int value; 

            while (true)
            {
                Console.WriteLine(question);
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out value);

                if (isNumber) //Check if user entered a number.
               {
                    return value;
                }
                else
                {
                    Console.WriteLine("\nAnna numeraali.\n");
                }
            }
        }

        //Used to get a double from user and to check if given value is double.
        public static double AskForDouble (string question)
        {
            double value; 

            while (true)
            {
                Console.WriteLine(question);
                string input = Console.ReadLine();
                bool isNumber = double.TryParse(input, out value);

                if (isNumber) //Check if user entered a number.
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("\nAnna numeraali.\n");
                }
            }
        }

        //Used to get a string from user and to assign a default value if input is empty.
        public static string AskForString (string question)
        {
            //Display proper question and format input
            Console.WriteLine(question);
            string input = Console.ReadLine();

            if(string.IsNullOrEmpty(input))
            {
                return "-";
            }
            else
            {
                //Conver first letter of input to upper case.
                return char.ToUpper(input[0]) + input.Substring(1).ToLower();
            }
        }   

        //Used to get fabric main type when adding new fabrics to database.
        public static string AskForFabricMainType(string question)
        {
            Console.WriteLine(question);
        
            while(true)
            {
                Console.WriteLine("1 - Trikoo");
                Console.WriteLine("2 - Kuvioitu");
                Console.WriteLine("3 - Yksivärinen");
                Console.WriteLine("4 - Puuvilla");
                string input = Console.ReadLine();

                if(input == "1")
                {
                    return "Trikoo";
                }
                else if(input == "2")
                {
                    return "Kuvioitu";
                }
                else if(input == "3")
                {
                    return "Yksivärinen";
                }
                else if(input == "4")
                   {
                    return "Puuvilla";
                }
            }
        }

        //Generates a random id for database items. Id is used for deleting items from database.
        public static string GenerateRandomId(string tableName)
        {
            string generatedId;

            while (true)
            {
                //Random used to generate ids of different length
                Random rand = new Random();
  
                //Id character length. Curently fixed to four characters.
                int stringLen = rand.Next(4, 4);

                int randValue;
                generatedId = ""; 
                char letter;

                for (int i = 0; i < stringLen; i++)
                {   
  
                    //Generate random number
                    randValue = rand.Next(0, 26);
  
                    //Convert random number into a character.
                    letter = Convert.ToChar(randValue + 65);
  
                    //Append character to string.
                    generatedId = generatedId + letter;
                }

                //Check if the generated id is unique in the target table context.
                bool uniqueId = Database.CheckForColumn(generatedId, tableName);

                if(uniqueId) break; //If id does exist, assign id to a new entry.
            }
            return generatedId;
        }
    }
}
