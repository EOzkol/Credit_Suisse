using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse_Test
{
   public class CashCard
    {
        private int pinNumber;
        private Account account;

        public CashCard(Account account, int pin) 
        {
            this.pinNumber = pin;
            this.account = account;
        }

        public bool withdraw(double amount)
        {
            return account.withdraw(amount);
        }

        public bool deposit(double amount)
        {
            return account.deposit(amount);
        } 

        public Boolean checkPIN(int inputPin)
        {
            if (inputPin == pinNumber)
                return true;
            else
                return false;

        }
    }
}
