//David Norvell
//OCCC C# Spring 2021 Online
//Invoice.cs

using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExam2
{
   public class Invoice
   {
        public int InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public DateTime InvoiceDate { get; set; }

        public decimal productTotal { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Shipping { get; set; }
        public decimal invoiceTotal { get; set; }

        public Invoice()
        { }

        public Invoice(int IID, int CID) // bare minimum constructor 
        {
            this.InvoiceID = IID;
            this.CustomerID = CID;
        }

        

        public Invoice(int IID, int CID, DateTime IvD, decimal PCt, decimal salesTx, decimal Scot, decimal IvT)
        {
            this.InvoiceID = IID;
            this.CustomerID = CID;
            this.InvoiceDate = IvD;
            this.productTotal = PCt;
            this.SalesTax = salesTx;
            this.Shipping = Scot;
            this.invoiceTotal = IvT;
        
        }


   }
}
