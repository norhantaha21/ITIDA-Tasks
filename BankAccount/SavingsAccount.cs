using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class SavingsAccount :BankAcc
    {
        public decimal InterestRate {  get; set; }

        public virtual void ApplyInterest()
        {
            decimal interest = Balance * InterestRate / 100;
            Deposit(interest);
        }

        public override string GetAccountType()
        {
            return "Savings";
        }
    }
}
