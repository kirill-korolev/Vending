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

        private Renderer<IGridRendered> renderer;

        public MainWindow()
        {
            InitializeComponent();
            Init();

            machine = new VMachine();
            machine.LoadProducts("products.json");
            machine.LoadStorage("storage.json");

            renderer = new Renderer<IGridRendered>();
            renderer.OnGridCellClick += OnGridCellClickCallback;


            renderer.RenderGrid(ProductsGrid, machine.Products.Wrapped.Cast<IGridRendered>().ToList());

            cashier = new Cashier(machine.Storage);
            cashier.OnChangeReturnCallback += OnReturnChangeCallback;

            UpdateCreditLabel();

            this.Show();
            emulationWindow.Show();
        }

        private void Init()
        {
            Config.Init(this, "Vending Machine", width: 960, height: 540, minWidth: 768, minHeight: 432);

            emulationWindow = new IEmulationWindow();
            emulationWindow.CashInsertedEvent += OnCashInsertedCallBack;

            WindowLocator.Center(this, emulationWindow, 50);
        }

        private void OnLoadCallback(object sender, EventArgs e)
        {
            renderer.HandleGrid(ProductsGrid);
        }

        private void OnCloseCallback(object sender, EventArgs e)
        {
            machine.PreserveProducts("products.json");
            machine.PreserveStorage("storage.json");
            emulationWindow.Close();
        }

        private void OnGridCellClickCallback(object sender, EventArgs e)
        {
            var gridCell = sender as GridCell<IGridRendered>;

            try
            {
                ISellable sellable = gridCell.Data as ISellable;

                if (cashier.CheckPurchase(sellable))
                {
                    machine.UpdateProducts(sellable);
                    cashier.SubmitPurchase(sellable);
                }
                
                renderer.UpdateCell(gridCell, gridCell.Data);
            }
            catch(Cashier.CashierException exc)
            {
                MessageBox.Show(exc.Message);
            }
            catch(VMachine.VMachineException exc)
            {
                MessageBox.Show(exc.Message);
            }

            renderer.UpdateGrid(ProductsGrid);
            UpdateCreditLabel();
        }

        private void OnCashInsertedCallBack(int banknote)
        {
            cashier.Add(banknote);
            machine.UpdateStorage(banknote);
            UpdateCreditLabel();
        }

        private void OnChangeButtonClickCallback(object sender, EventArgs e)
        {
            cashier.Change(cashier.Credit);
        }

        private void OnReturnChangeCallback(bool success, List<ChangeEngine.Change> info)
        {
            if (!success)
                MessageBox.Show("Unfortunately, the change cannot be returned");
            else
            {
                string s = "Your change \n";

                foreach(var o in info)
                {
                    s += "coin: " + o.Coin + " amount: " + o.Amount + "\n";
                }

                MessageBox.Show(s);
                cashier.Reset();
                UpdateCreditLabel();
            }
        }

        private void UpdateCreditLabel()
        {
            CreditLabel.Content = String.Concat("Credit: ", String.Concat(cashier.Credit, " RUB"));
        }
    }

}
