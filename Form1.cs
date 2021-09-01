using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ItemManager
{

    
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }


      

        private void statesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.adapterManager.UpdateAll(this.MMABooksDataSet);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.productAdapter.Fill(this.MMABooksDataSet.Products);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                string code = this.textBox4.Text;
                string desc = this.textBox1.Text;
                decimal price = decimal.Parse(this.textBox2.Text);
                int quant = Int32.Parse(this.textBox3.Text);

                if (code.Length != 0 && code.Contains("null") == false)
                    if (desc.Length != 0 && desc.Contains("null") == false)
                        if (price > 0 && quant > 0)
                        {
                            this.adapterManager.ProductsTableAdapter.Insert(code, desc, price, quant);
                            this.productAdapter.Fill(this.MMABooksDataSet.Products);
                            this.Validate();
                            this.adapterManager.UpdateAll(this.MMABooksDataSet);
                            
                        }
                        else
                            return;
            
           
        }
    }
}
