//David Norvell
//OCCC C# Spring Semester 2021 
//Final Exam 2
//MultiMIDAForm.cs


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalExam2
{
    public partial class multiMIDAForm : Form
    {
        //Subforms || Child Forms
        private Form consoleEmu;
        private Form JustSQLThings;

        



        public multiMIDAForm()
        {
            InitializeComponent();
            this.Load += multiMIDAForm_Load;
        }

        public void multiMIDAForm_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void toolStripMenuItem1_Clicked(object sender, EventArgs e)
        {
            this.consoleEmu = new consoleEmu();
            this.consoleEmu.MdiParent = this;
            this.consoleEmu.Show();

            GetProcsFromFile.outputList();
           
            
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripMenuItem1.DropDown.Show();

        }

        private void toolStripMenuItem2_Clicked(object sender, EventArgs e)
        {
            this.JustSQLThings = new JustSQLThings();
            this.JustSQLThings.MdiParent = this;
            this.JustSQLThings.Show();
        }
    }
}
