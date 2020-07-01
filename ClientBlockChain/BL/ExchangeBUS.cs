using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientBlockChain.BL
{
    class ExchangeBUS
    {
        private String URL = DataStatic.urlHost;

        public String LoginAccount(String username, String password)
        {
            String token = "";

            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api.php/LoginAccount?username=" + username + "&password=" + password));
            FileRead1 file = JsonConvert.DeserializeObject<FileRead1>(response);
            if (file.SUCCESS)
            {
                return file.DATA;
            }
            else
            {
                MessageBox.Show(file.DATA);
                return token;
            }
        }

        public bool CreateAccount(String username, String password, String name, String address, String phone)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api.php/CreateAccount?username=" + username + "&password=" + password + "&name=" + name + "&address=" + address + "&phone=" + phone));
            FileRead1 file = JsonConvert.DeserializeObject<FileRead1>(response);
            MessageBox.Show(file.DATA);
            return file.SUCCESS;
        }

        public bool ChangePassAccount(String username, String oldpass, String newpass)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api.php/ChangePassAccount?username=" + username + "&oldpass=" + oldpass + "&newpass=" + newpass));
            FileRead1 file = JsonConvert.DeserializeObject<FileRead1>(response);
            MessageBox.Show(file.DATA);
            return file.SUCCESS;
        }

        public bool CheckAccountExchange(String username, String token)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api.php/CheckAccountExchange?username=" + username + "&token=" + token));
            FileRead1 file = JsonConvert.DeserializeObject<FileRead1>(response);
            return file.SUCCESS;
        }

        public String CheckAccountTransfer(String username)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api.php/CheckAccountTransfer?username=" + username));
            FileRead2 file = JsonConvert.DeserializeObject<FileRead2>(response);
            if(file.SUCCESS)
            {
                return file.DATA.NAME;
            }
            else
            {
                MessageBox.Show(file.DATA.ERROR);
                return "";
            }
        }

        public bool CreateAccountExchange(String username, String token)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api.php/CreateAccountExchange?username=" + username + "&token=" + token));
            FileRead1 file = JsonConvert.DeserializeObject<FileRead1>(response);
            MessageBox.Show(file.DATA);
            return file.SUCCESS;
        }
        public bool RechargeAccountExchange(String username, String token, String amount)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api.php/RechargeAccountExchange?username=" + username + "&token=" + token + "&amount=" + amount));
            FileRead1 file = JsonConvert.DeserializeObject<FileRead1>(response);
            MessageBox.Show(file.DATA);
            return file.SUCCESS;
        }

        public bool TransferAccountExchange(String username1, String token, String username2, String amount)
        {
            WebClient client = new WebClient();

            /* GetSelectByName_HttpGet */
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "utf-8");
            client.Encoding = Encoding.UTF8;
            String response = client.DownloadString(new Uri(URL + "api.php/TransferAccountExchange?username1=" + username1 + "&token=" + token+"&username2="+username2+"&amount="+amount));
            FileRead1 file = JsonConvert.DeserializeObject<FileRead1>(response);
            MessageBox.Show(file.DATA);
            return file.SUCCESS;
        }

        class FileRead1
        {
            public bool SUCCESS { get; set; }
            public String DATA { get; set; }
        }

        class Data
        {
            public String NAME { get; set; }
            public String PHONE { get; set; }
            public String ERROR { get; set; }
        }

        class FileRead2
        {
            public bool SUCCESS { get; set; }
            public Data DATA { get; set; }
        }
    }
}
