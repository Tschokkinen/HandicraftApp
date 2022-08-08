using System;

public class CollectData
{
    public static int AskForInt (string question)
    {
        int size; 

        while (true)
        {
            Console.WriteLine(question);
            string input = Console.ReadLine();
            bool isNumber = int.TryParse(input, out size);

            if (isNumber) //Check if user entered a number.
            {
                return size;
            }
            else
            {
                Console.WriteLine("\nAnna numeraali.\n");
            }
        }
    }

    public static double AskForDouble (string question)
    {
        double size; 

        while (true)
        {
            Console.WriteLine(question);
            string input = Console.ReadLine();
            bool isNumber = double.TryParse(input, out size);

            if (isNumber) //Check if user entered a number.
            {
                return size;
            }
            else
            {
                Console.WriteLine("\nAnna numeraali.\n");
            }
        }
    }

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
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }

    public static string AskForFabricMainType()
        {
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

    public static string GenerateRandomId(string tableName)
    {
        string generatedId;

        while (true)
        {
            //Create random
            Random rand = new Random();
  
            //Size of the string
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

            bool uniqueId = Database.CheckForColumn(generatedId, tableName);

            if(uniqueId) break;
        }
        return generatedId;
    }
    
    
}