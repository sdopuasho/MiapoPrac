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
    /// Логика взаимодействия для ShipmentMoreInfo.xaml
    /// </summary>
    public partial class ShipmentMoreInfo : Window
    { ganMiapodbEntities dbconnect = new ganMiapodbEntities();
        public int id, lvl, origWar;
        public string origNamePro;
        public ShipmentMoreInfo()
        {
            InitializeComponent(); 
        }
        public void infobd()
        {
            var information = dbconnect.ProductOnShipment.Include(i => i.Products).Include(i => i.ShipmentEmployee).Include(i => i.ShipmentEmployee.Warehouse).Where(w => w.id == this.id).FirstOrDefault();
            ProductTxt.Text = information.Products.Name;
            QuantityTxt.Text = information.QuantityOfShipment.ToString();
            WarehouseTxt.Text = information.ShipmentEmployee.Warehouse.Number.ToString();
            origWar = information.ShipmentEmployee.Warehouse.Number;
            origNamePro = information.Products.Name;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        public void checer()
        {

            if (lvl == 0)
            {
                Upd.Visibility = Visibility.Hidden;
            }
            else
            {
                Upd.Visibility = Visibility.Visible;
            }
        }
        public  bool Loadtobd(int Originalwarahouse, int warehousetxt, string producted)
        {
            if (Originalwarahouse < 1 || warehousetxt < 1 || producted == "")
            {
                return false;
            }
            else
            {
                int idwarehouse = dbconnect.Warehouse.Where(w => w.Number == warehousetxt).Select(s => s.id).FirstOrDefault();
                var upd = dbconnect.ShipmentEmployee.Where(w => w.FK_Warehouse_id == Originalwarahouse).FirstOrDefault();
                upd.FK_Warehouse_id = warehousetxt;
                dbconnect.SaveChanges();
                int idsho = dbconnect.ShipmentEmployee.Where(w => w.FK_Warehouse_id == Originalwarahouse).Select(s => s.id).FirstOrDefault();
                int idprod = dbconnect.Products.Where(w => w.Name == producted).Select(s => s.id).FirstOrDefault();
                var upd2 = dbconnect.ProductOnShipment.Where(w => w.id ==1).FirstOrDefault();
                upd2.FK_ShipmentEmployee = idsho;
                upd2.FK_Product_id = idprod;
                dbconnect.SaveChanges();
                return true;
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Loadtobd(origWar, Convert.ToInt32(WarehouseTxt.Text), ProductTxt.Text);
        }
    }
}
