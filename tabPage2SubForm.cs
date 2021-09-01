//David Norvell
//OCCC C# Spring 2021 Online
//tabPage2SubForm.cs

//Let's finish this fight...once and for all.

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
    public partial class tabPage2SubForm : Form
    {
        private int PID = 0;

        public tabPage2SubForm()
        {
            InitializeComponent();
            this.PID = PatientDB.getPID(Program.username.ToString().Trim());
            this.setPerInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Personal Details "Edit" button
        {
            enablePersonalMedDetails();
            this.linkLabel8.Enabled = true;
            this.linkLabel15.Enabled = true;

        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Personal Details "Save" button
        {
            

            string bloodGroup = this.comboBox1.SelectedItem.ToString();
            bool isDonor = this.checkBox1.Checked;
            bool isHIV = getAIDS();
            int weight = int.Parse(this.textBox1.Text.Trim());
            int height = int.Parse(this.textBox2.Text.Trim());

            string actualPID = this.getZedPadding(this.PID).ToString().Trim();

            bool doesExist = medicalDetailsDB.doesPersonalEntryExist(actualPID);
            System.Windows.Forms.MessageBox.Show(doesExist.ToString() + " ," + actualPID);
            /*

            if (medicalDetailsDB.doesPersonalEntryExist(actualPID))
            {
                medicalDetailsDB.updatePatientPerDetails(bloodGroup, isDonor, isHIV, height, weight, this.PID);
                
            }
            else if(medicalDetailsDB.doesPersonalEntryExist(actualPID) == false) {
                medicalDetailsDB.createNewPerDetails(this.PID, bloodGroup, isDonor, isHIV, height, weight);
            }
            */

        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Personal Details "Cancel" button
        {
            disablePersonalMedDetails();
        }

        private void enablePersonalMedDetails()
        {
            this.comboBox1.Enabled = true;
            this.checkBox1.Enabled = true;

            this.radioButton3.Enabled = true;
            this.radioButton4.Enabled = true;
            this.radioButton5.Enabled = true;

            this.textBox1.Enabled = true;
            this.textBox1.ReadOnly = false;

            this.textBox2.Enabled = true;
            this.textBox2.ReadOnly = false;
        }

        private void disablePersonalMedDetails()
        {
            this.linkLabel8.Enabled = false;
            this.linkLabel15.Enabled = false;

            this.comboBox1.Enabled = false;
            this.checkBox1.Enabled = false;

            this.radioButton3.Enabled = false;
            this.radioButton4.Enabled = false;
            this.radioButton5.Enabled = false;

            this.textBox1.Enabled = false;
            this.textBox1.ReadOnly = true;
            this.textBox1.Clear();

            this.textBox2.Enabled = false;
            this.textBox2.ReadOnly = true;
            this.textBox1.Clear();
        }

        private void setPerInfo()
        {
            StringBuilder[] perInfo = medicalDetailsDB.getPatientPersonalDetails(this.PID);
            if (perInfo != null && perInfo.Length != 0)
            {
                string blood = perInfo[0].ToString().Trim();
                string isDonor = perInfo[1].ToString().Trim();
                string isHiv = perInfo[2].ToString().Trim();
                string height = perInfo[3].ToString().Trim();
                string weight = perInfo[4].ToString().Trim();

                int index = this.comboBox1.FindStringExact(blood);
                bool isDono = bool.Parse(isDonor);
                bool isPos = bool.Parse(isHiv);

                this.comboBox1.SelectedIndex = index;
                this.checkBox1.Checked = isDono;
                this.setAIDS(isPos);

                this.textBox1.Text = height;
                this.textBox2.Text = weight;
                


            
            }
        
        }

        private bool getAIDS()
        {
            if (this.radioButton3.Checked) 
                return true;
            if (this.radioButton4.Checked && this.radioButton5.Checked) //negative or unknown == false
                return false;

            return false;
        }

        private void setAIDS(bool x)
        {
            if (x)
            {
                this.radioButton3.Checked = true;
                this.radioButton4.Checked = false;
                this.radioButton5.Checked = false;
            }
            else
            {
                this.radioButton3.Checked = false;
                this.radioButton4.Checked = true;
                this.radioButton5.Checked = false;
            }

        
        }

        private StringBuilder getZedPadding(int x)
        {
            if (x <= 9)
                return new StringBuilder("00000" + x.ToString());
            else
                return new StringBuilder("0000" + x.ToString());
        
        }

      
    }
}
