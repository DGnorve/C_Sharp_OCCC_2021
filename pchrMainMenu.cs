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
    public partial class pchrMainMenu : Form
    {
        private tabPage1SubForm PersonalDetailsTab = null;
        private tabPage2SubForm MedicalDetailsTab = null;

        public pchrMainMenu()
        {
            InitializeComponent();
            this.Load += pchrMainMenu_Load;
        }

        private void pchrMainMenu_Load(object sender, EventArgs e)
        {
           

            this.PersonalDetailsTab = new tabPage1SubForm();
            this.PersonalDetailsTab.TopLevel = false;
            this.MedicalDetailsTab = new tabPage2SubForm();
            this.MedicalDetailsTab.TopLevel = false;
            this.tabPage1.Controls.Add(this.PersonalDetailsTab);
            this.PersonalDetailsTab.Show();
            this.tabPage2.Controls.Add(this.MedicalDetailsTab);
            this.MedicalDetailsTab.Show();

           

            
        }
    }
}
