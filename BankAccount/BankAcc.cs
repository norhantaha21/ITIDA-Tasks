using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankAcc
    {
        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }

        }
        public string owner { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid Amount");
                return;
            }
            _balance += amount;
        }

        public void Withdraw(decimal amount) {
            if (amount <= 0) {
                Console.WriteLine("Invalid Amount");
                return;
            }
            if (amount > _balance) {
                Console.WriteLine("Insufficient balance");
            }
            _balance -= amount;
        }

        public virtual string GetAccountType()
        {
            return "Standard";
        }
    }
}
