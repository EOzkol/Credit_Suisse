using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse_Test
{
    public class IncorrectPinException : Exception
    {
        public IncorrectPinException()
            : base() { }
    }

    public class InsufficientFundException : Exception
    {
        public InsufficientFundException()
            : base() { }
    }

    public class NoMoreCansException : Exception
    {
        public NoMoreCansException()
            : base() { }
    }

    public class VendingMachineInternalError : Exception
    {
        public VendingMachineInternalError()
            : base() { }
    }

}