using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_CS2563_DavidNorvell
{
    public class Medication
    {
        public int PID { get; set; }
        public int MID { get; set; }
        public StringBuilder typeOfMedication { get; set; }
        public StringBuilder date { get; set; }
        public bool isChronic { get; set; }

        public StringBuilder note {get; set;}



    }
}
