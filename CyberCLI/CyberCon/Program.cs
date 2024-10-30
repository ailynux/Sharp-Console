using System;
using System.Linq;
using System.Text;
using System.Threading;

class CyberConsole
{
    static void Main()
    {
        Console.Title = "CyberConsole - The Future is Now!";
        DisplayIntro(); // Cool ASCII art welcome screen
        ShowMenu();
    }

    static void DisplayIntro()
    {
        // Set color for the ASCII art
        Console.ForegroundColor = ConsoleColor.Cyan;
        string asciiArt = @"
  ______     __  __     ______   ______     ______     ______    
 /\  ___\   /\ \_\ \   /\__  _\ /\  __ \   /\  == \   /\  == \   
 \ \  __\   \ \  __ \  \/_/\ \/ \ \ \/\ \  \ \  __<   \ \  __<   
  \ \_____\  \ \_\ \_\    \ \_\  \ \_____\  \ \_\ \_\  \ \_\ \_\ 
   \/_____/   \/_/\/_/     \/_/   \/_____/   \/_/ /_/   \/_/ /_/ 
";
        Console.WriteLine(asciiArt); // Display ASCII art
        Console.ResetColor(); // Reset color after ASCII art
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Welcome! Let's begin your mission...");
        Console.ResetColor();
        Thread.Sleep(2000); // Pause for dramatic effect
        Console.Clear();
    }

    static void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== CyberConsole Main Menu ===");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Password Generator & Strength Checker");
            Console.WriteLine("2. Fake Username Generator");
            Console.WriteLine("3. Countdown Timer");
            Console.WriteLine("4. Word Scrambler Games");
            Console.WriteLine("5. Simulated Hack Attack");
            Console.WriteLine("6. Exit");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Choose an option (1-6): ");
            Console.ResetColor();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    PasswordGenerator();
                    break;
                case "2":
                    UsernameGenerator();
                    break;
                case "3":
                    CountdownTimer();
                    break;
                case "4":
                    WordScramblerGames();
                    break;
                case "5":
                    SimulatedHackAttack();
                    break;
                case "6":
                    ExitProgram();
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    break;
            }
        }
    }

    static void PasswordGenerator()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("=== Password Generator ===");
        string generatedPassword = GeneratePassword(16); // Generates 16-char password
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Your new hacker password: {generatedPassword}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Password strength: {CheckPasswordStrength(generatedPassword)}");
        Console.ResetColor();
        PauseForEffect();
    }

    static string GeneratePassword(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
        Random random = new Random();
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }

    static string CheckPasswordStrength(string password)
    {
        if (password.Length >= 12 && password.Any(char.IsDigit) && password.Any(char.IsUpper) && password.Any(char.IsLower))
        {
            return "Strong";
        }
        return "Weak";
    }

    static void UsernameGenerator()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("=== Fake Username Generator ===");
        string hackerUsername = "Neo_" + Guid.NewGuid().ToString("N").Substring(0, 7);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Your hacker alias: {hackerUsername}");
        Console.ResetColor();
        PauseForEffect();
    }

    static void CountdownTimer()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("=== Countdown Timer ===");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Enter countdown time in seconds: ");
        Console.ResetColor();
        if (int.TryParse(Console.ReadLine(), out int seconds))
        {
            for (int i = seconds; i >= 0; i--)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Countdown: {i}");
                Thread.Sleep(1000);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Mission Complete!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Returning to menu...");
            Console.ResetColor();
        }
        PauseForEffect();
    }

    static void WordScramblerGames()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("=== Word Scrambler Game ===");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1. Beginner Level");
        Console.WriteLine("2. Intermediate Level");
        Console.WriteLine("3. Expert Level");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Choose a level (1-3): ");
        Console.ResetColor();

        string level = Console.ReadLine();
        switch (level)
        {
            case "1":
                ScramblerGame(new string[] { "code", "hack", "java", "data" });
                break;
            case "2":
                ScramblerGame(new string[] { "console", "cyberpunk", "matrix", "algorithm" });
                break;
            case "3":
                ScramblerGame(new string[] { "cryptography", "vulnerability", "infrastructure", "synchronization" });
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid level. Returning to menu...");
                Console.ResetColor();
                Thread.Sleep(1000);
                break;
        }
    }

    static void ScramblerGame(string[] words)
    {
        Random random = new Random();
        string selectedWord = words[random.Next(words.Length)];

        string scrambledWord = new string(selectedWord.ToCharArray().OrderBy(c => random.Next()).ToArray());

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Unscramble the word: {scrambledWord}");
        Console.Write("Your guess: ");
        Console.ResetColor();
        string guess = Console.ReadLine();

        if (guess.Equals(selectedWord, StringComparison.OrdinalIgnoreCase))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct! You're a true hacker.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Wrong! The correct word was: {selectedWord}");
            Console.ResetColor();
        }

        PauseForEffect();
    }

    static void SimulatedHackAttack()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("=== Simulated Hack Attack ===");
        Console.ResetColor();
        for (int i = 0; i <= 100; i += 5)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\rLaunching hack attack... [{i}%]");
            Console.ResetColor();
            Thread.Sleep(100);
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Hack completed successfully. Mission accomplished.");
        Console.ResetColor();
        PauseForEffect();
    }

    static void ExitProgram()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Thanks for using CyberConsole. Goodbye.");
        Console.ResetColor();
        Thread.Sleep(1500);
    }

    static void PauseForEffect()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Press any key to return to menu...");
        Console.ResetColor();
        Console.ReadKey();
    }
}
