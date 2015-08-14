using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using ShepherdsFramework.Core;
namespace ShepherdsFramework.Data
{
    public class SqlServerDataProvider : IDataProvider
    {

        public virtual void InitConnectionFactory()
        {
            var connectionFactory = new SqlConnectionFactory();
            Database.DefaultConnectionFactory = connectionFactory;
        }

        public virtual void InitDatabase()
        {
        }

        public virtual void SetDatabaseInitializer()
        {

        }
    }
}
