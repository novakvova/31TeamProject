using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TeamProject
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conStr = new SqlConnection(@"Data Source=karaka123.mssql.somee.com; Initial Catalog = karaka123; User ID=gmirakivan_SQLLogin_1; Password=8b1m2f1gnt");
            try
            {
                if (conStr.State == ConnectionState.Closed)
                    conStr.Open();
                String query = "SELECT COUNT(1) FROM tblUsers WHERE Email=@Email AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, conStr);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильний логін або пароль!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conStr.Close();
            }
        }

        private void ChangeLocalizationAndUpdateUA(object sender, RoutedEventArgs e)
        {
            UpdateLocalizationUA();
            UpdateUI();
        }

        private void UpdateLocalizationUA()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk-UA");
        }

        private void ChangeLocalizationAndUpdateENG(object sender, RoutedEventArgs e)
        {
            UpdateLocalizationENG();
            UpdateUI();
        }

        private void UpdateLocalizationENG()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
        }

        private void ChangeLocalizationAndUpdateRU(object sender, RoutedEventArgs e)
        {
            UpdateLocalizationRU();
            UpdateUI();
        }

        private void UpdateLocalizationRU()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
        }

        private void UpdateUI()
        {
            //btnEng.Content = Strings.Eng;
            //btnUkr.Content = Strings.Ukr;
            //btnRus.Content = Strings.Rus;
            //btnSignup.Content = Strings.Signup;
            //btnSubmit.Content = Strings.Submit;
            //lblLogin.Content = Strings.Login;
            //lblUsername.Content = Strings.Username;
            //lblPassword.Content = Strings.Password;
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }
    }
}
