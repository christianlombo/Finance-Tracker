using FinanceTracker;

namespace FinanceTracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            var transactionManager = new TransactionManager();
            var fileHandler = new FileHandler();
            var consoleInterface = new Interface(transactionManager, fileHandler);
            consoleInterface.Run();
        }
    }
}