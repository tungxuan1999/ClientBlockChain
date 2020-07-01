using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientBlockChain
{
    class DataStatic
    {
        //public const String urlHost = "http://localhost:81/phpblockchain/";
        public const String urlHost = "https://phpblockchain.herokuapp.com/";
        public const String urlFirebase = "https://demoblockchain.firebaseio.com/";
        public static String TOKEN { get; set; }
        public static String USERNAME { get; set; }
    }
}
