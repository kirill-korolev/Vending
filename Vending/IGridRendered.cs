using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public interface IGridRendered
    {
         string TitleLabel { get; }
         string PriceLabel { get; }
         string LeftLabel { get; }
         string ImagePath { get; }
    }
}
