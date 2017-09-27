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

        public void Insert(int money)
        {

        }
    }
}
