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
        ///public string _conStr = "Data Source=karaka123.mssql.somee.com;User ID=gmirakivan_SQLLogin_1;Password=8b1m2f1gnt";
        private EFContext _context;
        private ObservableCollection<UserModel> _usersList;
        private List<CarModel> _carsList, _clientsCL, _brokersBL;
        public ClientWindow()
        {
            InitializeComponent();
            _context = new EFContext();

            _usersList = new ObservableCollection<UserModel>();
            _usersList.Add(new UserModel()
            {
                ID = 1,
                FirstName = "q",
                LastName = "w",
                Email = "q@q.com",
                Password = "1234",
                Status = "client"
            });
            _usersList.Add(new UserModel()
            {
                ID = 2,
                FirstName = "a",
                LastName = "s",
                Email = "a@a.com",
                Status = "broker"
            });
            _carsList = new List<CarModel>();
            _carsList.Add(new CarModel()
            {
                ID = 1,
                Brand = "audi",
                GraduationYear = "1234",
                VIN = "4321",
                StateNumber = "1234",
                ClientID = 1
            });
            _carsList.Add(new CarModel()
            {
                ID = 2,
                Brand = "bmw",
                GraduationYear = "4567",
                VIN = "7654",
                StateNumber = "4567",
                ClientID = 1
            });
            
            //clientsCL = new List<CarModel>(
            //    carsList.Select(c => new CarModel()
            //    {
            //        Brand = c.Brand,
            //        StateNumber = c.StateNumber
            //    }).Where(c => c.ClientID == 1).ToList());

            DB_Load();
        }

        public void DB_Load()
        {
            //usersList = new ObservableCollection<UserModel>(
            //    _context.Users.Select(u => new UserModel()
            //    {
            //        UserID = u.UserID,
            //        FirstName = u.FirstName,
            //        LastName = u.LastName,
            //        Email = u.Email,
            //        Password = u.Password
            //    }).ToList());
            try
            {
                //using (SqlConnection con = new SqlConnection(_conStr))
                //{
                //    con.Open();
                //    SqlCommand cmd = new SqlCommand("SELECT [Id],[FirstName]FROM[tblUsers]", con);
                //    SqlDataReader rdr = cmd.ExecuteReader();
                //    if (rdr.Read())
                //    {
                //        MessageBox.Show("ok");
                //    }
                //    con.Close();
                //}

                //usersList = new ObservableCollection<UserModel>(
                //_context.Users.Select(u => new UserModel()
                //{
                //    ID = u.ID,
                //    FirstName = u.FirstName,
                //    LastName = u.LastName,
                //    Email = u.Email,
                //    Password = u.Password
                //}).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            dgUsers.ItemsSource = _usersList;
            dgCars.ItemsSource = _carsList;
        }

        private void SelectionChanged_Item(object sender, SelectionChangedEventArgs e)
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
            lblUserHistTitle.Content = (dgUsers.SelectedItem as UserModel).FirstName + " " + (dgUsers.SelectedItem as UserModel).LastName;
            _clientsCL = new List<CarModel>(
                _carsList.Select(c => new CarModel()
                {
                    ID = c.ID,
                    Brand = c.Brand,
                    GraduationYear = c.GraduationYear,
                    VIN = c.VIN,
                    StateNumber = c.StateNumber,
                    ClientID = c.ClientID
                }).Where(c => c.ClientID == (dgUsers.SelectedItem as UserModel).ID));
            dgCarsUser.ItemsSource = _clientsCL.Select(i => new CUModel()
            {
                Brand = i.Brand,
                StateNumber = i.StateNumber
            });

        }

        private void SelectionChanged_Car(object sender, SelectionChangedEventArgs e)
        {
            txtCarYear.Text = _clientsCL.Where(i => i.StateNumber == (dgCarsUser.SelectedItem as CUModel).StateNumber).First().GraduationYear;
            txtCarVin.Text = _clientsCL.Where(i => i.StateNumber == (dgCarsUser.SelectedItem as CUModel).StateNumber).First().VIN;
        }

        private void BtnAddCar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("add car");
            AddCarWindow adwDialog = new AddCarWindow();
            adwDialog.ShowDialog();
        }

        private void BtnSetBrok_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("broker");
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("save");
        }
    }
}
