using Autofac;
using PhongBank.DataAccess.Core;
using PhongBank.DataAccess.Core.Interfaces;
using PhongBank.DataAccess.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhongBank.DataAccess.Dapper
{
    public class DataAccessBootstrapper
    {
        public static void Register(ContainerBuilder builder, DatabaseConfig config)
        {
            builder.RegisterType<DbConnectionFactory>().As<IDbConnectionFactory>();
            builder.RegisterType<CustomerRepository>().As<CustomerRepository>().WithParameter("config", config);
        }
    }
}
