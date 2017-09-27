using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Vending
{
    public static partial class Config
    {
        public static void Init(Window window, string title = "", double width = 0, double height = 0)
        {
            window.Title = title;
            window.Width = width;
            window.Height = height;
        }

        public static void Init(Window window, string title = "", double width = 0, double height = 0, double minWidth = 0, double minHeight = 0)
        {
            Init(window, title, width, height);
            window.MinWidth = minWidth;
            window.MinHeight = minHeight;
        }
    }
}
