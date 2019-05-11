using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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
using TeamProject.Entities;
using TeamProject.Models;

namespace TeamProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public string Email { get; set; }
        private EFContext _context;
        private User _tmp;
        private ObservableCollection<UserModel> _usersList;
        private List<CarModel> _carsList, _clientsCL;
        private List<BrokModel> _brokList;
        public ClientWindow()
        {
            InitializeComponent();
            _context = new EFContext();
            Email = TeamProject.LoginWindow.LogName;
            _tmp = _context.Users.Where(u => u.Email == Email).First();
        }

        public void DB_Load()
        {
            try
            {
                _usersList = new ObservableCollection<UserModel>(
                    _context.Users.Select(u => new UserModel()
                    {
                        ID = u.ID,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        Password = u.Password
                    }).ToList());

                _carsList = new List<CarModel>(
                    _context.Autos.Select(c => new CarModel()
                    {
                        ID = c.ID,
                        Brand = c.Brand,
                        GraduationYear = c.GraduationYear,
                        VIN = c.VIN,
                        StateNumber = c.StateNumber,
                        BrokerId = (int)c.BrokerId,
                        UserId = (int)c.UserId
                    }).ToList());

                _brokList = new List<BrokModel>(
                    _context.Brokers.Select(b => new BrokModel()
                    {
                        ID = b.ID,
                        FirstName = b.FirstName,
                        LastName = b.LastName,
                        Email = b.Email,
                        Password = b.Password
                    }).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CU_Load()
        {
            _clientsCL = new List<CarModel>(
                _context.Autos.Select(c => new CarModel()
                {
                    ID = c.ID,
                    Brand = c.Brand,
                    GraduationYear = c.GraduationYear,
                    VIN = c.VIN,
                    StateNumber = c.StateNumber,
                    UserId = (int)c.UserId
                }).Where(c => c.UserId == _tmp.ID));
            dgCarsUser.ItemsSource = _clientsCL.Select(i => new CUModel()
            {
                Brand = i.Brand,
                StateNumber = i.StateNumber
            });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Registration.Focus();
            lblUserHistTitle.Content = _tmp.FirstName + " " + _tmp.LastName;
            CU_Load();
            txtUserFName.Text = _tmp.FirstName;
            txtUserLName.Text = _tmp.LastName;
            txtUserEmail.Text = _tmp.Email;
            txtUserPass.Password = _tmp.Password;
        }

        private void SelectionChanged_Car(object sender, SelectionChangedEventArgs e)
        {
            txtCarYear.Text = _clientsCL.Where(i => i.StateNumber == (dgCarsUser.SelectedItem as CUModel).StateNumber).First().GraduationYear;
            txtCarVin.Text = _clientsCL.Where(i => i.StateNumber == (dgCarsUser.SelectedItem as CUModel).StateNumber).First().VIN;
        }

        private void BtnAddCar_Click(object sender, RoutedEventArgs e)
        {
            AddCarWindow adwDialog = new AddCarWindow();
            adwDialog.ShowDialog();
            _context.Autos.Add(new Car()
            {
                Brand = adwDialog.Brand,
                GraduationYear = adwDialog.GradYear,
                VIN = adwDialog.VIN,
                StateNumber = adwDialog.StNum,
                UserId = _tmp.ID
            });
            _context.SaveChanges();
            MessageBox.Show("car added");
            CU_Load();
        }

        private void BtnSetBrok_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("тут мала бути форма роботи з broker");
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            _tmp.FirstName = txtUserFName.Text;
            _tmp.LastName = txtUserLName.Text;
            _tmp.Email = txtUserEmail.Text;
            _tmp.Password = txtUserPass.Password;
            _context.SaveChanges();
            MessageBox.Show("data changed");
            this.Close();
        }

        private void wrt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("хто хоче допиляти?");
            Excl.WriteToExcel();
        }
    }
}
