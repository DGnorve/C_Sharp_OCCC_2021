//David Norvell
//OCCC C# Spring 2021 Online
//InvoiceDB.cs

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FinalExam2
{
    public class InvoiceDB
    {
       
        
        public static List<Invoice> getInvoices()
        {
            List<Invoice> data = new List<Invoice>(0);
            SqlConnection Conn = MMABooksDB.GetConnection();
            string query = "SELECT * FROM Invoices";
            SqlCommand getDataFromTable = new SqlCommand(query, Conn);
            try
            {
                Conn.Open();
                SqlDataReader ingestTable = getDataFromTable.ExecuteReader();
                while (ingestTable.Read())
                {
                    Invoice Target = new Invoice();
                    Target.InvoiceID = (int)ingestTable["InvoiceID"];
                    Target.CustomerID = (int)ingestTable["CustomerID"];
                    Target.InvoiceDate = (DateTime)ingestTable["InvoiceDate"];
                    Target.productTotal = (decimal)ingestTable["ProductTotal"];
                    Target.SalesTax = (decimal)ingestTable["SalesTax"];
                    Target.Shipping = (decimal)ingestTable["Shipping"];
                    Target.invoiceTotal = (decimal)ingestTable["InvoiceTotal"];
                    data.Add(Target);
                }
                return data;
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return data;
        }

       

    }
}
