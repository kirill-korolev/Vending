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
        private IEmulationWindow emulationWindow;

        private Cashier cashier;
        private VMachine machine;

        private Renderer<Product> renderer;

        public MainWindow()
        {
            InitializeComponent();
            Init();

            machine = new VMachine();
            machine.LoadProducts("products.json");
            machine.LoadStorage("storage.json");

            renderer = new Renderer<Product>();
            renderer.OnGridCellClick += OnGridCellClickCallback<Product>;
            renderer.RenderGrid(ProductsGrid, machine.Products);

            cashier = new Cashier();
            UpdateCreditLabel();

            this.Show();
            emulationWindow.Show();
        }

        public void Init()
        {
            Config.Init(this, "Vending Machine", width: 960, height: 540, minWidth: 768, minHeight: 432);

            emulationWindow = new IEmulationWindow();
            emulationWindow.CashInsertedEvent += OnCashInsertedCallBack;

            WindowLocator.Center(this, emulationWindow, 50);
        }

        public void OnLoadCallback()
        {
            
        }

        public void OnGridCellClickCallback<T>(object sender, EventArgs e) where T: IGridRendered
        {
            var gridCell = sender as GridCell<T>;

            try
            {
                cashier.Buy<T>(gridCell.Data as ISellable);
            }
            catch(Cashier.CashierException exc)
            {
                MessageBox.Show(exc.Message);
            }
            
            UpdateCreditLabel();
        }

        public void OnCashInsertedCallBack(int banknote)
        {
            cashier.Add(banknote);
            machine.Insert(banknote);
            UpdateCreditLabel();
        }


        public void UpdateCreditLabel()
        {
            CreditLabel.Content = String.Concat("Credit: ", String.Concat(cashier.Credit, " RUB"));
        }
    }

}
