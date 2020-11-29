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
using System.Data.Entity;

namespace MiapoPracticProjectGAN
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ganMiapodbEntities dbconnect = new ganMiapodbEntities();
        public int lvlaccess;
        int check;
        public MainWindow()
        {
            InitializeComponent();
            GridTable.ItemsSource = dbconnect.ProductOnShipment.Include(i => i.Products).Include(i => i.ShipmentEmployee).Include(i => i.ShipmentEmployee.Warehouse).ToList();
            if(lvlaccess == 0)
            {

            }
            else
            {

            }
        }

        private void GridTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductOnShipment POS = GridTable.SelectedItem as ProductOnShipment;

            if (POS != null)
            {
                check = dbconnect.ProductOnShipment.Include(i => i.Products).Include(i => i.ShipmentEmployee).Include(i => i.ShipmentEmployee.Warehouse).Where(w=>w.Products.Name == POS.Products.Name && w.QuantityOfShipment == POS.QuantityOfShipment && w.ShipmentEmployee.Warehouse.Number == POS.ShipmentEmployee.Warehouse.Number && w.ShipmentEmployee.Warehouse.Quantity == POS.ShipmentEmployee.Warehouse.Quantity).Select(s=>s.id).FirstOrDefault();
            }
            else
            {
                check = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Windows.ShipmentWindow mw = new Windows.ShipmentWindow();
            this.Hide();
            mw.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.EmployeeWindow mw = new Windows.EmployeeWindow();
            this.Hide();
            mw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Windows.MainWindowMoreInfo wd = new Windows.MainWindowMoreInfo();
            wd.id = check;
            wd.lvl = 1;
            wd.infoofbd();
            wd.checer();
            wd.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Windows.MainWindowMoreInfo wd = new Windows.MainWindowMoreInfo();
            wd.id = check;
            wd.lvl = 0;
            wd.infoofbd();
            wd.checer();
            wd.ShowDialog();
        }
    }
}
//Просмотр информации о

//сотрудниках или

//продукции


//Изменение данных о

//сотруднике или

//продукции


//Просмотр или изменение

//информации о поставке 