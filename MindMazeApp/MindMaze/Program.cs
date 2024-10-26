using System;
using System.Collections.Generic;
using System.Threading;

class MindMazeApp
{
    static int lives = 3; // Player starts with 3 lives
    static Random random = new Random();

    static void Main()
    {
        Console.Title = "Mind Maze - Can You Escape?";
        ShowIntro();
        StartGame();
    }

    static void ShowIntro()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        string asciiArt = @"
  __  __ _           _    __  __                 
 |  \/  (_)         | |  |  \/  |                
 | \  / |_  ___  ___| |_ | \  / | __ _ _ __   ___ 
 | |\/| | |/ _ \/ __| __|| |\/| |/ _` | '_ \ / _ \
 | |  | | |  __/ (__| |_ | |  | | (_| | | | |  __/
 |_|  |_|_|\___|\___|\__||_|  |_|\__,_|_| |_|\___|
                                                  
";
        Console.WriteLine(asciiArt);
        Console.ResetColor();
        Thread.Sleep(2000); // Pause for effect
    }

    static void StartGame()
    {
        while (lives > 0)
        {
            EnterRoom();
            if (lives <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou have failed too many puzzles. Game Over!");
                Console.ResetColor();
                break;
            }
        }
        EndGame();
    }

    // Player enters a random room
    static void EnterRoom()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nYou enter a mysterious room...");
        Console.ResetColor();
        Thread.Sleep(1000);

        int roomType = random.Next(1, 4); // Choose a random type of puzzle room (1 to 3)
        switch (roomType)
        {
            case 1:
                RiddleRoom();
                break;
            case 2:
                MathRoom();
                break;
            case 3:
                LogicRoom();
                break;
        }
    }

    // Riddle Room
    static void RiddleRoom()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to the Riddle Room!");
        Console.ResetColor();
        Thread.Sleep(1000);

        string[] riddles = {
            "I speak without a mouth and hear without ears. I have no body, but I come alive with wind. What am I?",
            "The more you take, the more you leave behind. What am I?",
            "I am not alive, but I grow. I don’t have lungs, but I need air. What am I?"
        };

        string[] answers = { "echo", "footsteps", "fire" };

        int riddleIndex = random.Next(riddles.Length);
        Console.WriteLine($"Riddle: {riddles[riddleIndex]}");
        Console.Write("Your answer: ");
        string userAnswer = Console.ReadLine()?.ToLower();

        if (userAnswer == answers[riddleIndex])
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct! You may proceed.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Wrong! The correct answer was: {answers[riddleIndex]}");
            lives--;
            Console.WriteLine($"Lives remaining: {lives}");
            Console.ResetColor();
        }
        PauseForEffect();
    }

    // Math Puzzle Room
    static void MathRoom()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to the Math Puzzle Room!");
        Console.ResetColor();
        Thread.Sleep(1000);

        int num1 = random.Next(1, 21);
        int num2 = random.Next(1, 21);
        Console.WriteLine($"Solve this: {num1} + {num2} = ?");
        Console.Write("Your answer: ");

        if (int.TryParse(Console.ReadLine(), out int userAnswer))
        {
            if (userAnswer == num1 + num2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct! You may proceed.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Wrong! The correct answer was: {num1 + num2}");
                lives--;
                Console.WriteLine($"Lives remaining: {lives}");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input! You lose a life.");
            lives--;
        }
        Console.ResetColor();
        PauseForEffect();
    }

    // Logic Puzzle Room
    static void LogicRoom()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to the Logic Puzzle Room!");
        Console.ResetColor();
        Thread.Sleep(1000);

        string[] puzzles = {
            "You see a boat filled with people. It has not sunk, but when you look again you don’t see a single person on the boat. Why?",
            "What can run but never walks, has a mouth but never talks, has a head but never weeps, has a bed but never sleeps?"
        };

        string[] answers = { "they are all married", "a river" };

        int puzzleIndex = random.Next(puzzles.Length);
        Console.WriteLine($"Logic Puzzle: {puzzles[puzzleIndex]}");
        Console.Write("Your answer: ");
        string userAnswer = Console.ReadLine()?.ToLower();

        if (userAnswer == answers[puzzleIndex])
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct! You may proceed.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Wrong! The correct answer was: {answers[puzzleIndex]}");
            lives--;
            Console.WriteLine($"Lives remaining: {lives}");
            Console.ResetColor();
        }
        PauseForEffect();
    }

    static void EndGame()
    {
        if (lives > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCongratulations! You have successfully escaped the Mind Maze!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou have failed to escape the Mind Maze. Better luck next time.");
        }
        Console.ResetColor();
    }

    static void PauseForEffect()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nPress any key to continue...");
        Console.ResetColor();
        Console.ReadKey();
    }
}
