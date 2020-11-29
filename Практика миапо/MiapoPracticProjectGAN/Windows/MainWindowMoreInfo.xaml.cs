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
    /// Логика взаимодействия для MainWindowMoreInfo.xaml
    /// </summary>
    public partial class MainWindowMoreInfo : Window
    {
        ganMiapodbEntities dbconnect = new ganMiapodbEntities();
        public int id, quat, lvl;
        public string nameorig;
        public MainWindowMoreInfo()
        {
            InitializeComponent();
            if (lvl == 0)
            {
                Upd.Visibility = Visibility.Hidden;
            }
            else if(lvl ==1)
            {
                Upd.Visibility = Visibility.Visible;
            }
        }
        public void infoofbd()
        {
            var info = dbconnect.ProductOnShipment.Include(i => i.Products).Where(w=>w.id == this.id).FirstOrDefault();
            NameTxt.Text = info.Products.Name;
            QuantityTxt.Text = info.QuantityOfShipment.ToString();
            QuantityTxt_Copy.Text = info.Products.Manufacture;
            nameorig = info.Products.Name;
            quat = info.QuantityOfShipment;
            
        }

        public void checer()
        {
            if (lvl == 0)
            {
                Upd.Visibility = Visibility.Hidden;
            }
            else if (lvl == 1)
            {
                Upd.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public bool testupload(string originalnameproduct, string newnameprod, int quantity, int newquantity)
        {
            string nae = newnameprod;
            if (originalnameproduct == "" || newnameprod == "" || quantity <1 || newquantity < 1)
            {
                return false;
            }
            else
            {
                int prodid = dbconnect.Products.Where(w => w.Name == originalnameproduct).Select(s => s.id).FirstOrDefault();
                var upd = dbconnect.Products.Where(w => w.id == prodid).FirstOrDefault();
                upd.Name = nae;
                dbconnect.SaveChanges();
                var upd2 = dbconnect.ProductOnShipment.Where(w => w.FK_Product_id == prodid && w.QuantityOfShipment == quantity).FirstOrDefault();
                upd2.QuantityOfShipment = newquantity;
                dbconnect.SaveChanges();
                return true;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            testupload(nameorig, NameTxt.Text, quat, Convert.ToInt32(QuantityTxt.Text));
        }
    }
}
