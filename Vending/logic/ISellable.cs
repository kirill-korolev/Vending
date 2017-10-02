using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public interface ISellable
    {
        int Price { get; }
        int Left { get; }
    }
}
