
using System.Data;
using System.Data.SqlClient;
using PhongBank.Core;
using PhongBank.DataAccess.Core.Interfaces;

namespace PhongBank.DataAccess.Dapper.Repositories
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
