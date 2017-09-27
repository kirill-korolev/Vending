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

        public Wrapper<Product> Products => products;

        public VMachine()
        {
            storage = new Storage();
        }

        public void LoadProducts(string fileName)
        {
            products = JsonParser.Read<Product>(fileName, null);
        }

        public void LoadStorage(string fileName)
        {
            var money = JsonParser.Read<Money>(fileName, new JsonMoneyConverter());
            storage.Init(money);
        }

        public void Insert(int money)
        {
            storage.Insert(money);
        }

    }
}
