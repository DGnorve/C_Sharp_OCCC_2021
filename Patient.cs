//David Norvell
//OCCC C# Spring 2021 Online
//Patient.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_CS2563_DavidNorvell
{
    public class Patient
    {
        int PATIENT_ID { get; set; }
        StringBuilder firstName { get; set; }
        StringBuilder lastName { get; set; }
        StringBuilder DateOfBirth { get; set; }
        StringBuilder Address_Street { get; set; }
        StringBuilder Address_City { get; set; }
        StringBuilder Address_State { get; set; }
        StringBuilder Address_ZIP { get; set; }
        StringBuilder PHONE_HOME { get; set; }
        StringBuilder PHONE_MOBILE { get; set; }
        int PRIMARY_ID { get; set; }

        public Patient(int ID, string fName, string lName, string DOB)
        {
            this.PATIENT_ID = ID;
            this.firstName = this.firstName.Append(fName);
            this.lastName = this.lastName.Append(lName);
            this.DateOfBirth = this.DateOfBirth.Append(DOB);
            
        }

        

    }
}
