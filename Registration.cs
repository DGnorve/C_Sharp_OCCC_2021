//David Norvell
//OCCC C# Spring 2021 Online
//Registration.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_CS2563_DavidNorvell
{
    public partial class Registration : Form
    {
       public bool hasPrompted = false;
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = 0;
            
            if (Validation.isValidText(textBox6.Text))
            {
                ID = registrationDB.doesExist(textBox6.Text);
                if (ID != -1)
                {
                    if (registrationDB.hasHash(ID) == false)
                    {
                        if (this.textBox2.Text.Trim().Contains(this.textBox3.Text.Trim()))
                        {
                            registrationDB.createLogin(textBox1.Text, textBox2.Text, ID);
                            this.Close();
                            this.Dispose();
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Both passwords must match");
                            this.textBox2.Clear();
                            this.textBox3.Clear();
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Please login to change your password");
                    }
                }
                else
                {
                    if (this.hasPrompted == false)
                    {
                        System.Windows.Forms.MessageBox.Show("No entry found, please complete all fields of this form and submit");
                        this.hasPrompted = true;
                    }
                    else {
                        if (registrationDB.doesExist(textBox1.Text.Trim()) == -1)
                        {
                            string username = textBox1.Text.Trim();
                            string password = textBox2.Text.Trim();
                            string identityNum = textBox4.Text.Trim();
                            string lastName = textBox5.Text.Trim();
                            string firstName = textBox6.Text.Trim();
                            string dob = this.dateTimePicker1.Text.Trim();
                            string title = this.comboBox1.SelectedItem.ToString();
                            string initial = this.comboBox2.SelectedItem.ToString();
                            string sex = null;
                            if (radioButton1.Checked == true)
                            {
                                sex = "Male";
                            }
                            if (radioButton2.Checked == true)
                            {
                                sex = "Female";
                            }
                            if (password.Contains(textBox3.Text.Trim()) == false)
                            {
                                System.Windows.Forms.MessageBox.Show("Both passwords must match");
                                this.textBox2.Clear();
                                this.textBox3.Clear();
                            }
                            else
                            {
                                if (Validation.isValidText(username))
                                    if (Validation.isValidText(lastName))
                                        if (Validation.isValidText(firstName))
                                        {
                                            PatientDB.createNewPatient(lastName, firstName, title, initial, sex, dob, identityNum);
                                            int newID = registrationDB.doesExist(firstName);
                                            registrationDB.createLogin(username, password, newID);
                                            this.Close();
                                            this.Dispose();



                                        }

                            }
                        }
                       
                        

                    }
                }
            }

        }
    }
}
