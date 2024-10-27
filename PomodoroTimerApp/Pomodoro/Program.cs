using System;
using System.Threading;
using System.Collections.Generic;

class CutePomododoTimer
{
    static int workDuration = 25 * 60;  // 25 minutes in seconds
    static int breakDuration = 5 * 60;  // 5 minutes in seconds
    static int sessionCount = 0;
    static Random random = new Random();

    // Define theme colors
    static readonly ConsoleColor[] rainbow = {
        ConsoleColor.Magenta,
        ConsoleColor.Red,
        ConsoleColor.Yellow,
        ConsoleColor.Green,
        ConsoleColor.Cyan,
        ConsoleColor.Blue
    };

    // Cute emoji collection
    static readonly string[] workEmojis = { "🍅", "✨", "💪", "🎯", "💻", "📚", "⭐" };
    static readonly string[] breakEmojis = { "🌸", "🎨", "🎮", "☕", "🎵", "🌿", "🦋" };
    static readonly string[] progressEmojis = { "🌱", "🌿", "🌺", "🌸", "🌼" };

    static void Main()
    {
        Console.Title = "✨ Cute Pomodoro Timer ✨";
        while (true)
        {
            ShowMenu();
            StartPomodoro();
        }
    }

    static void ShowMenu()
    {
        Console.Clear();
        string logo = @"
   🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 
    
   ╭━━━╮╱╱╱╱╱╱╱╱╭━━━╮╱╱╱╱╱╱╱╱╭╮
   ┃╭━╮┃╱╱╱╱╱╱╱╱┃╭━╮┃╱╱╱╱╱╱╱╱┃┃
   ┃╰━╯┣━━┳╮╭┳━━┫┃╱┃┣━━┳━┳━━┳━╯┃
   ┃╭━━┫╭╮┃╰╯┃╭╮┃┃╱┃┃╭╮┃╭┫╭╮┃╭╮┃
   ┃┃╱╱┃╰╯┃┃┃┃╰╯┃╰━╯┃╰╯┃┃┃╰╯┃╰╯┃
   ╰╯╱╱╰━━┻┻┻┫╭━┻━━━┻━━┻╯╰━━┻━━╯
   ╱╱╱╱╱╱╱╱╱╱┃┃ Timer ʕ•ᴥ•ʔ
   ╱╱╱╱╱╱╱╱╱╱╰╯
   
   🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸 🌸";

        AnimateText(logo, true);
        
        string menu = $@"
        🎀 Welcome to your cute productivity companion! 🎀
        
        ╭────────── Menu ──────────╮
        │  1. Start Pomodoro       │
        │  2. View Statistics      │
        │  3. Exit                 │
        ╰──────────────────────────╯

        Current Settings:
        🍅 Work Time: 25 minutes
        🌸 Break Time: 5 minutes
        
        Total Sessions Completed: {sessionCount}
        ";

        AnimateText(menu, false);
        
        Console.WriteLine("\n💫 Press any key to start your Pomodoro journey! 💫");
        Console.ReadKey(true);
    }

    static void StartPomodoro()
    {
        sessionCount++;
        RunTimer(workDuration, "Work", workEmojis);
        PlayNotificationSound();
        RunTimer(breakDuration, "Break", breakEmojis);
        PlayNotificationSound();
    }

    static void RunTimer(int duration, string phase, string[] emojis)
    {
        Console.Clear();
        int initialCursorTop = Console.CursorTop;
        
        for (int remaining = duration; remaining >= 0; remaining--)
        {
            Console.SetCursorPosition(0, initialCursorTop);
            
            string emoji = emojis[random.Next(emojis.Length)];
            ConsoleColor color = rainbow[random.Next(rainbow.Length)];
            
            Console.ForegroundColor = color;
            Console.WriteLine($@"
            {emoji} {phase} Time! {emoji}
            ╭──────────────────────────╮
            │  {remaining / 60:D2}:{remaining % 60:D2} remaining      │
            ╰──────────────────────────╯
            ");

            // Progress bar
            DrawProgressBar(duration - remaining, duration);
            
            Thread.Sleep(1000);
        }
    }

    static void DrawProgressBar(int progress, int total)
    {
        int barWidth = 30;
        int filled = (int)((double)progress / total * barWidth);
        
        Console.Write("            ╭");
        Console.Write(new string('─', barWidth + 2));
        Console.WriteLine("╮");
        
        Console.Write("            │ ");
        for (int i = 0; i < barWidth; i++)
        {
            if (i < filled)
                Console.Write(progressEmojis[i % progressEmojis.Length]);
            else
                Console.Write("░");
        }
        Console.WriteLine(" │");
        
        Console.Write("            ╰");
        Console.Write(new string('─', barWidth + 2));
        Console.WriteLine("╯");
    }

    static void AnimateText(string text, bool isRainbow = false)
{
    foreach (char c in text)
    {
        if (isRainbow)
            Console.ForegroundColor = rainbow[random.Next(rainbow.Length)];
        Console.Write(c);
        Thread.Sleep(5);
    }
    Console.ResetColor();
}


    // Adjusting the PlayNotificationSound to avoid platform-specific warning
    static void PlayNotificationSound()
    {
        if (OperatingSystem.IsWindows())
        {
            Console.Beep(1000, 500); // Only works on Windows
        }
        else
        {
            Console.WriteLine("🔔 Ding! (No sound on non-Windows platforms)");
        }
    }
}
