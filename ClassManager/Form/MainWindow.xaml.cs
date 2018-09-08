using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace ClassManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool logoutcheck;
        int chatLogCount = 0;
        /* All global variables can use in all WPF form storage in GlobalVariables class  */
        DataBase dataBase = new DataBase();
        public MainWindow()
        {
            InitializeComponent();

            ///<MainWindow> load process here
            this.ResizeMode = ResizeMode.CanMinimize;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            lbClock.Content = DateTime.Now;
            dataBase.Connection();
            chatLogCount = dataBase.ChatLogTable().Rows.Count;

            //Timer load
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;
            timer.Start();

            //Textbox load
            txtData.Focusable = false;
            txtSent.Focus();

            //Button load
            btDelStudent.IsEnabled = false;
            btEditStudent.IsEnabled = false;
            btEditCollect.IsEnabled = false;
            btDelCollect.IsEnabled = false;
            btDelNotification.IsEnabled = false;
            btDelUsed.IsEnabled = false;
            if (GlobalVariables.UserProfile.Position != "Lớp trưởng")
            {
                btAddStudent.IsEnabled = false;
            }
            if (GlobalVariables.UserProfile.Position == "Lớp trưởng")
            {
                lvStudentList.MouseDoubleClick += lvStudentList_MouseDoubleClick;
            }
            if (GlobalVariables.UserProfile.Position != "Thủ quỹ")
            {
                btAddUsed.IsEnabled = false;
                btAddCollect.IsEnabled = false;
            }
            if (GlobalVariables.UserProfile.Position == "Thủ quỹ")
            {
                lvCollect.MouseDoubleClick += lvCollect_MouseDoubleClick;
            }

            btSent.IsDefault = true;
            btAddCollect.IsDefault = true;
            btAddNotification.IsDefault = true;
            btAddStudent.IsDefault = true;
            btAddUsed.IsDefault = true;

            //Student list load
            for (int i = 0; i < dataBase.StudentTable().Rows.Count; i++)
            {
                GlobalVariables.studentList.Add(TableToStudent(dataBase.StudentTable(), i));
            }
            PassArrayListToListView(GlobalVariables.studentList, lvStudentList);

            //Notification load
            for (int i = 0; i < dataBase.NotificationTable().Rows.Count; i++)
            {
                GlobalVariables.notificationList.Add(TableToNotification(dataBase.NotificationTable(), i));
            }
            PassArrayListToListView(GlobalVariables.notificationList, lvAll);

            if (GlobalVariables.notificationList.Count > 0) //Devide by type of Notification
            {
                int i = 0;
                while (i < GlobalVariables.notificationList.Count)
                {
                    Notification tmp = (Notification)GlobalVariables.notificationList[i];
                    if (tmp.Type == "Thông báo")
                    {
                        object tmpObject = GlobalVariables.notificationList[i];
                        lvNotification.Items.Add(tmp);
                    }
                    if (tmp.Type == "Quan trọng")
                    {
                        object tmpObject = GlobalVariables.notificationList[i];
                        lvImportant.Items.Add(tmp);
                    }
                    if (tmp.Type == "Tự do")
                    {
                        object tmpObject = GlobalVariables.notificationList[i];
                        lvFree.Items.Add(tmp);
                    }
                    i++;
                }
            }

            //Owe load
            for (int i = 0; i < dataBase.OweTable().Rows.Count; i++)
            {
                GlobalVariables.fundOweList.Add(TableToFundOwe(dataBase.OweTable(), i));
            }
            PassArrayListToListView(GlobalVariables.fundOweList, lvOwe);

            //Fund Collect load
            for (int i = 0; i < dataBase.FundCollectTable().Rows.Count; i++)
            {
                GlobalVariables.fundCollectList.Add(TableToFundCollect(dataBase.FundCollectTable(), i));
            }
            PassArrayListToListView(GlobalVariables.fundCollectList, lvCollect);

            //Fund Used load
            for (int i = 0; i < dataBase.FundUsedTable().Rows.Count; i++)
            {
                GlobalVariables.fundUsedList.Add(TableToFundUsed(dataBase.FundUsedTable(), i));
            }
            PassArrayListToListView(GlobalVariables.fundUsedList, lvUsedList);

            //Chat log load
            ChatLogLoad();

            //User Profile load here
            txtID.Text = Convert.ToString(GlobalVariables.UserProfile.ID);
            txtName.Text = GlobalVariables.UserProfile.Name;
            txtEmail.Text = GlobalVariables.UserProfile.Email;
            txtEmer.Text = Convert.ToString(GlobalVariables.UserProfile.Emer);
            txtPhoneNumber.Text = Convert.ToString(GlobalVariables.UserProfile.PhoneNumber);
            txtPosition.Text = GlobalVariables.UserProfile.Position;


            //Test
            ///</Main>
        }

        //<User function define>
        private void ChatLogLoad()
        {
            if (dataBase.ChatLogTable().Rows.Count > 10)
            {
                for (int i = dataBase.ChatLogTable().Rows.Count - 10; i < dataBase.ChatLogTable().Rows.Count; i++)
                {
                    DataRow row = dataBase.ChatLogTable().Rows[i];
                    txtData.Text += "[" + FindNameByID((int)row[1]) + "]" + (string)row[2];
                }
                chatLogCount = dataBase.ChatLogTable().Rows.Count;
            }
            else
            {
                for (int i = 0; i < dataBase.ChatLogTable().Rows.Count; i++)
                {
                    DataRow row = dataBase.ChatLogTable().Rows[i];
                    string name = FindNameByID(Convert.ToInt32(row[1]));
                    txtData.Text += "[" + name + "] " + (string)row[2] + "\n";
                }
                chatLogCount = dataBase.ChatLogTable().Rows.Count;
            }
        }
        private void PassArrayListToListView(ArrayList arrayList, ListView listView)
        {
            if (arrayList.Count > 0)
            {
                int i = 0;
                while (i < arrayList.Count)
                {
                    object tmp = arrayList[i];
                    listView.Items.Add(tmp);
                    i++;
                }
            }
        }

        private Student TableToStudent(DataTable table, int location)
        {
            Student student = new Student();
            DataRow row = table.Rows[location];
            student.ID = Convert.ToInt32(row[0]);
            student.Name = Convert.ToString(row[1]);
            student.PhoneNumber = Convert.ToInt64(row[2]);
            student.Emer = Convert.ToInt64(row[3]);
            student.Email = Convert.ToString(row[4]);
            student.Position = Convert.ToString(row[5]);
            return student;
        }

        private Notification TableToNotification(DataTable table, int location)
        {
            Notification notification = new Notification();
            DataRow row = table.Rows[location];
            notification.ID = Convert.ToInt32(row[0]);
            notification.StudentID = Convert.ToInt32(row[1]);
            notification.Title = Convert.ToString(row[2]);
            notification.Info = Convert.ToString(row[3]);
            notification.Type = Convert.ToString(row[4]);
            notification.Date = Convert.ToDateTime(row[5]);
            notification.StudentName();
            return notification;
        }

        private FundOwe TableToFundOwe(DataTable table, int location)
        {
            DataRow row = table.Rows[location];
            FundOwe fundOwe = new FundOwe();
            fundOwe.FundID = Convert.ToInt32(row[0]);
            fundOwe.ID = Convert.ToInt32(row[1]);
            fundOwe.FindName();
            return fundOwe;
        }

        private FundCollect TableToFundCollect(DataTable table, int location)
        {
            DataRow row = table.Rows[location];
            FundCollect fundCollect = new FundCollect();
            fundCollect.ID = Convert.ToInt32(row[0]);
            fundCollect.Title = (string)row[1];
            fundCollect.Count = Convert.ToInt32(row[2]);
            fundCollect.StartDate = Convert.ToDateTime(row[3]);
            fundCollect.OutDate = Convert.ToDateTime(row[4]);
            fundCollect.Fund = Convert.ToDouble(row[5]);
            if (Convert.ToInt32(row[6]) == 1)
            {
                fundCollect.Status = "Mở";
            }
            else
            {
                fundCollect.Status = "Đóng";
            }
            fundCollect.TotalCount();
            return fundCollect;
        }

        private FundUsed TableToFundUsed(DataTable table, int location)
        {
            DataRow row = table.Rows[location];
            FundUsed fundUsed = new FundUsed();
            fundUsed.ID = Convert.ToInt32(row[0]);
            fundUsed.Title = (string)row[1];
            fundUsed.Date = Convert.ToDateTime(row[2]);
            fundUsed.Fund = Convert.ToDouble(row[3]);
            return fundUsed;
        }

        private void AddToStudentList(DataTable table)
        {
            int i = 0;
            while (i < table.Rows.Count)
            {
                GlobalVariables.studentList.Add(TableToStudent(table, i));
                i++;
            }
        }

        private string FindNameByID(int id)
        {
            int i = 0;
            while (i < GlobalVariables.studentList.Count)
            {
                Student tmp = (Student)GlobalVariables.studentList[i];
                if (id == tmp.ID)
                {
                    return tmp.Name;
                }
                i++;
            }
            return "";
        }
        //</Funtion>


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult d;
            if (logoutcheck == true)
            {
                d = MessageBox.Show("Bạn muốn đăng xuất?", "Đăng xuất?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            }
            else
            {
                d = MessageBox.Show("Bạn muốn thoát?", "Thoát?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            }
            if (d == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            if (d == MessageBoxResult.Yes && logoutcheck == false)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void miLogout_Click(object sender, RoutedEventArgs e)
        {
            //clear all
            lvAll.Items.Clear();
            lvCollect.Items.Clear();
            lvFree.Items.Clear();
            lvImportant.Items.Clear();
            lvNotification.Items.Clear();
            lvOwe.Items.Clear();
            lvStudentList.Items.Clear();
            lvUsedList.Items.Clear();

            GlobalVariables.fundCollectList.Clear();
            GlobalVariables.fundOweList.Clear();
            GlobalVariables.fundUsedList.Clear();
            GlobalVariables.notificationList.Clear();
            GlobalVariables.studentList.Clear();

            //Log out process
            Login login = new Login();
            logoutcheck = true;
            this.Close();
            if (!this.IsActive)
            {
                login.Show();
            }
            logoutcheck = false;
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Any reload process here
        private void Timer_Tick(object sender, EventArgs e)
        {
            lbClock.Content = DateTime.Now;

            //Refresh user info
            txtID.Text = Convert.ToString(GlobalVariables.UserProfile.ID);
            txtName.Text = GlobalVariables.UserProfile.Name;
            txtEmail.Text = GlobalVariables.UserProfile.Email;
            txtEmer.Text = Convert.ToString(GlobalVariables.UserProfile.Emer);
            txtPhoneNumber.Text = Convert.ToString(GlobalVariables.UserProfile.PhoneNumber);
            txtPosition.Text = GlobalVariables.UserProfile.Position;

            //Studen
            if (lvStudentList.SelectedItems.Count > 0 && GlobalVariables.UserProfile.Position == "Lớp trưởng")
            {
                btDelStudent.IsEnabled = true;
                if (lvStudentList.SelectedItems.Count == 1)
                {
                    btEditStudent.IsEnabled = true;
                }
                else
                {
                    btEditStudent.IsEnabled = false;
                }
            }
            else
            {
                btDelStudent.IsEnabled = false;
                btEditStudent.IsEnabled = false;
            }

            //Collect
            if (lvCollect.SelectedItems.Count > 0 && GlobalVariables.UserProfile.Position == "Thủ quỹ")
            {
                btDelCollect.IsEnabled = true;
                if (lvCollect.SelectedItems.Count == 1)
                {
                    btEditCollect.IsEnabled = true;
                }
                else
                {
                    btEditCollect.IsEnabled = false;
                }
            }
            else
            {
                btEditCollect.IsEnabled = false;
            }

            //Used
            if (lvUsedList.SelectedItems.Count > 0)
            {
                btDelUsed.IsEnabled = true;
            }
            else
            {
                btDelUsed.IsEnabled = false;
            }

            //Notification
            if (lvAll.SelectedItems.Count > 0 || lvImportant.SelectedItems.Count > 0 || lvNotification.SelectedItems.Count > 0 || lvFree.SelectedItems.Count > 0)
            {
                btDelNotification.IsEnabled = true;
            }
            else
            {
                btDelNotification.IsEnabled = false;
            }

            //Fund
            lbFundStatus.Content = "Tiền quỹ còn lại: " + dataBase.Fund() + " VND";

            //Refresh chat log
            if (chatLogCount < dataBase.ChatLogTable().Rows.Count)
            {
                for (int i = chatLogCount - 1; i < dataBase.ChatLogTable().Rows.Count; i++)
                {
                    DataRow row = dataBase.ChatLogTable().Rows[i];
                    txtData.Text += "[" + FindNameByID((int)row[1]) + "]" + (string)row[2];
                }
                chatLogCount = dataBase.ChatLogTable().Rows.Count;
            }
            if (chatLogCount > dataBase.ChatLogTable().Rows.Count) //reload chat log
            {
                txtData.Clear();
                ChatLogLoad();
                chatLogCount = dataBase.ChatLogTable().Rows.Count;
            }


            //Del Process
            if (GlobalVariables.isDel == true && GlobalVariables.isDelStudent == true) //Del Student
            {
                Student tmp = (Student)lvStudentList.SelectedItems[0];
                lvStudentList.Items.Remove(lvStudentList.SelectedItems[0]);
                dataBase.DelStudent(tmp.ID);
                GlobalVariables.isDel = false;
                GlobalVariables.isDelStudent = false;
            }

            if (GlobalVariables.isDel == true && GlobalVariables.isDelNotification == true)    //Del Notification
            {
                Notification tmp;
                if (lvAll.SelectedItems.Count > 0)
                {
                    tmp = (Notification)lvAll.SelectedItems[0];
                    lvAll.Items.Remove(lvAll.SelectedItems[0]);
                    dataBase.DelNotification(tmp);
                }
                if (lvImportant.SelectedItems.Count > 0)
                {
                    tmp = (Notification)lvImportant.SelectedItems[0];
                    lvImportant.Items.Remove(lvImportant.SelectedItems[0]);
                    dataBase.DelNotification(tmp);
                }
                if (lvNotification.SelectedItems.Count > 0)
                {
                    tmp = (Notification)lvNotification.SelectedItems[0];
                    lvNotification.Items.Remove(lvNotification.SelectedItems[0]);
                    dataBase.DelNotification(tmp);
                }
                if (lvFree.SelectedItems.Count > 0)
                {
                    tmp = (Notification)lvFree.SelectedItems[0];
                    lvFree.Items.Remove(lvFree.SelectedItems[0]);
                    dataBase.DelNotification(tmp);
                }
                GlobalVariables.isDel = false;
                GlobalVariables.isDelNotification = false;
            }

            if (GlobalVariables.isDel == true && GlobalVariables.isDelFundUsed == true)
            {
                FundUsed tmp = (FundUsed)lvUsedList.SelectedItems[0];
                lvUsedList.Items.Remove(lvUsedList.SelectedItems[0]);
                dataBase.DelFundUsed(tmp);
                GlobalVariables.isDel = false;
                GlobalVariables.isDelFundUsed = false;

            }

            if (GlobalVariables.isDel == true && GlobalVariables.isDelFundCollect == true)
            {
                FundCollect tmp = (FundCollect)lvCollect.SelectedItems[0];
                lvCollect.Items.Remove(lvCollect.SelectedItems[0]);
                dataBase.DelFundCollect(tmp);
                GlobalVariables.isDel = false;
                GlobalVariables.isDelFundCollect = false;
            }
        }

        private void btDelStudent_Click(object sender, RoutedEventArgs e)
        {
            Delete delete = new Delete();
            GlobalVariables.isDelStudent = true;
            delete.ShowDialog();
        }

        private void btSent_Click(object sender, RoutedEventArgs e)
        {
            if (txtSent.Text != "")
            {
                dataBase.Sent(txtSent.Text);
                chatLogCount++;
                txtData.Text += "[" + GlobalVariables.UserProfile.Name + "] " + txtSent.Text + "\n";
                txtSent.Text = "";
            }
        }

        private void miOption_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btAddCollect_Click(object sender, RoutedEventArgs e)
        {
            Collect collect = new Collect();
            collect.ShowDialog();
        }

        private void btAddUsed_Click(object sender, RoutedEventArgs e)
        {
            Used used = new Used();
            used.ShowDialog();
        }

        private void btAddStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.ShowDialog();
        }

        private void btAddNotification_Click(object sender, RoutedEventArgs e)
        {
            NotificationForm notificationForm = new NotificationForm();
            notificationForm.ShowDialog();
        }

        private void miPreferance_Click(object sender, RoutedEventArgs e)
        {
            Preferance preferance = new Preferance();
            preferance.Show();
        }

        private void btDelNotification_Click(object sender, RoutedEventArgs e)
        {
            Delete delete = new Delete();
            GlobalVariables.isDelNotification = true;
            delete.ShowDialog();
        }

        private void btDelCollect_Click(object sender, RoutedEventArgs e)
        {
            Delete delete = new Delete();
            GlobalVariables.isDelFundCollect = true;
            delete.ShowDialog();
        }

        private void btDelUsed_Click(object sender, RoutedEventArgs e)
        {
            Delete delete = new Delete();
            GlobalVariables.isDelFundUsed = true;
            delete.ShowDialog();
        }

        private void miRefresh_Click(object sender, RoutedEventArgs e)
        {

            //Refresh student listview
            lvStudentList.Items.Clear();
            GlobalVariables.studentList.Clear();
            for (int i = 0; i < dataBase.StudentTable().Rows.Count; i++)
            {
                GlobalVariables.studentList.Add(TableToStudent(dataBase.StudentTable(), i));
            }
            PassArrayListToListView(GlobalVariables.studentList, lvStudentList);

            //Refresh Notification listview
            lvAll.Items.Clear();
            lvFree.Items.Clear();
            lvImportant.Items.Clear();
            lvNotification.Items.Clear();

            GlobalVariables.notificationList.Clear();

            for (int i = 0; i < dataBase.NotificationTable().Rows.Count; i++)
            {
                GlobalVariables.notificationList.Add(TableToNotification(dataBase.NotificationTable(), i));
                Notification tmp = (Notification)GlobalVariables.notificationList[i];
                tmp.StudentName();
            }
            PassArrayListToListView(GlobalVariables.notificationList, lvAll);
            if (GlobalVariables.notificationList.Count > 0)
            {
                int i = 0;
                while (i < GlobalVariables.notificationList.Count)
                {
                    Notification tmp = (Notification)GlobalVariables.notificationList[i];
                    if (tmp.Type == "Thông báo")
                    {
                        object tmpObject = GlobalVariables.notificationList[i];
                        lvNotification.Items.Add(tmp);
                    }
                    if (tmp.Type == "Quan trọng")
                    {
                        object tmpObject = GlobalVariables.notificationList[i];
                        lvImportant.Items.Add(tmp);
                    }
                    if (tmp.Type == "Tự do")
                    {
                        object tmpObject = GlobalVariables.notificationList[i];
                        lvFree.Items.Add(tmp);
                    }
                    i++;
                }
            }

            //Refresh Owe
            lvOwe.Items.Clear();

            GlobalVariables.fundOweList.Clear();

            for (int i = 0; i < dataBase.OweTable().Rows.Count; i++)
            {
                GlobalVariables.fundOweList.Add(TableToFundOwe(dataBase.OweTable(), i));
            }
            PassArrayListToListView(GlobalVariables.fundOweList, lvOwe);

            //Refresh Fund Collect
            lvCollect.Items.Clear();

            GlobalVariables.fundCollectList.Clear();

            for (int i = 0; i < dataBase.FundCollectTable().Rows.Count; i++)
            {
                GlobalVariables.fundCollectList.Add(TableToFundCollect(dataBase.FundCollectTable(), i));
            }
            PassArrayListToListView(GlobalVariables.fundCollectList, lvCollect);

            //Refresh Fund Used
            lvUsedList.Items.Clear();

            GlobalVariables.fundUsedList.Clear();

            for (int i = 0; i < dataBase.FundUsedTable().Rows.Count; i++)
            {
                GlobalVariables.fundUsedList.Add(TableToFundUsed(dataBase.FundUsedTable(), i));
            }
            PassArrayListToListView(GlobalVariables.fundUsedList, lvUsedList);

        }

        private void btEditStudent_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.TmpStudent = (Student)lvStudentList.SelectedItem;
            GlobalVariables.isEdit = true;
            StudentForm window = new StudentForm();
            window.ShowDialog();
        }

        private void lvStudentList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GlobalVariables.TmpStudent = (Student)lvStudentList.SelectedItem;
            GlobalVariables.isEdit = true;
            StudentForm window = new StudentForm();
            window.ShowDialog();
        }

        private void btEditCollect_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.isEdit = true;
            GlobalVariables.TmpFundCollect = (FundCollect)lvCollect.SelectedItems[0];
            Collect collect = new Collect();
            collect.ShowDialog();
        }

        private void lvCollect_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GlobalVariables.isEdit = true;
            GlobalVariables.TmpFundCollect = (FundCollect)lvCollect.SelectedItems[0];
            Collect collect = new Collect();
            collect.ShowDialog();
        }

    }
}
