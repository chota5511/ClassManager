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

namespace ClassManager
{
    /// <summary>
    /// Interaction logic for Preferance.xaml
    /// </summary>
    public partial class Preferance : Window
    {
        public Preferance()
        {
            InitializeComponent();
            txtEmail.Text = GlobalVariables.UserProfile.Email;
            txtEmer.Text = Convert.ToString(GlobalVariables.UserProfile.Emer);
            txtPhoneNumber.Text = Convert.ToString(GlobalVariables.UserProfile.PhoneNumber);
        }
        //Save user preferance here
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
            this.Close();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult d = MessageBox.Show("Bạn có muốn lưu lại tùy chỉnh?", "Đóng tùy chỉnh?", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (d == MessageBoxResult.Yes)
            {
                //Save process
                Save();
                this.Close();
            }
            if (d == MessageBoxResult.No)
            {
                this.Close();
            }
        }
        private void Save()
        {
            DataBase dataBase = new DataBase();
            dataBase.Connection();
            if (txtPassword.Password != "")
            {
                dataBase.ChangePassword(GlobalVariables.UserProfile, txtPassword.Password);
            }
            GlobalVariables.UserProfile.Email = txtEmail.Text;
            GlobalVariables.UserProfile.Emer = Convert.ToInt64(txtEmer.Text);
            GlobalVariables.UserProfile.PhoneNumber = Convert.ToInt64(txtPhoneNumber.Text);
            dataBase.EditStudent(GlobalVariables.UserProfile);
        }
    }
}
