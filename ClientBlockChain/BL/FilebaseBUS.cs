using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientBlockChain.BL
{
    class FilebaseBUS
    {
        private const String FIREBASE_APP = DataStatic.urlFirebase;
        static IFirebaseConfig config = new FirebaseConfig { BasePath = FIREBASE_APP };
        static FirebaseClient client = new FirebaseClient(config);

        public async void ListenFirebaseToken()
        {
            EventStreamResponse response = await client.OnAsync("account/" + DataStatic.USERNAME + "/token",

                changed: (sender, args, context) => { CheckToken(); });

        }

        private void CheckToken()
        {
            if (GetToken() != DataStatic.TOKEN)
            {
                Exchange.exchange.CheckLogin(true);
            }
        }

        private String GetToken()
        {
            FirebaseResponse response = client.Get("account/" + DataStatic.USERNAME+"/token");
            String token = response.ResultAs<String>();
            return token;
        }

        public async void ListenFirebaseDataGridView(DataGridView dataGridView,TextBox textBox)
        {
            EventStreamResponse response = await client.OnAsync("exchange/" + DataStatic.USERNAME,

                added: (sender, args, context) => {
                    List<Data> animals = GetALL();
                    dataGridView.BeginInvoke(new MethodInvoker(delegate {
                        dataGridView.DataSource = animals;
                        textBox.Text = animals[animals.Count - 1].amount;
                    }));
                });

        }

        public List<Data> GetALL()
        {
            FirebaseResponse response = client.Get("exchange/"+DataStatic.USERNAME);
            Dictionary<String, ExchngeClass> dictAnimals = response.ResultAs<Dictionary<String, ExchngeClass>>();
            List<Data> datas = new List<Data>();
            for(int i = 0; i < dictAnimals.Values.ToList().Count; i++)
            {
                datas.Add(dictAnimals.Values.ToList()[i].data);
            }
            return datas;
        }

        public class ExchngeClass
        {
            public Data data { get; set; }
            //public String hash { get; set; }
            //public int index { get; set; }
            //public int nonce { get; set; }
            //public String previousHash { get; set; }
            //public int timestamp { get; set; }
        }

        public class Data
        {
            public String amount { get; set; }
            public String result { get; set; }
            public String time { get; set; }
        }
    }
}
