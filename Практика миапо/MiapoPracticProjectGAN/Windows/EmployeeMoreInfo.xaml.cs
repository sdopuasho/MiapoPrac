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

namespace MiapoPracticProjectGAN.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeMoreInfo.xaml
    /// </summary>
    public partial class EmployeeMoreInfo : Window
    {
        ganMiapodbEntities dbconnect = new ganMiapodbEntities();
        public int idEmp,lvl;
        public EmployeeMoreInfo()
        {
            InitializeComponent();
            
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
        public void infobd()
        {
            var information = dbconnect.Employees.Where(w => w.id == idEmp).FirstOrDefault();
            FirstNTxt.Text = information.Firstname;
            LastNTxt.Text = information.LastName;
            MiddleNTxt.Text = information.MiddleName;
            EmailTxt.Text = information.Email;
            Phone.Text = information.ContactNumber;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public bool testSave(int id, string first, string last, string middle, string mail, string phone)
        {
            if (first == "" || last == "" || middle == "" || mail == "" || phone == "")
            {
                return false;
            }
            else
            {
                var update = dbconnect.Employees.Where(w => w.id == id).FirstOrDefault();
                update.Firstname = first;
                update.LastName = last;
                update.MiddleName = middle;
                update.Email = mail;
                update.ContactNumber = phone;
                dbconnect.SaveChanges();
                return true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            testSave(idEmp, FirstNTxt.Text, LastNTxt.Text, MiddleNTxt.Text, EmailTxt.Text, Phone.Text);
        }
    }
}
