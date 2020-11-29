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
using System.Data.Entity;

namespace MiapoPracticProjectGAN.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        ganMiapodbEntities dbconnect = new ganMiapodbEntities();
        int check;
        public EmployeeWindow()
        {
            InitializeComponent(); GridTable.ItemsSource = dbconnect.Employees.ToList();

        }
        private void GridTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employees POS = GridTable.SelectedItem as Employees;

            if (POS != null)
            {
                check = dbconnect.Employees.Where(w => w.Firstname == POS.Firstname && w.LastName == POS.LastName).Select(s => s.id).FirstOrDefault();
            }
            else
            {
                check = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeMoreInfo wd = new EmployeeMoreInfo();
            wd.idEmp = check;
            wd.lvl = 1;
            wd.infobd();
            wd.checer();
            wd.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EmployeeMoreInfo wd = new EmployeeMoreInfo();
            wd.idEmp = check;
            wd.lvl = 0;
            wd.infobd();
            wd.checer();
            wd.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ShipmentWindow mw = new ShipmentWindow();
            this.Hide();
            mw.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.Show();
        }
    }
}
