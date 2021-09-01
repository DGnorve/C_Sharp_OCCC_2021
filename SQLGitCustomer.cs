//David Norvell
//OCCC C# Spring 2021 Online
//FinalExam2.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FinalExam2
{
    public partial class SQLGitCustomer : Form
    {
        private int IDF = 0;
        private Customer Selected = null;
        private Customer updated = null;
        public SQLGitCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text != null)
            {
                if (int.TryParse(textBox1.Text, out IDF))
                {
                    this.Selected = CustomerDB.getCustomer(this.IDF);
                    textBox2.Text = Selected.Name;
                    textBox3.Text = Selected.Address;
                    textBox4.Text = Selected.ZipCode;
                    textBox5.Text = Selected.City;
                    textBox6.Text = Selected.State;
                }
                else
                    this.textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Selected != null)
            {
                updated = new Customer(this.Selected.CustomerID, this.textBox3.Text, this.textBox5.Text, this.textBox2.Text, this.textBox6.Text, this.textBox4.Text);
                CustomerDB.UpdateCustomer(this.updated, this.Selected);
                Form temp = Application.OpenForms["JustSQLThings"];  //This is so much cheese, but i love it.
                ((JustSQLThings)temp).Refresh();
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.Selected != null)
            {
                CustomerDB.DeleteCustomer(this.Selected);
                Form temp = Application.OpenForms["JustSQLThings"];  
                ((JustSQLThings)temp).Refresh();
            }
        }
    }
}
