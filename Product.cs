//David Norvell
//OCCC C# Spring 2021 Online
//Product.cs

using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExam2
{
    public class Product
    {
       public string Code { get; set; }
       public string Description { get; set; }
       public decimal price { get; set; }

        public Product() { }

        public Product(string PC, string desc, string PSP)
        {
            this.Code = PC;
            this.Description = desc;
            this.price = decimal.Parse(PSP);
        
        }




    }
}
