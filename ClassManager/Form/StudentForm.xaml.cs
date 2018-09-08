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
    /// Interaction logic for Student.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        DataBase dataBase = new DataBase();
        public StudentForm()
        {
            InitializeComponent();
            txtName.Focus();
            dataBase.Connection();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.5);
            if (GlobalVariables.isEdit == true)
            {
                txtID.IsEnabled = false;
                txtID.Text = Convert.ToString(GlobalVariables.TmpStudent.ID);
                txtName.Text = GlobalVariables.TmpStudent.Name;
                txtEmail.Text = GlobalVariables.TmpStudent.Email;
                txtPhone.Text = Convert.ToString(GlobalVariables.TmpStudent.PhoneNumber);
                txtEmer.Text = Convert.ToString(GlobalVariables.TmpStudent.Emer);
                cbPosition.Text = GlobalVariables.TmpStudent.Position;
            }
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender,EventArgs e)
        {
            ///<Disable> Save button
            if (txtEmer.Text == "" || txtID.Text == "" || txtName.Text == "" || txtPhone.Text == "" || cbPosition.Text == "" || txtEmail.Text == "")
            {
                btSave.IsEnabled = false;
            }
            else
            {
                btSave.IsEnabled = true;
            }
            ///</Disable>
            
            //Refresh process here
        }
        private void OnlyNumbericTextbox(object sender,KeyEventArgs e)
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

        private void PreviewKeyDownNoSpacebar(object sender,KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.isDel = false;
            GlobalVariables.isEdit = false;
            this.Close();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            student.ID = Convert.ToInt32(txtID.Text);
            student.Name = txtName.Text;
            student.PhoneNumber = Convert.ToInt64(txtPhone.Text);
            student.Emer = Convert.ToInt64(txtEmer.Text);
            student.Email = txtEmail.Text;
            student.Position = cbPosition.Text;
            if (GlobalVariables.isEdit == true)
            {
                dataBase.EditStudent(student);
                GlobalVariables.isEdit = false;
            }
            else
            {
                dataBase.AddStudent(student);
                dataBase.AddAccount(student);
            }
            this.Close();
        }
    }
}
