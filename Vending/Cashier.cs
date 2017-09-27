using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public class Cashier
    {

        public class CashierException: Exception
        {
            public CashierException(string message) : base(message) { }
        }

        public int Credit { get; private set; }

        public Cashier()
        {
            Credit = 0;
        }

        public void Add(int value)
        {
            Credit += value;
        }

        public void Reset()
        {
            Credit = 0;
        }

        public void Buy<T>(ISellable product)
        {
            if (product == null)
                throw new CashierException("Internal error, try again later.");

            int delta = Credit - product.Price;

            if (delta >= 0)
            {
                Credit = delta;
            }
            else
            {
                throw new CashierException("Not enough credit for this commodity.");
            }
        }
    }
}
