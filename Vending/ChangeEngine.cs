using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{

    public class ChangeEngine
    {
        public delegate void ReturnChange(bool success, List<Change> info);
        public event ReturnChange OnReturnChangeCallback;

        private Storage internalStorage;

        public class Change
        {
            public int coin, amount;

            public Change(int c, int a)
            {
                coin = c; amount = a;
            }
        }

        public ChangeEngine(Storage storage)
        {
            internalStorage = storage;
        }

        public void Return(int fromCredit)
        {
            List<Coin> coins = internalStorage.Coins();
            coins.OrderBy(coin => coin.Value);

            bool success = false;
            int i = coins.Count - 1;
            List<Change> changes = new List<Change>();

            while(fromCredit > 0)
            {                
                Coin coin = coins[i];               

                while (fromCredit - coin.Value >= 0 && coin.Amount > 0)
                {
                    fromCredit -= coin.Value;
                    coin.Amount--;
                    int j = coins.Count - i - 1;
                    if (changes.ElementAtOrDefault(j) == null) changes.Add(new Change(coin.Value, 1));
                    else changes[j].amount++;
                }

                if (fromCredit == 0)
                {
                    if(i >= 0) success = true;
                    break;
                }

                i--;
            }

            OnReturnChangeCallback.Invoke(success, changes);
        }

    }
}
