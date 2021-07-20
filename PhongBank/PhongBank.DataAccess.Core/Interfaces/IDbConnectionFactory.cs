using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PhongBank.DataAccess.Core.Interfaces
{
   public interface IDbConnectionFactory
    {
        IDbConnection GetConnection(string connectionString);
    }
}
