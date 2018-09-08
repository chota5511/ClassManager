using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClassManager
{
    class DataBase
    {
        private SqlConnection sqlConnection;
        private string sqlString;
        private SqlCommand sqlCommand;
        private SqlDataAdapter da;
        private DataSet ds = new DataSet();

        public void Connection()
        {
            StreamReader reader = new StreamReader("Server");
            sqlConnection = new SqlConnection();
            string dataSource = reader.ReadLine();
            string dataInitialCatalog = reader.ReadLine();
            string dataSecurity = reader.ReadLine();
            sqlConnection.ConnectionString = dataSource + ";" + dataInitialCatalog + ";" + dataSecurity;
            //sqlConnection.ConnectionString = "Data Source=DESKTOP-EJBHDHF\\SQLEXPRESS;Initial Catalog = DSSV;Integrated Security = true";
        }

        //Student
        public DataTable StudentTable()
        {
            sqlString = "SELECT * FROM THONGTINSINHVIEN";
            DataTable table = new DataTable();
            da = new SqlDataAdapter(sqlString, sqlConnection);
            da.Fill(table);
            return table;
        }

        public void EditStudent(Student student)
        {
            sqlString = string.Format("EXEC CAPNHATSV '{0}', N'{1}', '{2}', '{3}', '{4}', N'{5}'", student.ID, student.Name, student.PhoneNumber, student.Emer, student.Email, student.Position);
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddStudent(Student student)
        {
            sqlString = string.Format("EXEC NHAP '{0}', N'{1}', '{2}', '{3}', '{4}', N'{5}'", student.ID, student.Name, student.PhoneNumber, student.Emer, student.Email, student.Position);
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public DataTable AccountTable()
        {
            sqlString = "SELECT * FROM XUATTAIKHOAN";
            DataTable table = new DataTable();
            da = new SqlDataAdapter(sqlString, sqlConnection);
            da.Fill(table);
            return table;
        }

        public void AddAccount(Student student)
        {
            sqlString = string.Format("EXEC TAOTK {0}, '{0}'",student.ID);
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void ChangePassword(Student student, string password)
        {
            sqlString = string.Format("EXEC XOATK {0}", student.ID);
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlString = string.Format("EXEC TAOTK {0}, '{1}'", student.ID, password);
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //Owe
        public DataTable OweTable()
        {
            sqlString = "SELECT * FROM XUATNOTHU";
            DataTable table = new DataTable();
            da = new SqlDataAdapter(sqlString, sqlConnection);
            da.Fill(table);
            return table;
        }

        public void AddOwe(FundOwe fundOwe)
        {
            sqlString = string.Format("EXEC NHAPNOTHU {0}, {1}", fundOwe.FundID, fundOwe.ID);
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DelOwe(FundOwe fundOwe)
        {
            sqlString = string.Format("EXEC XOANOTHU {0}, {1}", fundOwe.FundID, fundOwe.ID);
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //Fund
        public double Fund()    //Fund Status
        {
            sqlString = "SELECT * FROM XUATTIENQUY";
            DataTable table = new DataTable();
            da = new SqlDataAdapter(sqlString, sqlConnection);
            da.Fill(table);
            DataRow row = table.Rows[0];
            if (row[0] == DBNull.Value)
            {
                sqlString = "SELECT SUM(TIENTHU*SOLUONG) FROM THU";
                da = new SqlDataAdapter(sqlString, sqlConnection);
                da.Fill(table);
                row = table.Rows[1];
                if (row[1] == DBNull.Value)
                {
                    return 0;
                }
                return Convert.ToDouble(row[1]);
            }
            return Convert.ToDouble(row[0]);
        }

        public DataTable FundCollectTable()
        {
            sqlString = "SELECT * FROM XUATTHU";
            DataTable table = new DataTable();
            da = new SqlDataAdapter(sqlString, sqlConnection);
            da.Fill(table);
            return table;
        }

        public void AddFundCollect(FundCollect fundCollect)
        {
            int status;
            //Trans status from string to bit
            if(fundCollect.Status == "Mở")
            {
                status = 1;
            }
            else
            {
                status = 0;
            }

            sqlString = string.Format("EXEC NHAPTHU '{0}', {1}, '{2}', '{3}', {4}, {5}", fundCollect.Title, fundCollect.Count, fundCollect.StartDate, fundCollect.OutDate, fundCollect.Fund, status);
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DelFundCollect(FundCollect fundCollect)
        {
            sqlString = "EXEC XOATHU " + fundCollect.ID;
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void EditFundCollect(FundCollect fundCollect)
        {
            int status;
            //Trans status from string to bit
            if (fundCollect.Status == "Mở")
            {
                status = 1;
            }
            else
            {
                status = 0;
            }

            sqlString = string.Format("EXEC CAPNHATTHU {0}, '{1}', {2}, '{3}', '{4}', {5}, {6}", fundCollect.ID, fundCollect.Title, fundCollect.Count, fundCollect.StartDate, fundCollect.OutDate, fundCollect.Fund, status);
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public DataTable FundUsedTable()
        {
            DataTable table = new DataTable();
            sqlString = "SELECT * FROM XUATCHI";
            da = new SqlDataAdapter(sqlString, sqlConnection);
            da.Fill(table);
            return table;
        }

        public void AddFundUsed(FundUsed fundUsed)
        {
            sqlString = string.Format("EXEC NHAPCHI '{0}', '{1}', {2}",fundUsed.Date,fundUsed.Title,fundUsed.Fund);
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DelFundUsed(FundUsed fundUsed)
        {
            sqlString = string.Format("EXEC XOACHI {0}", fundUsed.ID);
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        //Del Student
        public void DelStudent(int id)
        {
            sqlString = string.Format("EXEC XOASV '{0}'", id);
            sqlConnection.Open();
            sqlCommand = new SqlCommand(sqlString,sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        //Chat log
        public DataTable ChatLogTable()
        {
            sqlString = "SELECT * FROM XUATCHATLOG";
            da = new SqlDataAdapter(sqlString, sqlConnection);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        public void Sent(string sentString)
        {
            sqlString = string.Format("EXEC NHAPCHATLOG {0}, N'{1}', '{2}'", GlobalVariables.UserProfile.ID, sentString, DateTime.Now.Date);
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        //Notification table
        public DataTable NotificationTable()
        {
            DataTable table = new DataTable();
            sqlString = "SELECT * FROM XUATTHONGBAO";
            da = new SqlDataAdapter(sqlString, sqlConnection);
            da.Fill(table);
            return table;
        }
        public void AddNotification(Notification notification)
        {
            sqlString = string.Format("EXEC NHAPINFO {0}, N'{1}', N'{2}', N'{3}', '{4}'", GlobalVariables.UserProfile.ID, notification.Title, notification.Type, notification.Info, notification.Date.Date);
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void DelNotification(Notification notification)
        {
            sqlString = "EXEC XOAINFO " + notification.ID;
            sqlCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
