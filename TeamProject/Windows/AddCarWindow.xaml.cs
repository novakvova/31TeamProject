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

namespace TeamProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        public int CarID { get; set; }
        public string Brand { get; set; }
        public string GradYear { get; set; }
        public string VIN { get; set; }
        public string StNum { get; set; }

        public AddCarWindow()
        {
            InitializeComponent();
        }

        private void BtnCarSubmit_Click(object sender, RoutedEventArgs e)
        {
            Brand = txtCarBrand.Text;
            GradYear = txtCarYear.Text;
            VIN = txtCarVin.Text;
            StNum = txtCarNum.Text;
            this.Close();
        }

        private void BtnCarCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelectionChanged_Text(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCarBrand.Text))
            {
                if (!string.IsNullOrEmpty(txtCarYear.Text))
                {
                    if (!string.IsNullOrEmpty(txtCarVin.Text))
                    {
                        if (!string.IsNullOrEmpty(txtCarNum.Text))
                        {
                            btnCarSubmit.IsEnabled = true;
                        }
                    }
                }
            }
        }
    }
}
