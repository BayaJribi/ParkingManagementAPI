using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessProject.Connection
{
    public class DBConnection
    {
        public SqlConnection _sqlConnection;
        private static  DBConnection _Instance;
        public  string ConnectionString = "Data Source=BAYYA-LAPTOP;Initial Catalog=SmartParking;Integrated Security=True";
        public DBConnection()
        {
           _sqlConnection= new SqlConnection(ConnectionString);
        }
        public static DBConnection getInstance()
        {
            if(_Instance==null)
                return new DBConnection();
            return _Instance;
        }

    }
}
