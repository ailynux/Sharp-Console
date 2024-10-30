using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class MemoryLaneApp
{
    static List<Memory> memories = new List<Memory>();
    static Random random = new Random();

    // Memory class with categories
    public class Memory
    {
        public string Content { get; set; }
        public string Category { get; set; }

        public Memory(string content, string category)
        {
            Content = content;
            Category = category;
        }
    }

    static void Main()
    {
        Console.Title = "Memory Lane - Relive Your Best Moments!";
        ShowIntro();
        ShowMenu();
    }

    // ASCII Art Intro
    static void ShowIntro()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        string asciiArt = @"
 __  __                            _     _   _             
|  \/  | ___  _ __ ___   __ _ _   _(_) __| | | | ___   __ _ 
| |\/| |/ _ \| '_ ` _ \ / _` | | | | |/ _` | | |/ _ \ / _` |
| |  | | (_) | | | | | | (_| | |_| | | (_| | | | (_) | (_| |
|_|  |_|\___/|_| |_| |_|\__,_|\__,_|_|\__,_| |_|\___/ \__, |
                                                     |___ / 
";
        Console.WriteLine(asciiArt);
        Console.ResetColor();
        Thread.Sleep(2000); // Pause for dramatic effect
    }

    static void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            DisplayHeader("Memory Lane Main Menu");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Add a New Memory");
            Console.WriteLine("2. Relive a Random Memory");
            Console.WriteLine("3. Search Memories");
            Console.WriteLine("4. View All Memories");
            Console.WriteLine("5. Exit");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nChoose an option (1-5): ");
            Console.ResetColor();

            string? choice = Console.ReadLine();
            if (choice != null)
            {
                switch (choice)
                {
                    case "1":
                        AddMemory();
                        break;
                    case "2":
                        ReliveMemory();
                        break;
                    case "3":
                        SearchMemories();
                        break;
                    case "4":
                        ViewAllMemories();
                        break;
                    case "5":
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
    }

    static void DisplayHeader(string title)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n=== {title} ===");
        Console.ResetColor();
    }

    static void AddMemory()
    {
        Console.Clear();
        DisplayHeader("Add a New Memory");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Enter your memory (e.g., 'Graduated college', 'Visited Paris'): ");
        string? newMemory = Console.ReadLine();

        Console.Write("\nEnter a category for this memory (e.g., 'Travel', 'Achievements'): ");
        string? category = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(newMemory) && !string.IsNullOrWhiteSpace(category))
        {
            memories.Add(new Memory(newMemory, category));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nMemory '{newMemory}' added successfully under '{category}' category!");

            // Milestone celebration
            if (memories.Count == 5 || memories.Count == 10)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nCongrats! You've added {memories.Count} memories! Keep going!");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Memory and category cannot be empty. Please try again.");
        }
        Console.ResetColor();
        PauseForEffect();
    }

    static void ReliveMemory()
    {
        Console.Clear();
        if (memories.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No memories stored yet. Add some first!");
            Console.ResetColor();
            PauseForEffect();
            return;
        }

        // Choose a random memory
        Memory randomMemory = memories[random.Next(memories.Count)];

        DisplayHeader("Reliving a Memory");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nMemory: {randomMemory.Content}");
        Console.WriteLine($"Category: {randomMemory.Category}");
        Console.ResetColor();

        // Provide a fun or motivational message related to the memory
        DisplayMemoryMessage(randomMemory);
        PauseForEffect();
    }

    // Display a motivational message based on the memory
    static void DisplayMemoryMessage(Memory memory)
    {
        string[] messages = {
            "You're a rockstar! Keep making moments like these!",
            "This memory is proof of your awesome journey. More to come!",
            "That was a special moment! Treasure it forever.",
            "You're unstoppable, and memories like this show why.",
            "The best is yet to come. Keep pushing toward greatness!"
        };

        // Show a random motivational message
        string message = messages[random.Next(messages.Length)];
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nMotivational Message: {message}");
        Console.ResetColor();
    }

    // Search for memories by keyword
    static void SearchMemories()
    {
        Console.Clear();
        DisplayHeader("Search Memories");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Enter a keyword or category to search for: ");
        string? keyword = Console.ReadLine();
        Console.ResetColor();

        if (keyword != null)
        {
            var results = memories.Where(m => m.Content.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                                            || m.Category.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

            if (results.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nFound {results.Count} memories related to '{keyword}':");
                foreach (var memory in results)
                {
                    Console.WriteLine($"- {memory.Content} ({memory.Category})");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nNo memories found for '{keyword}'. Try again!");
            }
        }
        Console.ResetColor();
        PauseForEffect();
    }

    // View all memories
    static void ViewAllMemories()
    {
        Console.Clear();
        DisplayHeader("All Memories");

        if (memories.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No memories stored yet. Add some first!");
            Console.ResetColor();
            PauseForEffect();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You have stored {memories.Count} memories:");
        foreach (var memory in memories)
        {
            Console.WriteLine($"- {memory.Content} ({memory.Category})");
        }
        Console.ResetColor();
        PauseForEffect();
    }

    static void ExitProgram()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        string asciiArt = @"
  __  __                            _     _   _             
|  \/  | ___  _ __ ___   __ _ _   _(_) __| | | | ___   __ _ 
| |\/| |/ _ \| '_ ` _ \ / _` | | | | |/ _` | | |/ _ \ / _` |
| |  | | (_) | | | | | | (_| | |_| | | (_| | | | (_) | (_| |
|_|  |_|\___/|_| |_| |_|\__,_|\__,_|_|\__,_| |_|\___/ \__, |
                                                     |___ / 
";
        Console.WriteLine(asciiArt);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nThanks for using Memory Lane. Keep making amazing memories!");
        Console.ResetColor();
        Thread.Sleep(3000); // Pause for effect
    }

    static void PauseForEffect()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ResetColor();
        Console.ReadKey();
    }
}
