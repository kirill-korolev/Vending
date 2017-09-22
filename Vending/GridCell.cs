using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace Vending
{
    public class GridCell<T>: DataGridCell where T:IGridRendered
    {
        private Label titleLabel, priceLabel, leftLabel;
        private Image image;
        private DockPanel panel;

        public GridCell(T data): base()
        {
            panel = new DockPanel();

            titleLabel = new Label();
            priceLabel = new Label();
            leftLabel = new Label();
            image = new Image();

            titleLabel.Content = data.TitleLabel;
            priceLabel.Content = data.PriceLabel;
            leftLabel.Content = data.LeftLabel;

            titleLabel.Width = this.Width;
            titleLabel.FontSize = 21;
            priceLabel.Width = this.Width;

            image.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            image.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            image.Source = new BitmapImage(new Uri(Path.Combine("../../content/images", data.ImagePath), UriKind.Relative));

            panel.Children.Add(titleLabel);
            panel.Children.Add(priceLabel);
            panel.Children.Add(leftLabel);
            panel.Children.Add(image);

            this.AddChild(panel);
        }
    }
}
