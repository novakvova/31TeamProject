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
        //public int UserID { get; set; }
        //public string Fname { get; set; }
        //public string Lname { get; set; }
        public string Email { get; set; }
        ///public string _conStr = "Data Source=karaka123.mssql.somee.com;User ID=gmirakivan_SQLLogin_1;Password=8b1m2f1gnt";
        private EFContext _context;
        private User _tmp;
        private ObservableCollection<UserModel> _usersList;
        private List<CarModel> _carsList, _clientsCL;
        private List<BrokModel> _brokList, _brokersBL;
        public ClientWindow()
        {
            InitializeComponent();
            _context = new EFContext();
            #region
            //_usersList = new ObservableCollection<UserModel>();
            //_usersList.Add(new UserModel()
            //{
            //    ID = 1,
            //    FirstName = "q",
            //    LastName = "w",
            //    Email = "q@q.com",
            //    Password = "1234",
            //    Status = "client"
            //});
            //_usersList.Add(new UserModel()
            //{
            //    ID = 2,
            //    FirstName = "a",
            //    LastName = "s",
            //    Email = "a@a.com",
            //    Status = "broker"
            //});
            //_carsList = new List<CarModel>();
            //_carsList.Add(new CarModel()
            //{
            //    ID = 1,
            //    Brand = "audi",
            //    GraduationYear = "1234",
            //    VIN = "4321",
            //    StateNumber = "1234",
            //    ClientID = 1
            //});
            //_carsList.Add(new CarModel()
            //{
            //    ID = 2,
            //    Brand = "bmw",
            //    GraduationYear = "4567",
            //    VIN = "7654",
            //    StateNumber = "4567",
            //    ClientID = 1
            //});

            //clientsCL = new List<CarModel>(
            //    carsList.Select(c => new CarModel()
            //    {
            //        Brand = c.Brand,
            //        StateNumber = c.StateNumber
            //    }).Where(c => c.ClientID == 1).ToList());
            #endregion
            DB_Load();
            //_tmp = _context.Users.Where(u => u.Email == Email).First();
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
            
            //dgUsers.ItemsSource = _usersList;
            //dgCars.ItemsSource = _carsList;
        }

        public void CU_Load()
        {
            _clientsCL = new List<CarModel>(
                _carsList.Select(c => new CarModel()
                {
                    ID = c.ID,
                    Brand = c.Brand,
                    GraduationYear = c.GraduationYear,
                    VIN = c.VIN,
                    StateNumber = c.StateNumber,
                    BrokerId = (int)c.BrokerId,
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
            //MessageBox.Show("ok");
            #region Settings.Focus()
            //Settings.Focus();
            //lblUserSetTitle.Content = (dgUsers.SelectedItem as UserModel).FirstName + " " + (dgUsers.SelectedItem as UserModel).LastName;
            //txtUserFName.Text = (dgUsers.SelectedItem as UserModel).FirstName;
            //txtUserLName.Text = (dgUsers.SelectedItem as UserModel).LastName;
            //txtUserEmail.Text = (dgUsers.SelectedItem as UserModel).Email;
            //txtUserPass.Password = (dgUsers.SelectedItem as UserModel).Password;
            #endregion

            Registration.Focus();
            _tmp = _context.Users.Where(u => u.Email == Email).First();
            lblUserHistTitle.Content = _tmp.FirstName + " " + _tmp.LastName;
            CU_Load();
        }

        //private void SelectionChanged_Item(object sender, SelectionChangedEventArgs e)
        //{
        //    //MessageBox.Show("ok");
        //    #region Settings.Focus()
        //    //Settings.Focus();
        //    //lblUserSetTitle.Content = (dgUsers.SelectedItem as UserModel).FirstName + " " + (dgUsers.SelectedItem as UserModel).LastName;
        //    //txtUserFName.Text = (dgUsers.SelectedItem as UserModel).FirstName;
        //    //txtUserLName.Text = (dgUsers.SelectedItem as UserModel).LastName;
        //    //txtUserEmail.Text = (dgUsers.SelectedItem as UserModel).Email;
        //    //txtUserPass.Password = (dgUsers.SelectedItem as UserModel).Password;
        //    #endregion
            
        //    Registration.Focus();
        //    MessageBox.Show(Email);
        //    UserModel Tmp = _usersList.Where(u => u.Email == Email) as UserModel;
        //    int srcId = _usersList.Where(u => u.Email == txtUserEmail.Text).First().ID;
        //    lblUserHistTitle.Content = Tmp.FirstName + " " + Tmp.LastName;
        //    _clientsCL = new List<CarModel>(
        //        _carsList.Select(c => new CarModel()
        //        {
        //            //ID = c.ID,
        //            Brand = c.Brand,
        //            //GraduationYear = c.GraduationYear,
        //            //VIN = c.VIN,
        //            StateNumber = c.StateNumber,
        //            BrokerId = (int)c.BrokerId,
        //            UserId = (int)c.UserId
        //        }).Where(c => c.UserId == srcId));
        //    //dgCarsUser.ItemsSource = _clientsCL.Select(i => new CUModel()
        //    //{
        //    //    Brand = i.Brand,
        //    //    StateNumber = i.StateNumber
        //    //});

        //}

        private void SelectionChanged_Car(object sender, SelectionChangedEventArgs e)
        {
            txtCarYear.Text = _clientsCL.Where(i => i.StateNumber == (dgCarsUser.SelectedItem as CUModel).StateNumber).First().GraduationYear;
            txtCarVin.Text = _clientsCL.Where(i => i.StateNumber == (dgCarsUser.SelectedItem as CUModel).StateNumber).First().VIN;
        }

        private void BtnAddCar_Click(object sender, RoutedEventArgs e)
        {
            AddCarWindow adwDialog = new AddCarWindow();
            adwDialog.ShowDialog();
            //_tmp = _context.Users.Where(u => u.Email == Email).First();
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
            MessageBox.Show("тут мала бути форма роботи з broker(");
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("save");
        }
    }
}
