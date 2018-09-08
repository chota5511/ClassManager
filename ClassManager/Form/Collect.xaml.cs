using System;
using System.Collections;
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
using System.Windows.Threading;

namespace ClassManager
{
    /// <summary>
    /// Interaction logic for Collect.xaml
    /// </summary>
    public partial class Collect : Window
    {
        private int count;
        public Collect()
        {
            InitializeComponent();

            //Timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;
            timer.Start();

            //Button load
            btSave.IsDefault = true;

            //Textbox load
            txtTitle.Focus();

            //Student list load
            if (GlobalVariables.isEdit == false)
            {
                PassArrayListToListView(GlobalVariables.studentList, lvNotCollected);
            }
            else
            {
                //Load ListView
                if (GlobalVariables.fundOweList.Count > 0)
                {
                    int i = 0;
                    while (i < GlobalVariables.fundOweList.Count)
                    {
                        FundOwe tmp = (FundOwe)GlobalVariables.fundOweList[i];
                        if(tmp.FundID == GlobalVariables.TmpFundCollect.ID)
                        {
                            lvNotCollected.Items.Add(tmp);
                        }
                        i++;
                    }
                }
                //Load info of Fund Collect
                txtTitle.Text = GlobalVariables.TmpFundCollect.Title;
                txtMoney.Text = Convert.ToString(GlobalVariables.TmpFundCollect.Fund);
                dpStartDate.SelectedDate = GlobalVariables.TmpFundCollect.StartDate;
                dpOutDate.SelectedDate = GlobalVariables.TmpFundCollect.OutDate;
                cbStartus.Text = GlobalVariables.TmpFundCollect.Status;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (GlobalVariables.isEdit == false)
            {
                if (txtTitle.Text == "" || txtMoney.Text == "" || lvNotCollected.SelectedItems.Count == 0 || cbStartus.Text == "" || dpStartDate.SelectedDate == null || dpOutDate.SelectedDate == null || dpOutDate.SelectedDate.Value <= dpStartDate.SelectedDate.Value)
                {
                    btSave.IsEnabled = false;
                }
                else
                {
                    btSave.IsEnabled = true;
                }
            }

            ///<Refresh> process here

            //Refresh student txtCount data
            if (GlobalVariables.isEdit == false)
            {
                count = lvNotCollected.SelectedItems.Count;
                lbCount.Content = "Số lượng: " + count;
            }
            else
            {
                count = lvNotCollected.SelectedItems.Count + GlobalVariables.TmpFundCollect.Count;
                lbCount.Content = "Số lượng: " + count;
            }

            //Refresh txtMoney
            if (txtMoney.Text == "")
            {
                lbTotal.Content = "Tổng cộng: 0";
            }
            else
            {
                lbTotal.Content = "Tổng cộng: " + count * Convert.ToDouble(txtMoney.Text);
            }

            ///</Refresh>
        }
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            FundCollect fundCollect = new FundCollect();
            fundCollect.Title = txtTitle.Text;
            fundCollect.Fund = Convert.ToDouble(txtMoney.Text);
            fundCollect.StartDate = dpStartDate.SelectedDate.Value;
            fundCollect.OutDate = dpOutDate.SelectedDate.Value;
            fundCollect.Status = cbStartus.Text;
            fundCollect.Count = count;
            fundCollect.TotalCount();
            DataBase dataBase = new DataBase();
            dataBase.Connection();
            if (GlobalVariables.isEdit == true)
            {
                fundCollect.ID = GlobalVariables.TmpFundCollect.ID;
                dataBase.EditFundCollect(fundCollect);
                for (int i = 0; i < lvNotCollected.SelectedItems.Count; i++)
                {
                    FundOwe fundOwe = (FundOwe)lvNotCollected.SelectedItems[i];
                    dataBase.DelOwe(fundOwe);
                }
                GlobalVariables.isEdit = false;
            }
            else
            {
                dataBase.AddFundCollect(fundCollect);
                DataRow row = dataBase.FundCollectTable().Rows[dataBase.FundCollectTable().Rows.Count - 1];
                for (int i = 0; i < lvNotCollected.SelectedItems.Count; i++)
                {
                    lvNotCollected.Items.Remove(lvNotCollected.SelectedItems[i]);
                }
                for(int i = 0; i < lvNotCollected.Items.Count; i++)
                {
                    FundOwe tmp = new FundOwe();
                    Student student = (Student)lvNotCollected.Items[i];
                    tmp.ID = student.ID;
                    tmp.FundID = Convert.ToInt32(row[0]);
                    dataBase.AddOwe(tmp);
                }
            }
            this.Close();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.isEdit = false;
            this.Close();
        }

        private void txtMoney_KeyDown(object sender, KeyEventArgs e)
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

        private void txtMoney_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
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

    }
}
