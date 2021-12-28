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
    /// Логика взаимодействия для WinAddUser.xaml
    /// </summary>
    public partial class WinAddUser : Window
    {
        public WinAddUser()
        {
            InitializeComponent();
            var office = Helper.GetContext().Offices.ToList();
            office.Insert(0, new Offices() { Title = "Office name" });
            CmbOffice.ItemsSource = office;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            using (PraktikaEntities db = new PraktikaEntities())
            {
                UserData user = new UserData();
                user.Roles = 2;
                user.Active = true;
                user.Email = TbEmail.Text;
                user.Name = TbName.Text;
                user.Surname = TbLastName.Text;
                user.DateBirth = DtpDate.SelectedDate;
                user.Password = Helper.MD5Hash(TbPass.Password);
                user.Offices = (int)CmbOffice.SelectedValue;
                db.UserData.Add(user);
                db.SaveChanges();
                MessageBox.Show("Пользователь добавлен");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();

            }
        }
    }
}
