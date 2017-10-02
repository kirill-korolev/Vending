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
            for(int i = 0; i < money.Count; i++)
            {
                if(money[i].Value == value)
                {
                    money[i].Amount++;
                    break;
                }
            }
        }

        public List<Coin> GetCoins()
        {
            List<Coin> coins = new List<Coin>();

            for(int i = 0; i < money.Count; i++)
                if (money[i] is Coin) coins.Add(money[i] as Coin);

            return coins;
        }

        public Wrapper<Money> GetMoney()
        {
            return money;
        }

        public void Update(List<ChangeEngine.Change> change)
        {
            for(int i = 0; i < change.Count; i++)
            {
                for(int j = 0; j < money.Count; j++)
                {
                    if(change[i].Coin == money[j].Value)
                    {
                        money[j].Amount -= change[i].Amount;
                        break;
                    }
                }
            }
        }
    }
}
