using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class FinanceTrackerApp
{
    // Track income and expenses
    static List<Transaction> incomeList = new List<Transaction>();
    static List<Transaction> expenseList = new List<Transaction>();
    static decimal savingsGoal = 0;

    // Transaction class
    public class Transaction
    {
        public string Category { get; set; }
        public decimal Amount { get; set; }

        public Transaction(string category, decimal amount)
        {
            Category = category;
            Amount = amount;
        }
    }

    static void Main()
    {
        Console.Title = "Personal Finance Tracker";
        ShowIntro();
        ShowMenu();
    }

    static void ShowIntro()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    string introArt = @"
    ███████╗██╗███╗   ██╗
    ██╔════╝██║████╗  ██║
    █████╗  ██║██╔██╗ ██║
    ██╔══╝  ██║██║╚██╗██║
    ██║     ██║██║ ╚████║
    ╚═╝     ╚═╝╚═╝  ╚═══╝
";
    Console.WriteLine(introArt);
    Console.ResetColor();
    Console.WriteLine("Welcome to the Personal Finance Tracker!\n");
    Console.WriteLine("Let's start by setting your savings goal.");
    SetSavingsGoal();
}

    static void SetSavingsGoal()
    {
        Console.Write("Enter your monthly savings goal: $");
        while (!decimal.TryParse(Console.ReadLine(), out savingsGoal) || savingsGoal <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid amount. Please enter a valid positive number.");
            Console.ResetColor();
        }
    }

    static void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Main Menu:");
            Console.ResetColor();
            Console.WriteLine("1. Add Income");
            Console.WriteLine("2. Add Expense");
            Console.WriteLine("3. View Budget Report");
            Console.WriteLine("4. Export to CSV");
            Console.WriteLine("5. Set New Savings Goal");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option (1-6): ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddIncome();
                    break;
                case "2":
                    AddExpense();
                    break;
                case "3":
                    ViewBudgetReport();
                    break;
                case "4":
                    ExportToCSV();
                    break;
                case "5":
                    SetSavingsGoal();
                    break;
                case "6":
                    ExitProgram();
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void AddIncome()
    {
        Console.Clear();
        Console.WriteLine("Add Income:");
        Console.Write("Enter income category (e.g., Salary, Freelancing): ");
        string category = Console.ReadLine();
        decimal amount = GetValidAmount("Enter income amount: ");

        incomeList.Add(new Transaction(category, amount));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Income added successfully!");
        Console.ResetColor();
        PauseForEffect();
    }

    static void AddExpense()
    {
        Console.Clear();
        Console.WriteLine("Add Expense:");
        Console.Write("Enter expense category (e.g., Rent, Groceries, Entertainment): ");
        string category = Console.ReadLine();
        decimal amount = GetValidAmount("Enter expense amount: ");

        expenseList.Add(new Transaction(category, amount));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Expense added successfully!");
        Console.ResetColor();
        PauseForEffect();
    }

    static decimal GetValidAmount(string prompt)
    {
        decimal amount;
        Console.Write(prompt);
        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid amount. Please enter a valid positive number.");
            Console.ResetColor();
            Console.Write(prompt);
        }
        return amount;
    }

    static void ViewBudgetReport()
    {
        Console.Clear();
        Console.WriteLine("=== Budget Report ===");

        decimal totalIncome = incomeList.Sum(i => i.Amount);
        decimal totalExpenses = expenseList.Sum(e => e.Amount);
        decimal savings = totalIncome - totalExpenses;

        Console.WriteLine($"Total Income: ${totalIncome}");
        Console.WriteLine($"Total Expenses: ${totalExpenses}");
        Console.WriteLine($"Savings: ${savings}\n");

        if (savings >= savingsGoal)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Congratulations! You've reached your savings goal of ${savingsGoal}.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You need ${savingsGoal - savings} more to reach your savings goal.");
        }
        Console.ResetColor();

        Console.WriteLine("\nExpenses Breakdown:");
        DisplayPieChart();
        PauseForEffect();
    }

    static void DisplayPieChart()
    {
        if (!expenseList.Any())
        {
            Console.WriteLine("No expenses to display.");
            return;
        }

        decimal totalExpenses = expenseList.Sum(e => e.Amount);
        var expenseCategories = expenseList.GroupBy(e => e.Category)
                                           .Select(g => new { Category = g.Key, Total = g.Sum(e => e.Amount) })
                                           .ToList();

        foreach (var category in expenseCategories)
        {
            int percentage = (int)((category.Total / totalExpenses) * 100);
            Console.WriteLine($"{category.Category}: {new string('*', percentage / 2)} {percentage}%");
        }
    }

    static void ExportToCSV()
    {
        Console.Clear();
        Console.WriteLine("Exporting data to CSV...");

        string filePath = "FinanceReport.csv";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Category,Amount,Type");
            foreach (var income in incomeList)
            {
                writer.WriteLine($"{income.Category},{income.Amount},Income");
            }
            foreach (var expense in expenseList)
            {
                writer.WriteLine($"{expense.Category},{expense.Amount},Expense");
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Data exported successfully to {filePath}");
        Console.ResetColor();
        PauseForEffect();
    }

   static void ExitProgram()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    string exitArt = @"
    ███████╗██╗███╗   ██╗
    ██╔════╝██║████╗  ██║
    █████╗  ██║██╔██╗ ██║
    ██╔══╝  ██║██║╚██╗██║
    ██║     ██║██║ ╚████║
    ╚═╝     ╚═╝╚═╝  ╚═══╝
";
    Console.WriteLine(exitArt);
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("\nThanks for using the Personal Finance Tracker! Goodbye!");
    Console.ResetColor();
    Thread.Sleep(3000); // Pause for effect
    Environment.Exit(0);  // Properly exit the program
}


    static void PauseForEffect()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ResetColor();
        Console.ReadKey();
    }
}
