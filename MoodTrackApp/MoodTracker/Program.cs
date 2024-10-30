using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

class DailyMoodTracker
{
    static Dictionary<string, string> moodLog = new Dictionary<string, string>();
    static List<string> moodOptions = new List<string> { "Happy", "Sad", "Anxious", "Calm", "Energetic", "Tired" };

    static void Main()
    {
        Console.Title = "🌈 Daily Mood Tracker 🌈";
        ShowIntro();
        
        while (true)
        {
            ShowMenu();
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    LogMood();
                    break;
                case "2":
                    ViewMoodHistory();
                    break;
                case "3":
                    ExitProgram();
                    return;
                default:
                    Console.WriteLine("❌ Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void ShowIntro()
    {
        string introArt = @"
__    __     ______     ______     _____     
/\ ""-./  \   /\  __ \   /\  __ \   /\  __-.  
\ \ \-./\ \  \ \ \/\ \  \ \ \/\ \  \ \ \/\ \ 
 \ \_\ \ \_\  \ \_____\  \ \_____\  \ \____- 
  \/_/  \/_/   \/_____/   \/_____/   \/____/ 
                                             
 ______   ______     ______     ______     __  __     ______     ______    
/\__  _\ /\  == \   /\  __ \   /\  ___\   /\ \/ /    /\  ___\   /\  == \   
\/_/\ \/ \ \  __<   \ \  __ \  \ \ \____  \ \  _""-.  \ \  __\   \ \  __<   
   \ \_\  \ \_\ \_\  \ \_\ \_\  \ \_____\  \ \_\ \_\  \ \_____\  \ \_\ \_\ 
    \/_/   \/_/ /_/   \/_/\/_/   \/_____/   \/_/\/_/   \/_____/   \/_/ /_/";

        // Save original colors
        ConsoleColor originalBg = Console.BackgroundColor;
        ConsoleColor originalFg = Console.ForegroundColor;

        // Clear console and set window title
        Console.Clear();
        Console.Title = "✨ Daily Mood Tracker ✨";

        // Animate the ASCII art
        foreach (string line in introArt.Split('\n'))
        {
            Console.ForegroundColor = GetRandomColor();
            TypeWriterEffect(line, 5);
            Console.WriteLine();
        }

        // Reset color and add spacing
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n");

        // Animated welcome message with rainbow effect
        string welcome = "Welcome to the Daily Mood Tracker!";
        Console.WriteLine(new string('═', welcome.Length + 4));
        Console.Write("║ ");
        foreach (char c in welcome)
        {
            Console.ForegroundColor = GetRandomColor();
            Console.Write(c);
            Thread.Sleep(50);
        }
        Console.WriteLine(" ║");
        Console.WriteLine(new string('═', welcome.Length + 4));

        // Animated prompt
        Console.ForegroundColor = ConsoleColor.Cyan;
        TypeWriterEffect("\nPress any key to begin your journey...", 30);
        
        // Flashing prompt effect
        bool flash = true;
        DateTime endTime = DateTime.Now.AddSeconds(5);
        while (!Console.KeyAvailable && DateTime.Now < endTime)
        {
            Console.CursorLeft = 0;
            Console.Write(flash ? "▶" : " ");
            flash = !flash;
            Thread.Sleep(500);
        }

        Console.ReadKey(true);
        
        // Clean up
        Console.Clear();
        Console.ForegroundColor = originalFg;
        Console.BackgroundColor = originalBg;
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n╔════════════════════╗");
        Console.WriteLine("║    Main Menu       ║");
        Console.WriteLine("╠════════════════════╣");
        Console.WriteLine("║ 1. Log Today's Mood║");
        Console.WriteLine("║ 2. View History    ║");
        Console.WriteLine("║ 3. Exit            ║");
        Console.WriteLine("╚════════════════════╝");
        Console.Write("\nYour choice: ");
    }

    static void LogMood()
    {
        string today = DateTime.Now.ToString("yyyy-MM-dd");
        
        Console.WriteLine("\n🌟 How are you feeling today? 🌟");
        Console.WriteLine("╔════════════════════╗");
        for (int i = 0; i < moodOptions.Count; i++)
        {
            Console.WriteLine($"║ {i + 1}. {moodOptions[i],-14}║");
        }
        Console.WriteLine("╚════════════════════╝");
        Console.Write("\nChoose a mood (1-6): ");
        
        if (int.TryParse(Console.ReadLine(), out int moodIndex) && moodIndex >= 1 && moodIndex <= moodOptions.Count)
        {
            string mood = moodOptions[moodIndex - 1];
            moodLog[today] = mood;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✨ Mood for {today} logged as: {mood} ✨");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Invalid input. Please enter a number from 1 to 6.");
            Console.ResetColor();
        }
    }

    static void ViewMoodHistory()
    {
        Console.WriteLine("\n📅 Mood History 📅");
        Console.WriteLine("╔═════════════════════════════╗");
        
        if (moodLog.Count == 0)
        {
            Console.WriteLine("║ No mood history available. ║");
            Console.WriteLine("║ Log today's mood to start! ║");
        }
        else
        {
            foreach (var entry in moodLog)
            {
                Console.WriteLine($"║ {entry.Key}: {entry.Value,-16}║");
            }
        }
        
        Console.WriteLine("╚═════════════════════════════╝");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ExitProgram()
    {
        Console.Clear();
        string goodbye = "Thank you for using the Daily Mood Tracker!";
        
        // Animate goodbye message
        foreach (char c in goodbye)
        {
            Console.ForegroundColor = GetRandomColor();
            Console.Write(c);
            Thread.Sleep(50);
        }
        
        Console.WriteLine("\n\nHave a great day! 😊");
        Thread.Sleep(1500);
    }

    static void TypeWriterEffect(string text, int delay)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }
    }

    static ConsoleColor GetRandomColor()
    {
        ConsoleColor[] colors = {
            ConsoleColor.Cyan,
            ConsoleColor.Green,
            ConsoleColor.Yellow,
            ConsoleColor.Red,
            ConsoleColor.Magenta,
            ConsoleColor.White
        };
        return colors[new Random().Next(colors.Length)];
    }

    static string GradientText(string text, ConsoleColor startColor, ConsoleColor endColor)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            Console.ForegroundColor = (ConsoleColor)((int)startColor + 
                (i * ((int)endColor - (int)startColor) / text.Length));
            result.Append(text[i]);
        }
        return result.ToString();
    }
}