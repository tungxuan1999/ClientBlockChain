using ClientBlockChain.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientBlockChain
{
    public partial class ChangePass : Form
    {
        ExchangeBUS exchangeBUS;
        public ChangePass()
        {
            InitializeComponent();
            exchangeBUS = new ExchangeBUS();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckNull())
            {
                if(exchangeBUS.ChangePassAccount(DataStatic.USERNAME,textBox3.Text,textBox1.Text))
                {
                    Close();
                }
            }
        }

        private bool CheckNull()
        {
            if(textBox3.Text == "")
            {
                MessageBox.Show("Old pass is empty");
                return false;
            }

            if(textBox1.Text == "")
            {
                MessageBox.Show("New pass is empty");
                return false;
            }

            if(textBox2.Text == "")
            {
                MessageBox.Show("Config pass is empty");
                return false;
            }

            if(textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Config pass don't like new pass");
                return false;
            }
            return true;
        }
    }
}
