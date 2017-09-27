using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Vending
{
    public class Renderer<T> where T: IGridRendered
    {

        public event MouseButtonEventHandler OnGridCellClick;

        public Renderer()
        {

        }

        public void RenderGrid(Grid grid, Wrapper<T> data)
        {

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
                cell.MouseDoubleClick += OnGridCellClickCallback;

                Grid.SetRow(cell, row);
                Grid.SetColumn(cell, col);
                grid.Children.Add(cell);
            }

        }

        public void OnGridCellClickCallback(object sender, MouseButtonEventArgs e)
        {
            OnGridCellClick.Invoke(sender, e);
        }
    }
}
