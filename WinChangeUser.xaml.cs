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

namespace Praktika
{
    /// <summary>
    /// Логика взаимодействия для WinChangeUser.xaml
    /// </summary>
    public partial class WinChangeUser : Window
    {
        public WinChangeUser(UserData userData)
        {
            InitializeComponent();
            var office = Helper.GetContext().Offices.ToList();
            office.Insert(0, new Offices() { Title = "Все группы" });
            CBOFF.ItemsSource = office;
            CBOFF.IsEnabled = false;
            TBEmailAdd.IsEnabled = false;
            TBFName.IsEnabled = false;
            TBLName.IsEnabled = false;
            DataContext = userData;
            TBEmailAdd.Text = userData.Email;
            TBFName.Text = userData.Name;
            TBLName.Text = userData.Surname;
            CBOFF.SelectedValue = userData.Offices;
            CBOFF.SelectedValue = userData.Offices;
            if (userData.Roles == 1)
            {
                RBAdmin.IsChecked = true;
            }
            else
            {
                RBUser.IsChecked = true;
            }

        }

        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            var userData = DataContext as UserData;

            if (RBAdmin.IsChecked == true)
            {
                userData.Roles = 1;
            }
            else
            {
                userData.Roles = 2;
            }
            Helper.GetContext().SaveChanges();
            MessageBox.Show("Данные изменены");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
