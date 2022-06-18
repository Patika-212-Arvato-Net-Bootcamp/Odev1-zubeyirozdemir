using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Person
    {
        private long tcNo = 0 , gsm = 0;
        private string name;
        private string surName;
     
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string SurName
        {
            get { return surName; }
            set { surName = value; }
        }

        public long TcNo
        {
            get { return tcNo; }
            set { tcNo = value; }
        }

        public long GSM
        {
            get { return gsm; }
            set { gsm = value; }
        }
    }
}
