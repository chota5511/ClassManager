using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager
{
    class Student
    {
        private string name;
        private int id;
        private string email;
        private long phoneNumber;
        private long emer;
        private string position;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public long PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public long Emer
        {
            get { return emer; }
            set { emer = value; }
        }
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
