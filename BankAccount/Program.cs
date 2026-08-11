namespace BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAcc account1= new BankAcc();
            account1.owner = "Ali";
            account1.Deposit(1000);

            SavingsAccount account2= new SavingsAccount();
            account2.owner = "Sara";
            account2.InterestRate = 10;
            account2.Deposit(2000);
            account2.ApplyInterest();

            BankAcc[] accounts = [account1, account2];

            foreach (BankAcc acc in accounts) {
                Console.WriteLine($"Type:{acc.GetAccountType()}");
                Console.WriteLine($"Balance:{acc.Balance}");
            }
        }
    }
}
