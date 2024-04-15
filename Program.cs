using System;
using System.Text;

public class Program
{
    public static char[] vowels = { 'a', 'i', 'u', 'e', 'o' };

    public static string procVowel(string param)
    {
        //Initialize StringBuilder for better string manipulation
        StringBuilder vowel = new StringBuilder();
        
        //Remove any spaces and change the param/input to LowerCase
        param = param.Replace(" ", "").ToLower();

        //looping for finding and append/insert vowels inside the input
        foreach (char p in param)
        {
            if (vowels.Contains(p))
            {
                vowel.Append(p);
            }
        }

        //Sorting the vowels by its order of appearance
        string sortedVowels = new string(vowel
            .ToString()
            .ToCharArray()
            .OrderBy(p => param.IndexOf(p))
            .ToArray());

        return sortedVowels;
    }

    public static string procConsonant(string param)
    {

        StringBuilder consonant = new StringBuilder();
        param = param.Replace(" ","").ToLower();
        foreach (char p in param)
        {
            if (!vowels.Contains(p))
            {
                consonant.Append(p);
            }
        }
        string sortedConsonants  = new string(consonant
            .ToString()
            .ToCharArray()
            .OrderBy(p => param.IndexOf(p))
            .ToArray());

        return sortedConsonants;
    }

    public static void Case1() {
        try
        {
            Console.WriteLine("\n--- This is Case Number 1 - Sort Character ---\n");
            Console.Write("Input one line of words (S) : ");
            string input = Console.ReadLine();

            string charVowel = procVowel(input);
            string charConsonant = procConsonant(input);

            Console.WriteLine("Vowel Characters : ");
            Console.WriteLine(charVowel);
            Console.WriteLine("Consonant Characters : ");
            Console.WriteLine(charConsonant);
            Console.WriteLine("\n Program Done \n");
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message.ToString()}\n");
        }

    }

    public static void Case2()
    {
        Console.WriteLine("\n--- This is Case Number 2 - PSBB ( Pembatasan Sosial Berskala Besar ) ---\n");

        int busCapacity = 4;
        bool validInput = false;
        int totalPassengers = 0;

        try
        {
            while (!validInput)
            {
                Console.Write("Input the number of families : ");
                int totalFamily = Convert.ToInt32(Console.ReadLine());

                //Handler for totalFamily = 0
                if (totalFamily != 0)
                {
                    Console.Write($"--- Total Families = {totalFamily} ---\n");
                    Console.Write("Input the number of members in the family\r\n(separated by a space) : ");
                    string[] members = Console.ReadLine().Split(' ');

                    //Handler to make sure the input isn't 0 
                    if (members.Any(m => string.IsNullOrEmpty(m)))
                    {
                        Console.WriteLine("### Member must not be empty ###\n");
                    }

                    //Handler to make sure the input count must be equal or same as total family
                    else if (members.Length != totalFamily)
                    {
                        Console.WriteLine("### Input must be equal with count of family ###\n");
                    }
                    else
                    {

                        //loop for converting string to int for counting totalPassenger
                        foreach (string m in members)
                        {
                            totalPassengers += int.Parse(m);
                        }

                        //Rounding up for totalBus required for picking up passengers, since there might be a bus where it consist less than 4 people inside
                        int totalBus = (int)Math.Ceiling((double)totalPassengers / busCapacity);

                        Console.WriteLine($"Minimum bus required is : {totalBus} \n");

                        Console.WriteLine("\n Program Done \n");
                        validInput = true;

                    }
                }
                else
                {
                    Console.WriteLine("Total Family Must Not Be 0\n");
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine($"{e.Message.ToString()}\n");
        }

    }

    public static void MainMenu()
    {
        bool status = true;
        while (status)
        {
            try{
                Console.WriteLine("Select Case Number ( 1 - 2 ), Type 3 For Exit The Program");
                int caseNo = Convert.ToInt32(Console.ReadLine());
                switch (caseNo)
                {
                    case 1:
                        Case1();
                        break;
                    case 2:
                        Case2();
                        break;
                    case 3:
                        Console.WriteLine("\nExit The Program...");
                        status = false;
                        break;

                    default:
                        Console.WriteLine("\n### Invalid Input Please Input Number Between 1 - 3 ###\n");
                        break;
                }
            }
            catch(Exception e) { 
                Console.WriteLine($"{e.Message.ToString()}\n"); 
            }
        }
    }

    public static void Main()
    {
        MainMenu();
    }
}