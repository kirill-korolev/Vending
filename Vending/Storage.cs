using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public class Storage
    {
        private Wrapper<Money> money;

        public Storage()
        {

        }

        public void Init(Wrapper<Money> money)
        {
            this.money = money;
        }

        public void Insert(int value)
        {
            //TODO
        }

        public List<Coin> Coins()
        {
            List<Coin> coins = new List<Coin>();

            for(int i = 0; i < money.Count; i++)
                if (money[i] is Coin) coins.Add(money[i] as Coin);

            return coins;
        }
    }
}
