using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager
{
    class FundCollect
    {
        private int id;
        private string title;
        private int count;
        private DateTime startdate;
        private DateTime outdate;
        private double fund;
        private string status;
        private double total;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public DateTime StartDate
        {
            get { return startdate; }
            set { startdate = value; }
        }
        public string StartDateString
        {
            get { return startdate.ToShortDateString(); }
        }
        public DateTime OutDate
        {
            get { return outdate; }
            set { outdate = value; }
        }
        public string OutDateString
        {
            get { return outdate.ToShortDateString(); }
        }
        public double Fund
        {
            get { return fund; }
            set { fund = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public double Total
        {
            get { return total; }
        }
        public double TotalCount()
        {
            total = fund * count;
            return total;
        }
    }
}
