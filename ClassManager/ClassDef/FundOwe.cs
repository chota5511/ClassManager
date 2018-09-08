using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager
{
    class FundOwe
    {
        private int fundID;
        private int studentID;
        private string studentName;
        public int FundID
        {
            get { return fundID; }
            set { fundID = value; }
        }

        //Student ID
        public int ID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        //Student Name
        public string Name
        {
            get { return studentName; }
        }
        public void FindName()
        {
            studentName = FindNameByID(studentID);
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
