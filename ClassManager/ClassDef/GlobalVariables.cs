using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager
{
    class GlobalVariables
    {
        private static Student userProfile = new Student();
        public static ArrayList studentList = new ArrayList();
        public static ArrayList fundCollectList = new ArrayList();
        public static ArrayList fundOweList = new ArrayList();
        public static ArrayList fundUsedList = new ArrayList();
        public static ArrayList notificationList = new ArrayList();
        private static Student tmpStudent = new Student();
        private static FundCollect tmpFundCollect = new FundCollect();
        public static bool isEdit;
        public static bool isDel;
        public static bool isDelStudent;
        public static bool isDelFundCollect;
        public static bool isDelFundUsed;
        public static bool isDelNotification;

        internal static Student UserProfile { get => userProfile; set => userProfile = value; }
        internal static Student TmpStudent { get => tmpStudent; set => tmpStudent = value; }
        internal static FundCollect TmpFundCollect { get => tmpFundCollect; set => tmpFundCollect = value; }
    }
}
