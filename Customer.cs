//David Norvell
//OCCC C# Spring 2021 Online
//Customer.cs

using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExam2
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public Customer()
        { 
        
        }

        public Customer(int ID, string adr, string cty, string name, string st, string ZIP)
        {
            this.CustomerID = ID;
            this.Address = adr;
            this.City = cty;
            this.Name = name;
            this.State = st;
            this.ZipCode = ZIP;
        }

    }
}
