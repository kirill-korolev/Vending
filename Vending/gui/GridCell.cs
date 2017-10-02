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
    public class GridCell<T>: DataGridCell where T : IGridRendered
    {
        public Label HeaderLabel { get; private set; }
        public Label DescriptionLabel { get; private set; }
        public Label AdditionalLabel { get; private set; }
        public Image Image { get; private set; }
        public StackPanel Panel { get; private set; }
        public T Data { get; private set; }

        public GridCell(T data) : base()
        {
            Data = data;

            //Initializing components

            Panel = new StackPanel();

            HeaderLabel = new Label();
            DescriptionLabel = new Label();
            AdditionalLabel = new Label();
            Image = new Image();

            //Labels content

            HeaderLabel.Content = data.Header;
            DescriptionLabel.Content = data.Description;
            AdditionalLabel.Content = data.Additional;

            HeaderLabel.FontSize = 16;

            //Components margins

            HeaderLabel.Margin = new System.Windows.Thickness(10);

            //Image configuration

            Image.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Image.VerticalAlignment = System.Windows.VerticalAlignment.Top;

            Image.BeginInit();
            Image.Source = new BitmapImage(new Uri(Path.Combine(Config.ImagesPath, data.ImagePath), UriKind.Relative));
            Image.EndInit();

            //Appending components to panel

            Panel.Children.Add(HeaderLabel);
            Panel.Children.Add(Image);
            Panel.Children.Add(DescriptionLabel);
            Panel.Children.Add(AdditionalLabel);

            this.AddChild(Panel);
        }

        public void Update(T data)
        {
            Data = data;
            AdditionalLabel.Content = Data.Additional;
        }
        
    }
}
