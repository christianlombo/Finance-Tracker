using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker
{
    public class Interface
    {
        private readonly TransactionManager transactionManager; // Manages the transactions
        private readonly FileHandler fileHandler; // Handles file operations for saving and loading transactions

        // Constructur which initialises the transaction manager and file handler
        public Interface(TransactionManager transactionManager, FileHandler fileHandler)
        {
            this.transactionManager = transactionManager;
            this.fileHandler = fileHandler;
        }

        // Method to run the main interface loop
        public void Run()
        {
            // Load transactions on startup
            transactionManager.LoadTransactions(fileHandler.LoadTransactions());

            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        AddTransaction(false);
                        break;
                    case "2":
                        AddTransaction(true);
                        break;
                    case "3":
                        ViewTransactions();
                        break;
                    case "4":
                        ViewTransactionsByCategory();
                        break;
                    case "5":
                        ViewSummary();
                        break;
                    case "6":
                        fileHandler.SaveTransactions(transactionManager.GetTransactions());
                        Console.WriteLine("Transactions saved.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\nFinance Tracker");
            Console.WriteLine("1. Add Income");
            Console.WriteLine("2. Add Expense");
            Console.WriteLine("3. View All Transactions");
            Console.WriteLine("4. View Transactions by Category");
            Console.WriteLine("5. View Balance");
            Console.WriteLine("6. Save and Exit");
            Console.Write("Select an option: ");
        }

        private void AddTransaction(bool isExpense)
        {
            try
            {
                Console.Write("Enter amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                Console.Write("Enter description: ");
                string description = Console.ReadLine()?.Trim();
                Console.Write("Enter category (e.g., Food, Salary): ");
                string category = Console.ReadLine()?.Trim();
                Console.Write("Enter date (yyyy-MM-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                var transaction = new Transaction(amount, description, date, category, isExpense);
                transactionManager.AddTransaction(transaction);
                Console.WriteLine("Transaction added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        private void ViewTransactions()
        {
            var transactions = transactionManager.GetTransactions();
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                return;
            }

            Console.WriteLine("\nTransactions:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        private void ViewTransactionsByCategory()
        {
            Console.Write("Enter category: ");
            string category = Console.ReadLine()?.Trim();
            var transactions = transactionManager.GetTransactionsByCategory(category);
            if (transactions.Count == 0)
            {
                Console.WriteLine($"No transactions found for category '{category}'.");
                return;
            }

            Console.WriteLine($"\nTransactions in category '{category}':");
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        private void ViewSummary()
        {
            var (income, expenses, balance) = transactionManager.GetFinancialSummary();
            Console.WriteLine($"\nTotal Income: {income:C}");
            Console.WriteLine($"Total Expenses: {expenses:C}");
            Console.WriteLine($"Balance: {balance:C}");
        }
    }
}

