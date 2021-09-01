//David Norvell
//OCCC C# Spring 2021 Online
//LoginForm.cs

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
    public partial class LoginForm : Form
    {
        public bool isSuccess { get; private set; }
        public bool isRegister { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Validation.isValidText(this.textBox1.Text.Trim()))
            {
                StringBuilder hash = new StringBuilder(0);
                hash.Append(registrationDB.getUserSecInfo(this.textBox1.Text.Trim()).ToString());
                Program.username = new StringBuilder(this.textBox1.Text.Trim());

                if (passwordHasher.isValidPassword(this.textBox2.Text.Trim(), hash.ToString().Trim()))
                {
                    isSuccess = true;
                    this.Close();
                    this.Dispose();

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("The Password you entered doesn't match our records, try again! If you're a first-time user, please click Register below.");
                    this.textBox1.Clear();
                    this.textBox2.Clear();
                }
            }

            

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isRegister = true;
            this.Close();
            this.Dispose();
        }
    }
}
