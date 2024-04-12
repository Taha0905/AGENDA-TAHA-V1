using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Windows;

namespace agenda_khelifi.Model
{
    public class ConnectionManager
    {
        public string host { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public int port { get; set; }
        public string database { get; set; }


       public string ConString { get { return string.Format("server={0};port={1};user={2};password={3};database={4};", host, port, user, password, database); } }

        public ConnectionManager()
        {
            this.host = ConfigurationManager.AppSettings["host"];
            this.user = ConfigurationManager.AppSettings["user"];
            this.password = ConfigurationManager.AppSettings["password"];
            this.port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            this.database = ConfigurationManager.AppSettings["database"];

        }
    }
}
