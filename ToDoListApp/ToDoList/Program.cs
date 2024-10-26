using System;
using System.Collections.Generic;

namespace ToDoList
{
    class Program
    {
        static List<string> tasks = new List<string>();

        static void Main(string[] args)
        {
            // Add a cyberpunk ASCII header
            PrintHeader();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n[1] Add Task  [2] View Tasks  [3] Remove Task  [4] Exit");
                Console.ResetColor();

                string option = Console.ReadLine();

                if (option == "1") AddTask();
                else if (option == "2") ViewTasks();
                else if (option == "3") RemoveTask();
                else if (option == "4") break;
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
 ________________________________________________________
|                                                        |
|    _______  _______    _______         _______         |
|   |  _____||   ___|  |  ____  |  /\   |   _   |        |
|   | |      |  |__    | |____| | /  \  |  |_|  |        |
|   | |      |   __|   |  ____  |/ /\ \ |   _   |        |
|   | |_____ |  |_____ | |    | | |__| ||  | |  |        |
|   |_______||________||_|    |_|______||__| |__|        |
|                                                        |
|   WELCOME TO THE FUTURISTIC TASK MANAGEMENT SYSTEM     |
|________________________________________________________|

            ");
            Console.ResetColor();
        }

        static void AddTask()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--- Task Creation ---");
            Console.ResetColor();

            Console.WriteLine("Enter the task:");
            string task = Console.ReadLine();

            tasks.Add(task);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n+++ Task added successfully! +++");
            Console.ResetColor();
        }

        static void ViewTasks()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--- Task List ---");
            Console.ResetColor();

            if (tasks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("+++ No tasks added yet. +++");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Your current tasks:");
                Console.ResetColor();

                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[{i + 1}] {tasks[i]}");
                    Console.ResetColor();
                }
            }
        }

        static void RemoveTask()
        {
            ViewTasks();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n--- Remove Task ---");
            Console.ResetColor();

            Console.WriteLine("Enter the task number to remove:");
            int taskNumber;
            if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks.RemoveAt(taskNumber - 1);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n+++ Task removed successfully! +++");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nERROR: Invalid task number.");
                Console.ResetColor();
            }
        }
    }
}
