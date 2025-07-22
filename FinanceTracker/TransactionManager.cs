using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker
{
    public class TransactionManager
    {
        private List<Transaction> transactions;//list which stores transactions

        // Constructor to initialise the transaction manager
        public TransactionManager()
        {
            transactions = new List<Transaction>();
        }

        // Method to add a transaction to the list
        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        // Method to get all transactions
        public List<Transaction> GetTransactions()
        {
            return transactions;
        }

        // Method to get all transactions based off category
        public List<Transaction> GetTransactionsByCategory(string category)
        {
            return transactions.Where(t => t.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Method responsible for calculating the financial summary
        public (decimal income, decimal expenses, decimal balance) GetFinancialSummary()
        {
            decimal income = transactions.Where(t => !t.IsExpense).Sum(t => t.Amount);
            decimal expenses = transactions.Where(t => t.IsExpense).Sum(t => t.Amount);
            decimal balance = income - expenses;
            return (income, expenses, balance);
        }

        // Method to load/call transactions from list
        public void LoadTransactions(List<Transaction> loadedTransactions)
        {
            transactions = loadedTransactions ?? new List<Transaction>();
        }
    }
}
