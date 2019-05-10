using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TeamProject.Entities;
using TeamProject.Models;

namespace TeamProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        #region localization

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
            //Tabs.
        }

        #endregion
        ///public string _conStr = "Data Source=karaka123.mssql.somee.com;User ID=gmirakivan_SQLLogin_1;Password=8b1m2f1gnt";
        private EFContext _context;
        private ObservableCollection<UserModel> usersList;
        private List<CarModel> carsList, clientsCL, brokersBL;
        public ClientWindow()
        {
            InitializeComponent();
            _context = new EFContext();

            usersList = new ObservableCollection<UserModel>();
            usersList.Add(new UserModel() { ID = 1, FirstName = "q", LastName = "w", Email = "q@q.com", Password = "1234", Status = "client" });
            usersList.Add(new UserModel() { ID = 2, FirstName = "a", LastName = "s", Email = "a@a.com", Status = "broker" });
            carsList = new List<CarModel>();
            carsList.Add(new CarModel() { ID = 1, Brand = "audi", GraduationYear = "1234", VIN = "4321", StateNumber = "1234", ClientID = 1 });
            carsList.Add(new CarModel() { ID = 2, Brand = "bmw", GraduationYear = "4567", VIN = "7654", StateNumber = "4567", ClientID = 1 });
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
            dgUsers.ItemsSource = usersList;
            dgCars.ItemsSource = carsList;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUI();
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
            History.Focus();
            lblUserHistTitle.Content = (dgUsers.SelectedItem as UserModel).FirstName + " " + (dgUsers.SelectedItem as UserModel).LastName;
            clientsCL = new List<CarModel>(
                carsList.Select(c => new CarModel()
                {
                    Brand = c.Brand,
                    StateNumber = c.StateNumber
                }).Where(c => c.ClientID == (dgUsers.SelectedItem as UserModel).ID)
                .ToList());
            dgCarsUser.ItemsSource = clientsCL;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("save");
        }
    }
}
