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
using System.Windows.Threading;

namespace Praktika
{
    /// <summary>
    /// Логика взаимодействия для WinLogin.xaml
    /// </summary>
    public partial class WinLogin : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private int countError;
        private int tick = 10;
        public WinLogin()
        {
            InitializeComponent();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += TimerTick;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            BtnLogin.Content = $"Доступ заблокирован:{tick} сек. ";
            tick--;
            if (tick == 0)
            {
                BtnLogin.IsEnabled = true;
                dispatcherTimer.Stop();
                tick = 10;
                countError = 0;


            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbUserName.Text) || string.IsNullOrEmpty(TbPass.Password))
            {
                MessageBox.Show("Не заполнены поля", "Информация");
                return;
            }
            var pass = Helper.MD5Hash(TbPass.Password);
            var user = Helper.GetContext().UserData
                .FirstOrDefault(x => x.Password == pass && x.Email == TbUserName.Text);
            if (user == null)
            {
                if (countError == 3)
                {
                    BtnLogin.IsEnabled = false;
                    dispatcherTimer.Start();
                    return;
                }
                MessageBox.Show("Неверный логин и пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                countError++;
                TbUserName.Text = string.Empty;
                TbPass.Password = string.Empty;
                return;
            }

            if (user.Active.HasValue)
            {
                if (!user.Active.Value)
                {
                    MessageBox.Show("Аккаунт не активен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            Helper.currentUser = user;
            if (user.Roles == 1)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            if (user.Roles == 2)
            {
                UserActivity activity = new UserActivity()
                {
                    IdUser = user.Id,
                    loginTime = DateTime.Now,
                };
                Helper.GetContext().UserActivity.Add(activity);
                Helper.GetContext().SaveChanges();
                Helper.currentUserActivity = activity;
                WinUser winUser = new WinUser();
                winUser.Show();
                this.Close();
            }
        }
    }
}
