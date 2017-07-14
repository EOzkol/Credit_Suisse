using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CreditSuisse_Test
{
    public class VendingMachine
    {
        private int numberOfCans = 25;
        public readonly double CAN_PRICE = 50;
        private void giveCan()
        {
            Console.WriteLine("Here is your can");
        }

        public void buyCan(CashCard cashCard, int pin)
        {
            if (numberOfCans < 1)
                throw new NoMoreCansException();
            if (!cashCard.checkPIN(pin))
                throw new IncorrectPinException();
            if (!cashCard.withdraw(CAN_PRICE))
                throw new InsufficientFundException();

            try
            {
                giveCan();
                numberOfCans--;
            }
            catch
            {
                /* incase of vending machine error, 
                 * give money back*/
                cashCard.deposit(CAN_PRICE);
                throw new VendingMachineInternalError();
            }

        }

    }

   
}
