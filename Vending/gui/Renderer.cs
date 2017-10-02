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
    public class Renderer<T> where T: class, IGridRendered
    {

        public event MouseButtonEventHandler OnGridCellClick;

        public Renderer()
        {

        }

        public void RenderGrid(Grid grid, List<T> data)
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
                ActiveCheck(cell);

                Grid.SetRow(cell, row);
                Grid.SetColumn(cell, col);
                grid.Children.Add(cell);
            }

        }

        public void UpdateCell(GridCell<IGridRendered> cell, IGridRendered data)
        {
            cell.Update(data as T);
        }

        public void HandleGrid(Grid grid)
        {           
            foreach(GridCell<T> cell in grid.Children)
            {
                double width = cell.ActualWidth;
                double k = 0.5;
                cell.Image.Width = width * k;
                cell.Image.Height = width * k;
            }
        }

        public void UpdateGrid(Grid grid)
        {
            foreach(GridCell<T> cell in grid.Children)
                ActiveCheck(cell);
        }

        public void ActiveCheck(GridCell<T> cell)
        {
            cell.MouseDoubleClick -= OnGridCellClickCallback;
            if (cell.Data.Active) cell.MouseDoubleClick += OnGridCellClickCallback;
            else cell.Opacity = 0.5;
        }

        public void OnGridCellClickCallback(object sender, MouseButtonEventArgs e)
        {
            OnGridCellClick.Invoke(sender, e);
        }
    }
}
