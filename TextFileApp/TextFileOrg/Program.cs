using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace TextFileOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcome();

            Console.WriteLine("\nEnter the directory to organize:");
            string directoryPath = Console.ReadLine();

            if (!Directory.Exists(directoryPath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDirectory not found!");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\nChoose an option to organize by:");
            Console.WriteLine("1. File Type");
            Console.WriteLine("2. Creation Date (Year/Month)");
            Console.WriteLine("3. File Size (Small/Medium/Large)");
            
            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            Console.Clear();
            switch (choice)
            {
                case "1":
                    OrganizeByFileType(directoryPath);
                    break;
                case "2":
                    OrganizeByDate(directoryPath);
                    break;
                case "3":
                    OrganizeBySize(directoryPath);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice");
                    Console.ResetColor();
                    return;
            }

            DisplaySummary(directoryPath);
            Console.WriteLine("\nOrganization complete.");
        }

        static void DisplayWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
            ╔═══════════════════════════════════════════╗
            ║    WELCOME TO THE TEXT FILE ORGANIZER     ║
            ║      Organize your files like magic!      ║
            ╚═══════════════════════════════════════════╝
            ");
            Console.ResetColor();
        }

        static void OrganizeByFileType(string directoryPath)
        {
            Console.WriteLine("\nOrganizing by File Type...");
            var files = Directory.GetFiles(directoryPath);
            
            foreach (var file in files)
            {
                string fileType = Path.GetExtension(file)?.TrimStart('.').ToUpper() ?? "UNKNOWN";
                string newFolderPath = Path.Combine(directoryPath, $"{fileType}_Files");
                Directory.CreateDirectory(newFolderPath);
                MoveFile(file, newFolderPath);
            }
            Console.WriteLine("Files organized by type.\n");
        }

        static void OrganizeByDate(string directoryPath)
        {
            Console.WriteLine("\nOrganizing by Creation Date...");
            var files = Directory.GetFiles(directoryPath);

            foreach (var file in files)
            {
                DateTime creationDate = File.GetCreationTime(file);
                string folderName = $"{creationDate:yyyy-MM}";
                string newFolderPath = Path.Combine(directoryPath, folderName);
                Directory.CreateDirectory(newFolderPath);
                MoveFile(file, newFolderPath);
            }
            Console.WriteLine("Files organized by creation date.\n");
        }

        static void OrganizeBySize(string directoryPath)
        {
            Console.WriteLine("\nOrganizing by File Size...");
            var files = Directory.GetFiles(directoryPath);

            foreach (var file in files)
            {
                long fileSize = new FileInfo(file).Length;
                string sizeCategory = fileSize switch
                {
                    < 1024 * 1024 => "Small_Files", // Less than 1 MB
                    < 10 * 1024 * 1024 => "Medium_Files", // 1 MB to 10 MB
                    _ => "Large_Files" // 10 MB or more
                };

                string newFolderPath = Path.Combine(directoryPath, sizeCategory);
                Directory.CreateDirectory(newFolderPath);
                MoveFile(file, newFolderPath);
            }
            Console.WriteLine("Files organized by size.\n");
        }

        static void MoveFile(string file, string newFolderPath)
        {
            string newFilePath = Path.Combine(newFolderPath, Path.GetFileName(file));
            if (!File.Exists(newFilePath))
            {
                File.Move(file, newFilePath);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"File already exists: {newFilePath}. Skipping...");
                Console.ResetColor();
            }
        }

        static void DisplaySummary(string directoryPath)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSummary of Organized Files:");
            Console.ResetColor();

            var directories = Directory.GetDirectories(directoryPath);
            foreach (var dir in directories)
            {
                var files = Directory.GetFiles(dir);
                long totalSize = files.Sum(file => new FileInfo(file).Length);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nDirectory: {Path.GetFileName(dir)}");
                Console.ResetColor();
                Console.WriteLine($"  Files Count: {files.Length}");
                Console.WriteLine($"  Total Size: {totalSize / (1024 * 1024.0):F2} MB");
            }
        }
    }
}
