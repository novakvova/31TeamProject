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
using TeamProject.Entities;

namespace TeamProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //EFContext ef = new EFContext();
            //ef.Autos.Add(new Car { ID = 1, Brand = "a", BrokerId = 1, UserId = 1, VIN = "a", StateNumber = "a", GraduationYear = "a" });
            //ef.Brokers.Add(new Broker { ID = 1, FirstName = "a", LastName = "a", Email = "a", Password = "a" });
            //ef.Users.Add(new User { ID = 1, FirstName = "a", LastName = "a", Email = "a", Password = "a" });
            //ef.SaveChanges();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow dlg = new LoginWindow();
            dlg.ShowDialog();
        }

        private void BtnSignup_Click(object sender, RoutedEventArgs e)
        {
            SignUp dlg = new SignUp();
            dlg.ShowDialog();
        }

        private void wrt_Click(object sender, RoutedEventArgs e)
        {
            Excl.WriteToExcel();
        }
    }
}
