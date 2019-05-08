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
