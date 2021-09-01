//David Norvell
//OCCC C# Spring 2021 Online
//tabPage1SubForm.cs
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_CS2563_DavidNorvell
{
    public partial class tabPage1SubForm : Form
    {
        private int PID = 0;
      

        public tabPage1SubForm()
        {
            InitializeComponent();
            this.Load += tabPage1SubForm_Load;
            this.PID = PatientDB.getPID(Program.username.ToString().Trim());
            this.setUsername();
            this.setPersonalDetails();
            this.setContactDetails();
            this.setEmergencyDetails();
            this.setPCPDetails();
            this.setInsDetails();
        }

        private void tabPage1SubForm_Load(object sender, EventArgs e)
        {
            
        }

  
        // "Setters" they get data into the GUI

        private void setPersonalDetails()
        {
            
            StringBuilder[] patientData = PatientDB.getPatientDetails(this.PID);
            this.textBox5.Text = patientData[13].ToString(); //Primary ID
            this.textBox6.Text = patientData[0].ToString(); //Last Name
            this.textBox7.Text = patientData[1].ToString(); //First Name
            this.dateTimePicker1.Value = DateTime.Parse(patientData[5].ToString(), CultureInfo.InvariantCulture); //DOB
            if (patientData[2].ToString().Trim().Contains("Male"))
            {
                this.radioButton1.Checked = true;
            }
            if (patientData[2].ToString().Trim().Contains("Female"))
            {
                this.radioButton2.Checked = true;
            }
            if (patientData[3].ToString().Trim() != null)
            {
                int set = this.comboBox1.FindStringExact(patientData[3].ToString().Trim());
                this.comboBox1.SelectedIndex = set;
            }
            if (patientData[4].ToString().Trim() != null) //These can be null, but rarely.
            { 
               int set2 = this.comboBox2.FindStringExact(patientData[4].ToString().Trim());
                this.comboBox2.SelectedIndex = set2;
            }
        }



        private void setEmergencyDetails()
        {

            StringBuilder[] patientEmergencyDetails = PatientDB.getPatientEmergencyDetails(this.PID);
            if (patientEmergencyDetails != null) //Note how there's a null check here, but not above? We know there's going to be contact details,patient details even with a new user. Because they're created at registration.
            {
                this.textBox16.Text = patientEmergencyDetails[0].ToString().Trim(); //NextOfKin
                this.textBox17.Text = patientEmergencyDetails[1].ToString().Trim(); //Relationship
                this.textBox18.Text = patientEmergencyDetails[6].ToString().Trim(); //Home Phone
                this.textBox19.Text = patientEmergencyDetails[10].ToString().Trim(); //Email
                this.richTextBox2.Text = patientEmergencyDetails[2].ToString().Trim(); // Address
                this.textBox25.Text = patientEmergencyDetails[4].ToString().Trim(); //ZIP
                this.textBox24.Text = patientEmergencyDetails[5].ToString().Trim(); //Suburb, not used
                this.textBox23.Text = patientEmergencyDetails[3].ToString().Trim(); //City
                this.textBox22.Text = patientEmergencyDetails[7].ToString().Trim(); //Mobile Phone
                this.textBox21.Text = patientEmergencyDetails[8].ToString().Trim(); //Work Phone
                this.textBox20.Text = patientEmergencyDetails[9].ToString().Trim(); //FAX #


            }
            else
                return;

        }

        private void setContactDetails()
        {
            StringBuilder[] patientData = PatientDB.getPatientDetails(this.PID);
            this.textBox9.Text = patientData[7].ToString(); //City
            this.textBox10.Text = patientData[10].ToString(); //Home Phone
            this.textBox11.Text = patientData[11].ToString(); //Work Phone
            this.textBox13.Text = patientData[12].ToString(); //FAX #
            this.textBox14.Text = patientData[14].ToString(); //EMAIL
            this.textBox15.Text = patientData[9].ToString(); //ZIP
            this.richTextBox1.Text = patientData[6].ToString(); // Address


        }

        private void setPCPDetails()
        {
            int primaryID = PatientDB.getPrimaryID(this.PID);
              StringBuilder[] patientPCP = PatientDB.getPatientPCPDetails(primaryID.ToString(),this.PID.ToString());  
            if (patientPCP != null || patientPCP.Length != 0)  //But everything else must be added, and we don't want to waste time calling ToString() on whitespace/null strings in best case. Worst case nullReferenceException
            {
                this.textBox26.Text = patientPCP[0].ToString();
                this.textBox27.Text = patientPCP[1].ToString();
                this.textBox28.Text = patientPCP[3].ToString();
                this.textBox29.Text = patientPCP[2].ToString();
                this.textBox30.Text = patientPCP[4].ToString();
                this.textBox31.Text = patientPCP[5].ToString();

            }
            else
                return;
        
        }

        private void setInsDetails()
        {
            StringBuilder[] patientIns = PatientDB.getPatientInsDetails(this.PID);
            this.textBox32.Text = patientIns[0].ToString().Trim();
            this.textBox33.Text = patientIns[1].ToString().Trim();
            this.textBox34.Text = patientIns[2].ToString().Trim();
        
        }

        private void setUsername()
        {
            this.textBox1.Text = Program.username.ToString();
        }



        //Event handlers

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.enablePasswordSection();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.disablePasswordSection();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Edit function of Personal info
        {
            this.enablePersonalSection();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Save function of Personal Info
        {
            StringBuilder[] patientData = PatientDB.getPatientDetails(this.PID);
            string address = patientData[6].ToString().Trim();
            string city = patientData[7].ToString().Trim();
            string state = patientData[8].ToString().Trim();
            string zip = patientData[9].ToString().Trim();
            string phoneHome = patientData[10].ToString().Trim();
            string phoneMobile = patientData[11].ToString().Trim();
            string fax = patientData[12].ToString().Trim();
            string primary = patientData[13].ToString().Trim();
            string email = patientData[14].ToString().Trim();

            

            string sex = null;
            if (this.radioButton1.Checked == true)
                sex = "Male";
            if (this.radioButton2.Checked == true)
                sex = "Female";
         

            string title = this.comboBox1.SelectedItem.ToString().Trim();
            string initials = this.comboBox2.SelectedItem.ToString().Trim();

            System.Windows.Forms.MessageBox.Show("Name: " + this.textBox6.Text.Trim() + " , " + "Last Name: " + this.textBox7.Text.Trim() + " , " + "Sex: " + sex + " , " + title + " , " + initials + " , " + this.dateTimePicker1.Text.Trim() + " , " +  address + " , " + city + " , " + state + " , " + zip + " , "
                + phoneHome + " , " + phoneMobile + " , " + fax + " , " + primary + " , " + email + " , " + this.PID);

            PatientDB.updatePatientInformation(this.textBox6.Text.Trim(), this.textBox7.Text.Trim(), sex, title, initials, this.dateTimePicker1.Text.Trim(), address, city, state, zip, phoneHome, phoneMobile, fax, primary, email, this.PID);
            System.Windows.Forms.MessageBox.Show("Update Success!");

            this.disablePersonalSection();
            this.setPersonalDetails();

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // Cancel Function of Personal info
        {
            this.disablePersonalSection();
            this.setPersonalDetails();
        }

        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)  //Save function of password
        {
            StringBuilder hash = registrationDB.getUserSecInfo(this.textBox1.Text.Trim());
            
            if (passwordHasher.isValidPassword(this.textBox2.Text.Trim(), hash.ToString()))
                {
                if (this.textBox3.Text.Trim().Contains(this.textBox4.Text.Trim()))
                {
                    
                    registrationDB.updateLogin(this.textBox1.Text.Trim(), this.textBox3.Text.Trim(), this.PID);
                    System.Windows.Forms.MessageBox.Show("Password Successfully Changed!");
                    this.disablePasswordSection();
                }
                    
                }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.enableContactSection();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Contact info "Save" function
        {
            StringBuilder[] patientData = PatientDB.getPatientDetails(this.PID);

            string lastName = patientData[0].ToString().Trim();
            string firstName = patientData[1].ToString().Trim();
            string sex = patientData[2].ToString().Trim();
            string title = patientData[3].ToString().Trim();
            string initial = patientData[4].ToString().Trim();
            string dob = patientData[5].ToString().Trim();
            string primary = patientData[13].ToString().Trim();
            string address = this.richTextBox1.Text.Trim();
            string city = this.textBox9.Text.Trim();
            string homePhone = this.textBox10.Text.Trim();
            string mobilePhone = this.textBox11.Text.Trim();
            string faxNumber = this.textBox13.Text.Trim();
            string email = this.textBox14.Text.Trim();
            string zip = this.textBox15.Text.Trim();

            PatientDB.updatePatientInformation(lastName, firstName, sex, title, initial, dob, address, city, null, zip, homePhone, mobilePhone, faxNumber, primary, email, this.PID);
            System.Windows.Forms.MessageBox.Show("Update Success!");
            this.disableContactSection();
            this.setContactDetails();

        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Emergency Contact "Edit" function
        {
            this.enableEmergencySection();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Emergency Contact "Cancel" function
        {
            this.disableEmergencySection();
        }
        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // Emergency Contact "Save" function
        {
            string nextOfKin = textBox16.Text.Trim();
            string relationship = textBox17.Text.Trim();
            string address = richTextBox2.Text.Trim();
            string city = textBox23.Text.Trim();
            string zip = textBox25.Text.Trim();
            string suburb = null;
            string homePhone = textBox18.Text.Trim();
            string mobilePhone = textBox22.Text.Trim();
            string workPhone = textBox21.Text.Trim();
            string fax = textBox20.Text.Trim();
            string email = textBox19.Text.Trim();

            if (PatientDB.doesEmergencyRecordExist(this.PID) == false)
            {
                PatientDB.createNewEmergencyDetails(this.PID, nextOfKin, relationship, address, city, zip, suburb, homePhone, mobilePhone, workPhone, fax, email);
                this.disableEmergencySection();
                this.setEmergencyDetails();
            }
            else
            {
                PatientDB.updatePatientEmergencyDetails(this.PID, nextOfKin, relationship, address, city, zip, suburb, homePhone, mobilePhone, workPhone, fax, email);
                this.disableEmergencySection();
                this.setEmergencyDetails();
            }

            
            


        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // Primary Care "Edit" function
        {
            this.enablePCPSection();
        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // Primary Care "Save" Function
        {
            int temppatientID = this.PID;
            int tempprimaryID = PatientDB.getPrimaryID(this.PID);

            string primaryID = this.getProperPrimaryID(tempprimaryID).ToString();
            string patientID = this.getProperPatientID(temppatientID).ToString();
         


            string fullName = this.textBox26.Text.Trim();
            string specialty = this.textBox27.Text.Trim();
            string mobilePhone = this.textBox28.Text.Trim();
            string workPhone = this.textBox29.Text.Trim();
            string fax = this.textBox30.Text.Trim();
            string email = this.textBox31.Text.Trim();

            //System.Windows.Forms.MessageBox.Show(primaryID + "," + patientID + "," + fullName + ", " + specialty + ", " + mobilePhone + ", " + workPhone + ", " + fax + ", " + email); used for debugging

            if (PatientDB.doesPCPRecordExist(primaryID, patientID) == false)
            {
                PatientDB.createNewPCPDetails(patientID, primaryID, fullName, specialty, workPhone, mobilePhone, fax, email);
                System.Windows.Forms.MessageBox.Show("Update Complete!");
                this.disablePCPSection();
                this.setPCPDetails();
            }
            else
            {
                PatientDB.updatePatientPCPInformation(fullName, specialty, workPhone, mobilePhone, fax, email, patientID, primaryID);
                System.Windows.Forms.MessageBox.Show("Update Complete!");
                this.disablePCPSection();
                this.setPCPDetails();
            }


        }

        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // Primary Care "Cancel" function
        {
            this.disablePCPSection();
        }

        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//Insurance details "Edit" function
        {
            this.enableInsuranceSection();
        }

        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Insurance Details "Save" Function
        {
            string insurer = this.textBox32.Text.Trim();
            string insNum = this.textBox33.Text.Trim();
            string insPlan = this.textBox34.Text.Trim();
            if (PatientDB.doesPatientInsRecordExist(this.PID.ToString()) == false)
            {
                PatientDB.createNewInsuranceDetails(this.PID, insurer, insNum, insPlan);
                this.disableInsuranceSection();
                this.setInsDetails();
            }
            else
            {
                PatientDB.updatePatientInsuranceDetails(this.PID, insurer, insNum, insPlan);
                this.disableInsuranceSection();
                this.setInsDetails();

            }


        }

        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //Insurance details "Cancel" function
        {
            this.disableInsuranceSection();
        }

        private void enablePasswordSection()
        {
            this.textBox2.Enabled = true;
            this.textBox2.ReadOnly = false;
            this.textBox3.Enabled = true;
            this.textBox3.ReadOnly = false;
            this.textBox4.Enabled = true;
            this.textBox4.ReadOnly = false;
            this.linkLabel2.Enabled = true;
            this.linkLabel18.Enabled = true;
        }

        private void enablePersonalSection()
        {
            this.textBox5.Enabled = true;
            this.textBox5.ReadOnly = false;

            this.textBox6.Enabled = true;
            this.textBox6.ReadOnly = false;

            this.textBox7.Enabled = true;
            this.textBox7.ReadOnly = false;

            this.comboBox1.Enabled = true;
            this.comboBox2.Enabled = true;

            this.radioButton1.Enabled = true;
            this.radioButton2.Enabled = true;

            this.dateTimePicker1.Enabled = true;
        

        }

        private void disablePersonalSection()
        {
            this.textBox5.Enabled = false;
            this.textBox5.ReadOnly = true;
            this.textBox5.Clear();

            this.textBox6.Enabled = false;
            this.textBox6.ReadOnly = true;
            this.textBox6.Clear();

            this.textBox7.Enabled = false;
            this.textBox7.ReadOnly = true;
            this.textBox7.Clear();

            this.comboBox1.Enabled = false;
            this.comboBox2.Enabled = false;
            
            this.radioButton1.Enabled = false;
            this.radioButton2.Enabled = false;

            this.dateTimePicker1.Enabled = false;
        }

        private void disablePasswordSection()
        {
            this.textBox2.Enabled = false;
            this.textBox2.ReadOnly = true;
            this.textBox2.Clear();

            this.textBox3.Enabled = false;
            this.textBox3.ReadOnly = true;
            this.textBox3.Clear();

            this.textBox4.Enabled = false;
            this.textBox4.ReadOnly = true;
            this.textBox4.Clear();

            this.linkLabel2.Enabled = false;
            this.linkLabel18.Enabled = false;
            this.setUsername();
        }

        private void enableContactSection()
        {
            this.richTextBox1.Enabled = true;
            this.richTextBox1.ReadOnly = false;

            this.textBox8.Enabled = true;
            this.textBox8.ReadOnly = false;

            this.textBox9.Enabled = true;
            this.textBox9.ReadOnly = false;

            this.textBox10.Enabled = true;
            this.textBox10.ReadOnly = false;

            this.textBox11.Enabled = true;
            this.textBox11.ReadOnly = false;

            this.textBox12.Enabled = true;
            this.textBox12.ReadOnly = false;

            this.textBox13.Enabled = true;
            this.textBox13.ReadOnly = false;

            this.textBox14.Enabled = true;
            this.textBox14.ReadOnly = false;

            this.textBox15.Enabled = true;
            this.textBox15.ReadOnly = false;
        }

        private void disableContactSection()
        {
            this.richTextBox1.Enabled = false;
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Clear();

            this.textBox8.Enabled = false;
            this.textBox8.ReadOnly = true;
            this.textBox8.Clear();

            this.textBox9.Enabled = false;
            this.textBox9.ReadOnly = true;
            this.textBox9.Clear();
                
            this.textBox10.Enabled = false;
            this.textBox10.ReadOnly = true;
            this.textBox10.Clear();

            this.textBox11.Enabled = false;
            this.textBox11.ReadOnly = true;
            this.textBox11.Clear();

            this.textBox12.Enabled = false;
            this.textBox12.ReadOnly = true;
            this.textBox12.Clear();

            this.textBox13.Enabled = false;
            this.textBox13.ReadOnly = true;
            this.textBox13.Clear();

            this.textBox14.Enabled = false;
            this.textBox14.ReadOnly = true;
            this.textBox14.Clear();

            this.textBox15.Enabled = false;
            this.textBox15.ReadOnly = true;
            this.textBox15.Clear();


            
        }

        private void enableEmergencySection()
        {
            this.textBox16.Enabled = true;
            this.textBox16.ReadOnly = false;

            this.textBox17.Enabled = true;
            this.textBox17.ReadOnly = false;

            this.richTextBox2.Enabled = true;
            this.richTextBox2.ReadOnly = false;

            this.textBox25.Enabled = true;
            this.textBox25.ReadOnly = false;

            this.textBox24.Enabled = true;
            this.textBox24.ReadOnly = false;

            this.textBox23.Enabled = true;
            this.textBox23.ReadOnly = false;

            this.textBox18.Enabled = true;
            this.textBox18.ReadOnly = false;

            this.textBox22.Enabled = true;
            this.textBox22.ReadOnly = false;

            this.textBox21.Enabled = true;
            this.textBox21.ReadOnly = false;

            this.textBox20.Enabled = true;
            this.textBox20.ReadOnly = false;

            this.textBox19.Enabled = true;
            this.textBox19.ReadOnly = false;

        }

        private void enablePCPSection()
        {
            this.textBox26.Enabled = true;
            this.textBox26.ReadOnly = false;

            this.textBox27.Enabled = true;
            this.textBox27.ReadOnly = false;

            this.textBox28.Enabled = true;
            this.textBox28.ReadOnly = false;
            
            this.textBox29.Enabled = true;
            this.textBox29.ReadOnly = false;

            this.textBox30.Enabled = true;
            this.textBox30.ReadOnly = false;

            this.textBox31.Enabled = true;
            this.textBox31.ReadOnly = false;


        
        }

        private void enableInsuranceSection()
        {
            this.textBox32.Enabled = true;
            this.textBox32.ReadOnly = false;

            this.textBox33.Enabled = true;
            this.textBox33.ReadOnly = false;

            this.textBox34.Enabled = true;
            this.textBox34.ReadOnly = false;

        }

        private void disableEmergencySection()
        {
            this.textBox16.Enabled = false;
            this.textBox16.ReadOnly = true;
            this.textBox16.Clear();

            this.textBox17.Enabled = false;
            this.textBox17.ReadOnly = true;
            this.textBox17.Clear();

            this.richTextBox2.Enabled = false;
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Clear();

            this.textBox25.Enabled = false;
            this.textBox25.ReadOnly = true;
            this.textBox25.Clear();

            this.textBox24.Enabled = false;
            this.textBox24.ReadOnly = true;
            this.textBox24.Clear();

            this.textBox23.Enabled = false;
            this.textBox23.ReadOnly = true;
            this.textBox23.Clear();

            this.textBox18.Enabled = false;
            this.textBox18.ReadOnly = true;
            this.textBox18.Clear();

            this.textBox22.Enabled = false;
            this.textBox22.ReadOnly = true;
            this.textBox22.Clear();

            this.textBox21.Enabled = false;
            this.textBox21.ReadOnly = true;
            this.textBox21.Clear();

            this.textBox20.Enabled = false;
            this.textBox20.ReadOnly = true;
            this.textBox20.Clear();

            this.textBox19.Enabled = false;
            this.textBox19.ReadOnly = true;
            this.textBox19.Clear();

            


        }

        private void disablePCPSection()
        {
            this.textBox26.Enabled = false;
            this.textBox26.ReadOnly = true;
            this.textBox26.Clear();

            this.textBox27.Enabled = false;
            this.textBox27.ReadOnly = true;
            this.textBox27.Clear();

            this.textBox28.Enabled = false;
            this.textBox28.ReadOnly = true;
            this.textBox28.Clear();

            this.textBox29.Enabled = false;
            this.textBox29.ReadOnly = true;
            this.textBox29.Clear();

            this.textBox30.Enabled = false;
            this.textBox30.ReadOnly = true;
            this.textBox30.Clear();

            this.textBox31.Enabled = false;
            this.textBox31.ReadOnly = true;
            this.textBox31.Clear();

           
        }

        private void disableInsuranceSection()
        {
            this.textBox32.Enabled = false;
            this.textBox32.ReadOnly = true;
            this.textBox32.Clear();

            this.textBox33.Enabled = false;
            this.textBox33.ReadOnly = true;
            this.textBox33.Clear();

            this.textBox34.Enabled = false;
            this.textBox34.ReadOnly = true;
            this.textBox34.Clear();
        }

        private StringBuilder getProperPatientID(int patientID) //Because our leading 0's keep getting wrecked, and without them FK Constraint WILL FAIL
        {
            StringBuilder tempID = new StringBuilder(0);
            if (patientID <= 9)
            {
                tempID.Append("00000" + patientID);
                return tempID;
            }
            else if(patientID > 9 && patientID <= 99 ) //Horrible design here btw, but i just needed it to work before midnight
            {
                tempID.Append("0000" + patientID);
                return tempID;
            }
            return null;

        }

        private StringBuilder getProperPrimaryID(int primaryID)
        {
            StringBuilder tempID = new StringBuilder(0);
            if (primaryID <= 9)
            {
                tempID.Append("00000" + primaryID);
                return tempID;
            }
            else if (primaryID > 9 && primaryID <= 99)
            {
                tempID.Append("0000" + primaryID);
                return tempID;
            }
            return null;

        }

       
    }
}
