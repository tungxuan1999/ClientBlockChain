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
    public partial class Recharge : Form
    {
        ExchangeBUS exchangeBUS;
        public Recharge()
        {
            InitializeComponent();
            exchangeBUS = new ExchangeBUS();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckNull())
            {
                if(exchangeBUS.RechargeAccountExchange(DataStatic.USERNAME,DataStatic.TOKEN,int.Parse(textBox3.Text).ToString()))
                {
                    Close();
                }
            }
        }

        private bool CheckNull()
        {
            if(textBox3.Text == "")
            {
                MessageBox.Show("Amount is empty");
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
