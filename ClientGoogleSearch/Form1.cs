using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGoogleSearch
{
    public partial class Form1 : Form
    {
        public Links link;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Search.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.link = new Links();
            this.link.setText(textBox1.Text);
            this.link.populateListBox();
            this.link.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Search.Enabled = true;
            }
            else if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                Search.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
