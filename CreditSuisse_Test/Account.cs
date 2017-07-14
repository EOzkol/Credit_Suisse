using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/*Elif Ozkol - Credit Suisse PreInterview Exercise*/

namespace CreditSuisse_Test
{
    public class Account
    {
        public double balance;
        
        public Account(double startingBalance)
        {
            this.balance = startingBalance;
        }

       
        /* Only one thread can access at a time */
        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool withdraw(double amount)
        {
            if (balance > amount)
            {
                balance -= amount;
                return true;
            } else
            {
                return false;
            }
        }

        /* Only one thread can access at a time */
        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool deposit(double amount)
        {
            balance += amount;
            return true;
        }
    }
}
