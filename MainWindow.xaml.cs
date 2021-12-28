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

namespace Praktika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var spicok = Helper.GetContext().UserData.ToList();
            DtgSpicok.ItemsSource = spicok;
            var office = Helper.GetContext().Offices.ToList();
            office.Insert(0, new Offices() { Title = "Все группы" });
            CmbOffice.ItemsSource = office;
        }
        private void Load()
        {
            var ooffice = CmbOffice.SelectedItem as Offices;
            DtgSpicok.ItemsSource = Helper.GetContext().UserData.Where(x => x.Offices1.Title == ooffice.Title || ooffice.Title == "Все группы").ToList();
        }

       

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Load();
        }

        private void TogButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (DtgSpicok.Items.Count > 0)
            {

                var index = DtgSpicok.SelectedItem;

                //int Id = int.Parse((DtgSpicok.SelectedCells[0].Column.GetCellContent(index) as TextBlock).Text);

                using (PraktikaEntities db = new PraktikaEntities())
                {
                    //UserData userData = new UserData();
                    if (DtgSpicok.SelectedItem is UserData userData)
                    {
                        WinChangeUser winIzmUser = new WinChangeUser(userData);
                        winIzmUser.Show();
                        this.Close();
                    }
                    else
                    {
                        WinAddUser winAddUser = new WinAddUser();
                        winAddUser.Show();
                        this.Close();
                    }

                }
            }
        }
    }
}
