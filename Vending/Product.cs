using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public class Product: IGridRendered
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Left { get; set; }
        public string Image { get; set; }

        string IGridRendered.TitleLabel
        {
            get
            {
                return Name;
            }
        }
        string IGridRendered.PriceLabel
        {
            get
            {
                return Price.ToString() + "P";
            }
        }
        string IGridRendered.LeftLabel
        {
            get
            {
                return Left.ToString();
            }

        }
        string IGridRendered.ImagePath
        {
            get
            {
                return Image;
            }
        }

        public Product()
        {
            
        }

    }
}
