using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public class Money
    {
        public int Value { get; set; }
        public int Amount { get; set; }
        public bool IsCoin { get; set; }

        public Money() { }
    }

    public class Coin : Money
    {
        public Coin(): base() { }
    }

    public class Bill : Money
    {
        public Bill() : base() { }
    }

}
