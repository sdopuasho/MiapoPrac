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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        ganMiapodbEntities dbconnect = new ganMiapodbEntities();
        public Autorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Windows.Registration WinPage = new Registration();
            WinPage.ShowDialog();
        }
        public int test(string login, string pass)
        {
            return dbconnect.Employees.Where(w => w.Login == login && w.Password == pass).Select(s => s.id).FirstOrDefault();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (LoginTxt.Text == "" && PasswordPsb.Password == "")
            {
                MessageBox.Show("Поля пусты");
            }
            else if (LoginTxt.Text == "")
            {
                MessageBox.Show("Введите логин");
            }
            else if (PasswordPsb.Password == "")
            {
                MessageBox.Show("Введите пароль");
            }
            else
            {
                string login = LoginTxt.Text, PasswordT = PasswordPsb.Password;
                if ((test(login, PasswordT)) < 1)
                {
                    MessageBox.Show("Пользователя не существует");
                }
                else
                {
                    MainWindow mw = new MainWindow();
                    this.Hide();
                    mw.Show();
                }
            }
            
        }
    }
}
