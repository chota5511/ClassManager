using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Login : Window
    {
        DataBase dataBase = new DataBase();
        public Login()
        {
            InitializeComponent();

            //Load process here
            txtUserID.Focus();
            btLogin.IsDefault = true;
            //btExit.IsCancel = true;
            this.ResizeMode = ResizeMode.CanMinimize;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen; //Make window startup at center of the screen is here
        }

        private void Button_Close(object sender, EventArgs e)
        {
            this.Close();
        }

        //Log in process here
        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Connect to Database
                dataBase.Connection();
            }
            catch (Exception e1)
            {
                MessageBox.Show(Convert.ToString(e1), "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (txtUserID.Text == "" || txtPassword.Password == "")
            {
                MessageBox.Show("Chưa nhập mã số sinh viên hoặc mật khẩu", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (AccountCheck(txtUserID.Text, txtPassword.Password) == true)
            {
                for(int i = 0; i < dataBase.StudentTable().Rows.Count; i++)
                {
                    DataRow row = dataBase.StudentTable().Rows[i];
                    if ((string)row[0] == txtUserID.Text)
                    {
                        GlobalVariables.UserProfile.ID = Convert.ToInt32(row[0]);
                        GlobalVariables.UserProfile.Name = (string)row[1];
                        GlobalVariables.UserProfile.PhoneNumber = Convert.ToInt64(row[2]);
                        GlobalVariables.UserProfile.Emer = Convert.ToInt64(row[3]);
                        GlobalVariables.UserProfile.Email = (string)row[4];
                        GlobalVariables.UserProfile.Position = (string)row[5];
                    }
                }
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Nhâp sai mã số sinh viên hoặc mật khẩu!!!", "Đăng nhập", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private bool AccountCheck(string studentID, string password)
        {
            for(int i = 0; i < dataBase.AccountTable().Rows.Count; i++)
            {
                DataRow row = dataBase.AccountTable().Rows[i];
                if ((string)row[1] == studentID)
                {
                    if ((string)row[2] == password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
