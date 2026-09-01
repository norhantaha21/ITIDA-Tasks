using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class PremiumSavingsAccount:SavingsAccount
    {
        public override void ApplyInterest()
        {
            decimal interest = Balance *(InterestRate * 2)/100;
            Deposit(interest);
        }

        public override string GetAccountType()
        {
            return "Premium Savings";
        }
    }
}
