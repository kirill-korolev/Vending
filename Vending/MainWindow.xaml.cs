using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vending
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private Config config;
        private IEmulationWindow emulationWindow;

        public MainWindow()
        {
            InitializeComponent();
            config = new Config(this, "Vending Machine", 960, 540);
            config.AddProperty<int>(x => this.MinWidth = x, 768);
            config.AddProperty<int>(x => this.MinHeight = x, 432);

            RenderGrid<Product>(ProductsGrid, "products.json", 150);

            //emulationWindow = new IEmulationWindow();
            //emulationWindow.Show();
            //emulationWindow.Activate();
        }

        public void RenderGrid<T>(Grid grid, string fileName, int rowHeight) where T: IGridRendered
        {
            Wrapper<T> data = JsonParser.Read<T>(fileName);
            int columns = grid.ColumnDefinitions.Count;

            for (int i = 0, row = 0, col = 0; i < data.Count;
                i++, col = (col + 1) % columns, row = i / columns)
            {
                if (i % columns == 0)
                {
                    RowDefinition rowDefinition = new RowDefinition();
                    rowDefinition.Height = new GridLength(1, GridUnitType.Star);
                    grid.RowDefinitions.Add(rowDefinition);                    
                }
                
                GridCell<T> cell = new GridCell<T>(data[i]);

                Grid.SetRow(cell, row);
                Grid.SetColumn(cell, col);
                grid.Children.Add(cell);
            }

        }
    }

}
