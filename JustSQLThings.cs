//David Norvell
//OCCC C# Spring 2021 Spring Online
//JustSQLThings.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace FinalExam2
{
    public partial class JustSQLThings : Form
    {
        

        //Data Access Form
        private SQLGitCustomer getCD;

        //Generic SQL Handling
        public static DataSet justSQLData;
        public static SqlDataAdapter adaptRS;

        private List<Invoice> invoiceData;
        private List<Customer> customerData;



        public JustSQLThings()
        {
            InitializeComponent();
           

        }

        private void toolStripMenuItem1_Clicked(object sender, EventArgs e)
        {
            this.getCD = new SQLGitCustomer();

            this.getCD.TopLevel = false;
            this.getCD.Parent = this;
            this.getCD.Show();
            this.getCD.BringToFront();
            
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerDB.fillTableWithCustomers();
            this.dataGridView1.Refresh();
            this.dataGridView1.DataSource = justSQLData.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.invoiceData = InvoiceDB.getInvoices();
            this.customerData = CustomerDB.getData();

            var resultSet = from Invoices in invoiceData                                   
                            join Customers in customerData
                            on Invoices.CustomerID equals Customers.CustomerID
                            where Invoices.invoiceTotal > 150
                            orderby Customers.Name, Invoices.invoiceTotal
                            select new { Customers.Name, Invoices.invoiceTotal };


            this.dataGridView1.DataSource = resultSet.ToList();
            this.dataGridView1.Refresh();
           
        }

        
    }
    }

