using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public interface IGridRendered
    {
         string Header { get; }
         string Description { get; }
         string Additional { get; }
         string ImagePath { get; }
         bool Active { get; }
    }
}
