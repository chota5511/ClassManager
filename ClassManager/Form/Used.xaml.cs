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
    /// Interaction logic for Used.xaml
    /// </summary>
    public partial class Used : Window
    {
        public Used()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.5);
            timer.Tick += Time_Tick;
            timer.Start();
        }

        private void Time_Tick(object sender,EventArgs e)
        {
            if (txtTitle.Text == "" || txtUsed.Text == "" || dpDate.SelectedDate == null)
            {
                btSave.IsEnabled = false;
            }
            else
            {
                btSave.IsEnabled = true;
            }
        }

        private void OnlyNumbericTextbox(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.NumPad0 &&
                e.Key != Key.NumPad1 &&
                e.Key != Key.NumPad2 &&
                e.Key != Key.NumPad3 &&
                e.Key != Key.NumPad4 &&
                e.Key != Key.NumPad5 &&
                e.Key != Key.NumPad6 &&
                e.Key != Key.NumPad7 &&
                e.Key != Key.NumPad8 &&
                e.Key != Key.NumPad9 &&
                e.Key != Key.D0 &&
                e.Key != Key.D1 &&
                e.Key != Key.D2 &&
                e.Key != Key.D3 &&
                e.Key != Key.D4 &&
                e.Key != Key.D5 &&
                e.Key != Key.D6 &&
                e.Key != Key.D7 &&
                e.Key != Key.D8 &&
                e.Key != Key.D9 &&
                e.Key != Key.Tab)
            {
                e.Handled = true;
            }
        }

        private void PreviewKeyDownNoSpacebar(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            FundUsed fundUsed = new FundUsed();
            fundUsed.Title = txtTitle.Text;
            fundUsed.Fund = Convert.ToDouble(txtUsed.Text);
            fundUsed.Date = dpDate.SelectedDate.Value.Date;
            DataBase dataBase = new DataBase();
            dataBase.Connection();
            dataBase.AddFundUsed(fundUsed);
            this.Close();
        }
    }
}
