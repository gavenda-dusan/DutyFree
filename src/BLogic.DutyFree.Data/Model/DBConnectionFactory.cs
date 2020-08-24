using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DutyFree.Data.Model
{
    public class DBConnectionFactory : IDBConnectionFactory
    {
        public IDbConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
        }
    }
}
