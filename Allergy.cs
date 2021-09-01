using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_CS2563_DavidNorvell
{
    public class Allergy
    {
        public int PID { get; set; }
        public int AID { get; set; }
        public StringBuilder trigger { get; set; }
        public StringBuilder DateOfOnset { get; set; }
        public StringBuilder Date { get; set; }
        public StringBuilder Note { get; set; }
    }
}
