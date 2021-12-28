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
    /// Логика взаимодействия для WinUser.xaml
    /// </summary>
    public partial class WinUser : Window
    {
        public WinUser()
        {
            InitializeComponent();
            TBName.Text = $"Hi {Helper.currentUser.Name}, Welcome to AMONIC Airlines.";

            TimeSpan time = new TimeSpan(Helper.GetContext().UserActivity.ToList().
                Where(x => x.IdUser == Helper.currentUser.Id && x.logoutTime.HasValue && x.logoutTime<=x.logoutTime.Value.AddDays(30) 
                && x.TimeSpent.HasValue).ToList().Sum(x=>x.TimeSpent.Value.Ticks));
            TBTime.Text = $"TIme spent on system: {time:hh\\:mm}\t";
            TBCrash.Text= $"Number of crashes: {Helper.GetContext().UserActivity.Where(x=>x.IdUser == Helper.currentUser.Id &&string.IsNullOrEmpty(x.reason)).Count()}";
            var activity = Helper.GetContext().UserActivity.Where(x => x.IdUser == Helper.currentUser.Id).ToList();
            DGLogControl.ItemsSource = activity;


           
        }
    }
}
