using Autofac;
using PhongBank.DataAccess.Core;
using PhongBank.DataAccess.Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhongBank.Services
{
    public class ServicesBootstrapper
    {
        public static void Register(ContainerBuilder builder, DatabaseConfig config)
        {
            builder.RegisterType<CustomerService>().As<ICustomerService>();

            DataAccessBootstrapper.Register(builder, config);
        }
    }
}
