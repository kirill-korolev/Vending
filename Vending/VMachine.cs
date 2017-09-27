using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public class VMachine
    {
        private Storage storage;
        private Wrapper<Product> products;
        private ChangeEngine changer;

        public delegate void ChangeReturn(bool success, List<ChangeEngine.Change> info);
        public event ChangeReturn OnChangeReturnCallback;

        public Wrapper<Product> Products => products;

        public VMachine()
        {
            storage = new Storage();
            changer = new ChangeEngine(storage);
            changer.OnReturnChangeCallback += OnReturnChangeCallback;
        }

        public void LoadProducts(string fileName)
        {
            products = JsonParser.ReadCollection<Product>(fileName);
        }

        public void LoadStorage(string fileName)
        {
            var money = JsonParser.ReadCollection<Money>(fileName, new JsonMoneyConverter());
            storage.Init(money);
        }

        public void Insert(int money)
        {
            storage.Insert(money);
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
