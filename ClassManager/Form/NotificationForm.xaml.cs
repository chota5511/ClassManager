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

namespace ClassManager
{
    /// <summary>
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class NotificationForm : Window
    {
        public NotificationForm()
        {
            InitializeComponent();

            //Timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.5);
            timer.Tick += Time_Tick;
            timer.Start();
        }

        private void Time_Tick(object sender,EventArgs e)
        {
            if (txtContent.Text == "" || txtTitle.Text == "" || cbType.Text == "" || dpDate.SelectedDate == null)
            {
                btSave.IsEnabled = false;
            }
            else
            {
                btSave.IsEnabled = true;
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            Notification notification = new Notification();
            notification.Title = txtTitle.Text;
            notification.Info = txtContent.Text;
            notification.Date = dpDate.SelectedDate.Value.Date;
            notification.Type = cbType.Text;
            DataBase dataBase = new DataBase();
            dataBase.Connection();
            dataBase.AddNotification(notification);
            this.Close();
        }
    }
}
