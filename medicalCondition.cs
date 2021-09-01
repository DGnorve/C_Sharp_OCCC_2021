using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_CS2563_DavidNorvell
{
    public class medicalCondition
    {
        public int PID { get; set; }
        public int CID { get; set; }

        public StringBuilder condition { get; set; }
        public StringBuilder dateOfOnset { get; set; }
        public bool acute { get; set; }
        public bool chronic { get; set; }
        public StringBuilder note { get; set; }
    }
}
