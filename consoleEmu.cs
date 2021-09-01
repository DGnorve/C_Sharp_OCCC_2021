//David Norvell 
//C# OCCC Spring Online
//consoleEmu.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FinalExam2
{
    public partial class consoleEmu : Form
    {
        ConsoleOutputAdapter writerEmu = null;
        public consoleEmu()
        {
            InitializeComponent();
            this.Load += consoleEmu_Load;
        }

        public void consoleEmu_Load(object sender, EventArgs e)
        {
            this.writerEmu = new ConsoleOutputAdapter(this.richTextBox1);
            Console.SetOut(this.writerEmu);
        }




    }
}
