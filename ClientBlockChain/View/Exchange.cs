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
    public partial class Exchange : Form, IFireabase
    {
        ExchangeBUS exchangeBUS;
        FilebaseBUS filebaseBUS;
        public static Exchange exchange;
        public Exchange()
        {
            InitializeComponent();
            exchangeBUS = new ExchangeBUS();
            filebaseBUS = new FilebaseBUS();
            exchange = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangePass change = new ChangePass();
            change.StartPosition = FormStartPosition.CenterParent;
            change.ShowDialog();
        }

        private void Exchange_Load(object sender, EventArgs e)
        {
            if(exchangeBUS.CheckAccountExchange(DataStatic.USERNAME,DataStatic.TOKEN))
            {
                button1.Enabled = false;
                label2.Text = DataStatic.USERNAME + " đã đăng ký";
                button3.Enabled = true;
                button4.Enabled = true;
                filebaseBUS.ListenFirebaseDataGridView(dataGridView1,textBox1);
            }
            else
            {
                button3.Enabled = false;
                button4.Enabled = false;
            }
            filebaseBUS.ListenFirebaseToken();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(exchangeBUS.CreateAccountExchange(DataStatic.USERNAME, DataStatic.TOKEN))
            {
                button1.Enabled = false;
                label2.Text = DataStatic.USERNAME + " đã đăng ký";
                button3.Enabled = true;
                button4.Enabled = true;
                filebaseBUS.ListenFirebaseDataGridView(dataGridView1,textBox1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Recharge recharge = new Recharge();
            recharge.StartPosition = FormStartPosition.CenterParent;
            recharge.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Transfer transfer = new Transfer();
            transfer.StartPosition = FormStartPosition.CenterParent;
            transfer.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void Logout()
        {
            Hide();
            Login login = new Login();
            login.StartPosition = FormStartPosition.CenterParent;
            login.ShowDialog();
            Close();
            DataStatic.USERNAME = "";
            DataStatic.TOKEN = "";
        }

        public void CheckLogin(bool check)
        {
            if (check)
            {
                MessageBox.Show("Account is being logged elsewhere");
                Application.Exit();
            }
        }
    }
}
