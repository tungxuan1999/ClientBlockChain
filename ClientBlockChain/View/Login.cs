using ClientBlockChain.BL;
using ClientBlockChain.Interface;
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
    public partial class Login : Form
    {
        private ExchangeBUS exchangeBUS;
        public Login()
        {
            InitializeComponent();
            exchangeBUS = new ExchangeBUS();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckNull())
            {
                DataStatic.USERNAME = textBox1.Text;
                DataStatic.TOKEN = exchangeBUS.LoginAccount(textBox1.Text, textBox2.Text);
                if (DataStatic.TOKEN != "")
                {
                    Hide();
                    Exchange exchange = new Exchange();
                    exchange.StartPosition = FormStartPosition.CenterParent;
                    exchange.ShowDialog();
                    Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            createAccount.StartPosition = FormStartPosition.CenterParent;
            createAccount.ShowDialog();
        }

        private bool CheckNull()
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("User is empty");
                return false;
            }

            if(textBox2.Text == "")
            {
                MessageBox.Show("Password is empty");
                return false;
            }
            return true;
        }
    }
}
