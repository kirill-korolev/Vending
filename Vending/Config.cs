using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Vending
{
    public class Config
    {
        public static string Title { get; set; }
        public static int Width { get; set; }
        public static int Height { get; set; }

        public Config(Window window, string title, int width, int height)
        {
            window.Title = title;
            window.Width = width;
            window.Height = height;
        }

        public void AddProperty<T>(Action<T> func, T value)
        {
            func.Invoke(value);
        }
    }
}
