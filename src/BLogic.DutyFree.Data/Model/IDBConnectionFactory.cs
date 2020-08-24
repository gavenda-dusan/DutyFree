using System.Data;

namespace DutyFree.Data.Model
{
    public interface IDBConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
