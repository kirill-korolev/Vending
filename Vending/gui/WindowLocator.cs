using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Vending
{
    public static class WindowLocator
    {
        public static void Center(Window window)
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = window.Width;
            double windowHeight = window.Height;
            window.Left = (screenWidth / 2) - (windowWidth / 2);
            window.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        public static void Center(Window lhs, Window rhs, double margin)
        {

            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;

            double lhsWidth = lhs.Width;
            double lhsHeight = lhs.Height;

            double rhsWidth = rhs.Width;
            double rhsHeight = rhs.Height;

            double width = lhsWidth + margin + rhsWidth;
            double left = (screenWidth / 2) - (width / 2);

            lhs.Left = left;
            lhs.Top = (screenHeight / 2) - (lhsHeight / 2);

            rhs.Left = left + lhsWidth + margin;
            rhs.Top = (screenHeight / 2) - (rhsHeight / 2);
        }
    }
}
