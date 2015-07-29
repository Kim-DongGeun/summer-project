using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace WindowsFormsApplication1
{
    class DBManager
    {
        private static DBManager instance;
        private MySqlConnection con;
        private DBManager()
        {
            string cs = @"server=data.khuhacker.com;userid=serverstudy;password=serverstudy!@#;database=serverstudy;charset=utf8";
            con = new MySqlConnection(cs);
            con.Open();
        }
        public static DBManager getInstance()
        {
            if (instance == null)
            {
                instance = new DBManager();
            }
            return instance;
        }
        public MySqlConnection getDBConnection()
        {
            return con;
        }
    }
}
