using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public enum ChangeMethod
    {
        Greedy, Dynamic
    }

    public class ChangeEngine
    {
        public delegate void ReturnChange(bool success, List<Change> info);
        public event ReturnChange OnReturnChangeCallback;

        private Storage internalStorage;
        public ChangeMethod ChangeMethod;

        public class Change
        {
            public int Coin { get; set; }
            public int Amount { get; set; }

            public Change(int c, int a)
            {
                Coin = c; Amount = a;
            }
        }

        public ChangeEngine(Storage storage, ChangeMethod method=ChangeMethod.Greedy)
        {
            internalStorage = storage;
            ChangeMethod = method;
        }

        public void Return(int fromCredit)
        {
            bool success;
            List<Change> changes = new List<Change>();
            List<Coin> coins = internalStorage.GetCoins();

            switch (ChangeMethod)
            {
                case ChangeMethod.Greedy:
                    success = this.ReturnGreedy(fromCredit, coins, ref changes);
                    break;
                case ChangeMethod.Dynamic:
                    success = this.ReturnDynamic(fromCredit, coins, ref changes);
                    break;
                default:
                    success = false;
                    break;
            }

            if (success) internalStorage.Update(changes);
            OnReturnChangeCallback.Invoke(success, changes);
        }

        public bool ReturnGreedy(int fromCredit, List<Coin> coins, ref List<Change> changes)
        {
            coins.OrderBy(coin => coin.Value);

            bool success = false;
            int i = coins.Count - 1;

            while(fromCredit > 0)
            {                
                Coin coin = coins[i];               

                while (fromCredit - coin.Value >= 0 && coin.Amount > 0)
                {
                    fromCredit -= coin.Value;
                    coin.Amount--;
                    int j = coins.Count - i - 1;
                    if (changes.ElementAtOrDefault(j) == null) changes.Add(new Change(coin.Value, 1));
                    else changes[j].Amount++;
                }

                if (fromCredit == 0)
                {
                    if(i >= 0) success = true;
                    break;
                }

                i--;
            }

            return success;
        }

        public bool ReturnDynamic(int fromCredit, List<Coin> coins, ref List<Change> changes)
        {
            //NOT IMPLEMENTED YET
            return false;
        }

    }
}
