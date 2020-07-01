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
    public partial class Transfer : Form
    {
        ExchangeBUS exchangeBUS;
        public Transfer()
        {
            InitializeComponent();
            exchangeBUS = new ExchangeBUS();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "CHECK")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Account Tranfer is empty");
                }
                else
                {
                    if (textBox1.Text == DataStatic.USERNAME)
                    {
                        MessageBox.Show("You have not tranfer amount to yourshelf");
                    }
                    else
                    {
                        String name = exchangeBUS.CheckAccountTransfer(textBox1.Text);
                        if (name != "")
                        {
                            label3.Text = name;
                            textBox1.Enabled = !textBox1.Enabled;
                            button2.Text = "EDIT";
                        }
                    }
                }
            }
            else
            {
                label3.Text = "";
                textBox1.Enabled = !textBox1.Enabled;
                button2.Text = "CHECK";
            }
        }

        private void Transfer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckNull())
            {
                if(exchangeBUS.TransferAccountExchange(DataStatic.USERNAME, DataStatic.TOKEN, textBox1.Text, int.Parse(textBox3.Text).ToString()))
                {
                    this.Close();
                }
            }
        }

        private bool CheckNull()
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Money is empty");
                return false;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("Account Tranfer is empty");
                return false;
            }
            return true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
