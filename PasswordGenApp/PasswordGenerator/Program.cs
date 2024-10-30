using System;
using System.Text;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print a secure-themed header
            PrintHeader();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nOptions: 1. Generate Password  2. Exit");
                Console.ResetColor();

                string option = Console.ReadLine();

                if (option == "1") GeneratePassword();
                else if (option == "2") break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("ERROR: Invalid option. Try again.");
                    Console.ResetColor();
                }
            }
        }

        static void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
____________________________________________________________________
|                                                                  |
|    _______  _______  _______  _______  _______  _______          |
|   (  ___  )(  ____ \(  ____ )(  ____ \(  ____ \(  __   )         |
|   | (   ) || (    \/| (    )|| (    \/| (    \/| (  )  |         |
|   | |   | || (__    | (____)|| (__    | (_____ | | /   |         |
|   | |   | ||  __)   |     __)|  __)   (_____  )| (/ /) |         |
|   | |   | || (      | (\ (   | (            ) ||   / | |         |
|   | (___) || (____/\| ) \ \__| (____/\/\____) ||  (__) |         |
|   (_______)(_______/|/   \__/(_______/\_______)(_______)         |
|                                                                  |
|            SECURE PASSWORD GENERATOR SYSTEM ACTIVATED            |
|__________________________________________________________________|
");
            Console.ResetColor();
        }

        static void GeneratePassword()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--- Password Generation ---");
            Console.ResetColor();

            Console.Write("Enter password length (8 - 128): ");
            int length;
            if (!int.TryParse(Console.ReadLine(), out length) || length < 8 || length > 128)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Invalid length. Please enter a number between 8 and 128.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\nInclude symbols? (y/n): ");
            bool includeSymbols = Console.ReadLine().ToLower() == "y";

            Console.WriteLine("Include numbers? (y/n): ");
            bool includeNumbers = Console.ReadLine().ToLower() == "y";

            Console.WriteLine("Include uppercase letters? (y/n): ");
            bool includeUppercase = Console.ReadLine().ToLower() == "y";

            string generatedPassword = CreatePassword(length, includeSymbols, includeNumbers, includeUppercase);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n+++ Your Secure Password: {generatedPassword} +++");
            Console.ResetColor();
        }

        static string CreatePassword(int length, bool includeSymbols, bool includeNumbers, bool includeUppercase)
        {
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string symbols = "!@#$%^&*()_-+=<>?";

            StringBuilder characterPool = new StringBuilder(lower);

            if (includeUppercase) characterPool.Append(upper);
            if (includeNumbers) characterPool.Append(numbers);
            if (includeSymbols) characterPool.Append(symbols);

            Random random = new Random();
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(characterPool.Length);
                password.Append(characterPool[index]);
            }

            return password.ToString();
        }
    }
}
