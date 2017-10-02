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
        private readonly List<int> cash;
        private double aspectRatio = 0.5;

        public delegate void CashInserted(int banknote);
        public event CashInserted CashInsertedEvent;

        public IEmulationWindow()
        {
            InitializeComponent();
            Init();

            CashAcceptor.Init("cash-acceptor-interface.json");

            cash = CashAcceptor.CashSupported;
        }

        public void Init()
        {
            double width = 270;
            double height = width / aspectRatio;

            Config.Init(this, "Cash Acceptor Emulator", width, height, minWidth: width, minHeight: height);
        }

        public void RenderButtons(DockPanel panel, List<int> list)
        {
            double height = panel.ActualHeight / list.Count;

            foreach(var obj in list)
            {
                Button btn = new Button();
                btn.Content = String.Concat(obj, " RUB");
                btn.Height = height;
                btn.Click += OnClickCallback;
                DockPanel.SetDock(btn, Dock.Top);
                panel.Children.Add(btn);
            } 
        }

        public void OnLoadCallback(object sender, EventArgs e)
        {
            IEmulationWindow window = sender as IEmulationWindow;
            RenderButtons(window?.Panel, cash);
        }

        public void OnResizeCallback(object sender, SizeChangedEventArgs e)
        {
            if (e.WidthChanged) this.Width = e.NewSize.Height * aspectRatio;
            else this.Height = e.NewSize.Width / aspectRatio;

            double height = Panel.ActualHeight / Panel.Children.Count;

            foreach (Button obj in Panel.Children)
            {
                obj.Height = height;
            }
        }

        public void OnClickCallback(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            int index = Panel.Children.IndexOf(btn);
            int banknote = cash[index];
            CashInsertedEvent?.Invoke(banknote);
        }
    }
}
