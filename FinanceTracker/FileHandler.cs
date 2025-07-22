using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinanceTracker
{
    public class FileHandler
    {
        private readonly string filePath; // Path to the JSON file where transactions are saved

        //Constructor to set the file path, defaulting to "transactions.json"
        public FileHandler(string filePath = "transactions.json")
        {
            this.filePath = filePath;
        }

        //method which saves a list of transactions to a JSON file
        public void SaveTransactions(List<Transaction> transactions)
        {
            // Check if the transactions list is null or empty
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(transactions, options);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex) // catch any exceptions that occur during the save process of a transaction
            {
                Console.WriteLine($"Error saving transactions: {ex.Message}");
            }
        }

        // method which loads transactions from a JSON file
        public List<Transaction> LoadTransactions()
        {
            try
            {
                if (!File.Exists(filePath)) // if the file does not exist, return an empty list
                    return new List<Transaction>();

                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>(); 
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error loading transactions: {ex.Message}"); 
                return new List<Transaction>();
            }
        }
    }
}
