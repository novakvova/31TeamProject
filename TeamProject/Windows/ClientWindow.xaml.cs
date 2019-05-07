using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public string _conStr = "Data Source=karaka123.mssql.somee.com;User ID=gmirakivan_SQLLogin_1;Password=8b1m2f1gnt";
        private EFContext _context;
        private ObservableCollection<UserModel> usersList;
        private List<CarModel> carsList;
        public ClientWindow()
        {
            InitializeComponent();
            _context = new EFContext();

            usersList = new ObservableCollection<UserModel>();
            usersList.Add(new UserModel() { ID = 1, FirstName = "q", LastName = "w", Email = "q@q.com" });
            usersList.Add(new UserModel() { ID = 2, FirstName = "a", LastName = "s", Email = "a@a.com" });
            carsList = new List<CarModel>();
            carsList.Add(new CarModel() { ID = 1, Brand = "audi", GraduationYear = "1234", VIN = "4321", StateNumber = "1234" });
            carsList.Add(new CarModel() { ID = 2, Brand = "bmw", GraduationYear = "4567", VIN = "7654", StateNumber = "4567" });

            DB_Load();
        }

        public void DB_Load()
        {
            
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

        private void SelectionChanged_Item(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("ok");
            Settings.Focus();
            lblUserTitle.Content = (dgUsers.SelectedItem as UserModel).FirstName + " " + (dgUsers.SelectedItem as UserModel).LastName;
            txtUserFName.Text = (dgUsers.SelectedItem as UserModel).FirstName;
            txtUserLName.Text = (dgUsers.SelectedItem as UserModel).LastName;
            txtUserEmail.Text = (dgUsers.SelectedItem as UserModel).Email;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("save");
        }
    }
}
