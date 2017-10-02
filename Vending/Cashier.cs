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

        private ChangeEngine changer;

        public delegate void ChangeReturn(bool success, List<ChangeEngine.Change> info);
        public event ChangeReturn OnChangeReturnCallback;

        public Cashier(Storage storage)
        {
            Credit = 0;
            changer = new ChangeEngine(storage, ChangeMethod.Greedy);
            changer.OnReturnChangeCallback += OnReturnChangeCallback;
        }

        public void Add(int value)
        {
            Credit += value;
        }

        public void Reset()
        {
            Credit = 0;
        }

        public bool CheckPurchase(ISellable product)
        {
            if (product == null)
                throw new CashierException("Internal error, try again later.");

            int delta = Credit - product.Price;

            if (delta < 0)
                throw new CashierException("Not enough credit for this commodity.");
            else return true;
        }

        public void SubmitPurchase(ISellable product)
        {
            Credit -= product.Price;
        }

        public void Change(int fromCredit)
        {
            changer.Return(fromCredit);
        }

        private void OnReturnChangeCallback(bool success, List<ChangeEngine.Change> info)
        {
            OnChangeReturnCallback.Invoke(success, info);
        }
    }
}
