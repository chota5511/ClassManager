using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager
{
    class FundUsed
    {
        private int id;
        private string title;
        private DateTime date;
        private double fund;
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
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string DateString
        {
            get { return date.ToShortDateString(); }
        }
        public double Fund
        {
            get { return fund; }
            set { fund = value; }
        }
    }
}
