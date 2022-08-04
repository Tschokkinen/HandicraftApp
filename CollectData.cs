using System;

public class CollectData
{
    public static int AskForSize (string question)
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

    public static string AskForMaterial (string question)
    {
        //Display proper question and format input
        Console.WriteLine(question);
        string input = Console.ReadLine();
        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }

    public static string AskForColour (string question)
    {
        //Display proper question and format input
        Console.WriteLine(question);
        string input = Console.ReadLine();
        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }

    public static string GenerateRandomId()
    {
        // Creating object of random class
        Random rand = new Random();
  
        // Choosing the size of string
        // Using Next() string
        int stringlen = rand.Next(4, 4);
        int randValue;
        string str = "";
            
        char letter;
        
        for (int i = 0; i < stringlen; i++)
        {   
  
            // Generating a random number.
            randValue = rand.Next(0, 26);
  
            // Generating random character by converting
            // the random number into character.
            letter = Convert.ToChar(randValue + 65);
  
            // Appending the letter to string.
            str = str + letter;
        }
        return str;
    }

    /*
    public static string GenerateRandomId()
    {
        string str;

        while (true)
        {
            str = "";
            // Creating object of random class
            Random rand = new Random();
  
            // Choosing the size of string
            // Using Next() string
            int stringlen = rand.Next(4, 4);
            int randValue;
            
            char letter;
            for (int i = 0; i < stringlen; i++)
            {   
  
                // Generating a random number.
                randValue = rand.Next(0, 26);
  
                // Generating random character by converting
                // the random number into character.
                letter = Convert.ToChar(randValue + 65);
  
                // Appending the letter to string.
                str = str + letter;
            }

            bool uniqueId = Database.CheckForColumn(str);

            if(uniqueId) break;
        }
        return str;
    }
    */
}