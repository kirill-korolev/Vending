using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public static class CashAcceptor
    {
        private static CashInterface cashInterface;

        public static List<int> CashSupported
        {
            get
            {
                return cashInterface.cashSupported;
            }
        }


        public static void Init(string fileName)
        {
            cashInterface = JsonParser.Read<CashInterface>(fileName);
        }

    }

    public class CashInterface
    {
        public List<int> cashSupported;
    }
}
