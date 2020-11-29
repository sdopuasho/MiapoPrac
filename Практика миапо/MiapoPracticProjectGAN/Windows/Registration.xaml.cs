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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        ganMiapodbEntities dbconnect = new ganMiapodbEntities();
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(LoginTxt.Text == "" && PasswordTxt.Text == "" && FirstNameTxt.Text == "" && LastNameTxt.Text == "" && MiddleNameTxt.Text == "" && EmailTxt.Text == "" && PhoneTxt.Text == "")
            {
                MessageBox.Show("Нужно заполнить все поля");
            }
            else if (LoginTxt.Text != "" && PasswordTxt.Text != "" && FirstNameTxt.Text == "" && LastNameTxt.Text == "" && MiddleNameTxt.Text == "" && EmailTxt.Text == "" && PhoneTxt.Text == "")
            {

                MessageBox.Show("Нужно заполнить все поля");
            }
            else if (LoginTxt.Text != "" && PasswordTxt.Text != "" && FirstNameTxt.Text != "" && LastNameTxt.Text == "" && MiddleNameTxt.Text == "" && EmailTxt.Text == "" && PhoneTxt.Text == "")
            {

                MessageBox.Show("Нужно заполнить все поля");
            }
            else if (LoginTxt.Text != "" && PasswordTxt.Text != "" && FirstNameTxt.Text != "" && LastNameTxt.Text != "" && MiddleNameTxt.Text == "" && EmailTxt.Text == "" && PhoneTxt.Text == "")
            {

                MessageBox.Show("Нужно заполнить все поля");
            }
            else if (LoginTxt.Text != "" && PasswordTxt.Text != "" && FirstNameTxt.Text != "" && LastNameTxt.Text != "" && MiddleNameTxt.Text != "" && EmailTxt.Text == "" && PhoneTxt.Text == "")
            {

                MessageBox.Show("Нужно заполнить все поля");
            }
            else if (LoginTxt.Text != "" && PasswordTxt.Text != "" && FirstNameTxt.Text != "" && LastNameTxt.Text != "" && MiddleNameTxt.Text != "" && EmailTxt.Text != "" && PhoneTxt.Text == "")
            {
                MessageBox.Show("Нужно заполнить все поля");
            }
            else if (LoginTxt.Text == "" && PasswordTxt.Text != "" && FirstNameTxt.Text == "" && LastNameTxt.Text == "" && MiddleNameTxt.Text == "" && EmailTxt.Text == "" && PhoneTxt.Text == "")
            {

                MessageBox.Show("Нужно заполнить все поля");
            }
            else if (LoginTxt.Text == "" && PasswordTxt.Text == "" && FirstNameTxt.Text != "" && LastNameTxt.Text == "" && MiddleNameTxt.Text == "" && EmailTxt.Text == "" && PhoneTxt.Text == "")
            {

                MessageBox.Show("Нужно заполнить все поля");
            }
            else if (LoginTxt.Text == "" && PasswordTxt.Text == "" && FirstNameTxt.Text == "" && LastNameTxt.Text != "" && MiddleNameTxt.Text == "" && EmailTxt.Text == "" && PhoneTxt.Text == "")
            {

                MessageBox.Show("Нужно заполнить все поля");
            }
            else if (LoginTxt.Text == "" && PasswordTxt.Text == "" && FirstNameTxt.Text == "" && LastNameTxt.Text == "" && MiddleNameTxt.Text != "" && EmailTxt.Text == "" && PhoneTxt.Text == "")
            {

                MessageBox.Show("Нужно заполнить все поля");
            }
            else if (LoginTxt.Text == "" && PasswordTxt.Text == "" && FirstNameTxt.Text == "" && LastNameTxt.Text == "" && MiddleNameTxt.Text == "" && EmailTxt.Text != "" && PhoneTxt.Text == "")
            {

                MessageBox.Show("Нужно заполнить все поля");
            }
            else 
            {
                testing(LastNameTxt.Text, FirstNameTxt.Text, MiddleNameTxt.Text, EmailTxt.Text, LoginTxt.Text, PasswordTxt.Text, PhoneTxt.Text);
            }
        }
        public bool testing(string lnm, string fnm, string mnm, string email, string login ,string password, string contactphone)
        {
            Employees EmployeesToadd = new Employees()
            {
                Firstname = FirstNameTxt.Text,
                LastName = LastNameTxt.Text,
                MiddleName = MiddleNameTxt.Text,
                ContactNumber = PhoneTxt.Text,
                Email = EmailTxt.Text,
                Login = LoginTxt.Text,
                Password = PasswordTxt.Text
            };
            dbconnect.Employees.Add(EmployeesToadd);
            dbconnect.SaveChanges();
            return true;
        }
    }
}
