
# FinanceTracker

A simple personal finance tracker built with C#. Track your income, expenses, and view summaries directly from the console.

## Features

- Add income and expenses
- Categorize transactions
- View all transactions
- Filter transactions by category
- View total income, expenses, and balance
- Save and load transactions from a file

## Requirements

- .NET 8 SDK

## Getting Started

1. **Clone the repository**
2. **Build the project**
   
```
   dotnet build
   
```
3. **Run the application**
   
```
   dotnet run --project FinanceTracker
   
```

## Usage

Follow the on-screen menu to add transactions, view summaries, and save your data.

## Project Structure

- `Program.cs` - Entry point
- `Interface.cs` - Console UI logic
- `TransactionManager.cs` - Handles transaction operations
- `Transaction.cs` - Transaction model
- `FileHandler.cs` - File I/O for transactions
