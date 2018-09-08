using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager
{
    class Notification
    {
        private int id;
        private int studentID; //student's ID who post the Notification
        private string studentName;
        private string title;
        private string type;
        private string info;
        private DateTime date; // the day that post the Notification

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public int StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Info
        {
            get { return info; }
            set { info = value; }
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

        public string Name
        {
            get { return studentName; }
        }
        public string StudentName()
        {
            studentName = FindNameByID(studentID);
            return studentName;
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
    }
}
