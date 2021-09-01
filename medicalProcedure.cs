using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_CS2563_DavidNorvell
{
    public class medicalProcedure
    {
        public int PID { get; set; }
        public int ProcID { get; set; }
        public StringBuilder typeOfProcedure { get; set; }
        public StringBuilder date { get; set; }
        public StringBuilder doctor { get; set; }
        public StringBuilder note { get; set; }
    }
}
