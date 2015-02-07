using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpResultToObjectModel.DAL
{
    public class ConnectionProvider
    {
        private static ConnectionProvider instance;
        private static object lockObject = new object();
        private SqlConnection sqlConnection;

        public static ConnectionProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance = new ConnectionProvider();
                    }
                }
                return instance;
            }
        }

        public SqlConnection Connection
        {
            get
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                return sqlConnection;
            }
        }

        private ConnectionProvider()
        {
            sqlConnection = new SqlConnection("Server=BTUGDENIZNB; Database=Sample; Trusted_Connection=True;");
        }
    }
}
