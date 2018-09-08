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
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        public Delete()
        {
            InitializeComponent();
            txtReason.Focus();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.isDelFundCollect = false;
            GlobalVariables.isDelFundUsed = false;
            GlobalVariables.isDelNotification = false;
            GlobalVariables.isDelStudent = false;
            this.Close();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.isDel = true;
            this.Close();
        }
    }
}
