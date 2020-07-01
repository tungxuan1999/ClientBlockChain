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
    public partial class CreateAccount : Form
    {
        ExchangeBUS exchangeBUS;
        public CreateAccount()
        {
            InitializeComponent();
            exchangeBUS = new ExchangeBUS();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckNull())
            {
                if (exchangeBUS.CreateAccount(textBox1.Text, textBox2.Text, textBox4.Text, textBox5.Text, textBox6.Text))
                {
                    Close();
                }
            }
        }

        private bool CheckNull()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("User is empty");
                return false;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Pass is empty");
                return false;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Pass config is empty");
                return false;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("Name is empty");
                return false;
            }

            if (textBox5.Text == "")
            {
                MessageBox.Show("Address is empty");
                return false;
            }

            if (textBox6.Text == "")
            {
                MessageBox.Show("Phone is empty");
                return false;
            }

            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Pass don't like pass config");
                return false;
            }
            return true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
