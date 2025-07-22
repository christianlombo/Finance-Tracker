using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker
{
    public class Transaction
    {
        //Initialising variables 
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public bool IsExpense { get; set; }

        // Constructor to initialise a transaction with validation
        public Transaction(decimal amount, string description, DateTime date, string category, bool isExpense)
        {
            //ensures the amount is greater than zero, description and category are not empty
            if (amount <= 0) throw new ArgumentException("Amount must be greater than zero.");
           if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description cannot be empty.");
           if(string.IsNullOrWhiteSpace(category)) throw new ArgumentException("Category cannot be empty.");
            Amount = amount;
            Description = description;
            Date = date;
            Category = category;
            IsExpense = isExpense;
        }

        //format the transaction details as a string for display
        public override string ToString() {
            return $"{Date:MM/dd/yyyy} | {(IsExpense ? "Expense" : "Income")} | {Amount:C} | {Category} | {Description}";
        }
    }
}
