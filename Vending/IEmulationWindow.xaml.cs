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
using System.Windows.Shapes;

namespace Vending
{
    /// <summary>
    /// Логика взаимодействия для IEmulationWindow.xaml
    /// </summary>
    public partial class IEmulationWindow : Window
    {
        private Config config;

        public IEmulationWindow()
        {
            InitializeComponent();
            config = new Config(this, "Cash Acceptor Emulator", 300, 150);
        }
    }
}
