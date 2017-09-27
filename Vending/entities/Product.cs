using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public class Product: IGridRendered, ISellable
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Left { get; set; }
        public string Image { get; set; }

        string IGridRendered.Header => Name;
        string IGridRendered.Description => String.Concat(Price, " RUB");
        string IGridRendered.Additional => String.Concat(Left, " left");
        string IGridRendered.ImagePath => Image;
        bool IGridRendered.Active => Left > 0;

        public Product()
        {
            
        }

    }
}
