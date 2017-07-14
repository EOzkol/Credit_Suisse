using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditSuisse_Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace CreditSuisse_Test.Tests
{
    [TestClass()]
    public class VendingMachineTests
    {
        [TestMethod()]
        [ExpectedException(typeof(IncorrectPinException))]
        public void incorrectPinTest()
        {
            VendingMachine vendingMachine = new VendingMachine();
            Account account = new Account(300); //starting balaance

            CashCard cashCard1 = new CashCard(account, 1234);
            vendingMachine.buyCan(cashCard1, 0000);
        }

        [TestMethod()]
        [ExpectedException(typeof(InsufficientFundException))]
        public void insufficientFundTest()
        {
            VendingMachine vendingMachine = new VendingMachine();
            Account account = new Account(30); //starting balaance

            CashCard cashCard1 = new CashCard(account, 1234);
            vendingMachine.buyCan(cashCard1, 1234);
        }

        [TestMethod()]
        [ExpectedException(typeof(NoMoreCansException))]
        public void noMoreCansTest()
        {
            VendingMachine vendingMachine = new VendingMachine();
            Account account = new Account(3000); //starting balaance

            CashCard cashCard1 = new CashCard(account, 1234);
            for(int i = 0; i < 26; i++)
                vendingMachine.buyCan(cashCard1, 1234);
        }

        [TestMethod()]
        public void multiThreadTest()
        {
            VendingMachine vendingMachine = new VendingMachine();
            Account account = new Account(3000); //starting balaance
            CashCard cashCard1 = new CashCard(account, 1234);

            for (int i=0; i<25; i++)
            {
                Task.Run(() => {
                    //Here is a new thread
                    buyOne(vendingMachine, cashCard1);
                });
            }
            return;
        }

        [TestMethod()]
        public void UpdateBalanceTest()
        {
            Double actualValue;
            Double resultValue;
            VendingMachine vendingMachine = new VendingMachine();
            Account account = new Account(3000); //starting balance
            CashCard cashCard1 = new CashCard(account, 1234);
            
            buyOne(vendingMachine, cashCard1);
            resultValue = account.balance;
            actualValue = 3000 - 50;
            Assert.AreEqual(resultValue, actualValue);

        }

        public void buyOne(VendingMachine vendingMachine, CashCard cashCard1)
        {
            vendingMachine.buyCan(cashCard1, 1234);
            Debug.WriteLine("I have bought a new can");
        }
    }
}