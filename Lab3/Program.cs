using System;
using System.Text.RegularExpressions;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = GetName();
            do
            {
                Console.Write($"\n{name}, please enter a number between 1 and 100: ");
                int input = GetInt();
                CheckTheInput(input);
            } while (KeepGoing());

            Console.WriteLine("\n\n-----------------------------------");
            Console.WriteLine("End of Demo. Press any key to exit.");
            Console.ReadKey();
        }

        private static string GetName()
        {
            Console.Write("Hello User, what is your name? (Enter to skip this step): ");
            string userName = Console.ReadLine();
            if (userName == "") return "Anonymous";
            if (Regex.IsMatch(userName, @"^([a-z A-Z])+$")) // Allows upper and lower case letters and spaces
            {
                return userName;
            }
            else
            {
                Console.WriteLine("That's a weird name, I'm going to call you BOB");
                return "BOB";
            }
        }
        private static int GetInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input >= 1 && input <= 100)
                    {
                        return input;
                    }
                }
                Console.Write("Please enter a whole integer between 1 and 100: ");
            }
        }
        private static bool KeepGoing()
        {
            Console.Write("Continue? (y/n): ");
            while (true)
            {
                string choice = Console.ReadLine().ToLower();
                if (choice == "y") return true;
                if (choice == "n") return false;
                Console.Write("(y/n): ");
            }
        }
        private static void CheckTheInput(int input)
        {
            if (input % 2 == 1) Console.WriteLine($"{input} and Odd");
            else if (input < 25) Console.WriteLine($"Even and less than 25");
            else if (input <= 60) Console.WriteLine($"Even");
            else Console.WriteLine($"{input} and Even");
        }
    }
}
