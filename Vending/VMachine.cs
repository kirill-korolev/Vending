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
        public Storage Storage => storage;

        public class VMachineException : Exception
        {
            public VMachineException(string message) : base(message) { }
        }

        public VMachine()
        {
            storage = new Storage();
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

        public void PreserveProducts(string fileName)
        {
            try
            {
                JsonParser.Write<Wrapper<Product>>(fileName, products);
            }
            catch
            {
                throw new Exception("Can't preserve products state.");
            }
        }

        public void PreserveStorage(string fileName)
        {
            try
            {
                JsonParser.Write<Wrapper<Money>>(fileName, storage.GetMoney());
            }
            catch
            {
                throw new Exception("Can't preserve cash state.");
            }
        }

        public void UpdateStorage(int money)
        {
            storage.Insert(money);
        }

        public void UpdateProducts(ISellable product)
        {
            for(int i = 0; i < products.Count; i++)
            {
                if(product.Price == products[i].Price)
                {
                    if (products[i].Left > 0)
                    {
                        products[i].Left--;
                        break;
                    }
                    else
                        throw new VMachineException("Can't fetch this current product from storage. Nothing left.");
                }
            }
        }
    }
}
