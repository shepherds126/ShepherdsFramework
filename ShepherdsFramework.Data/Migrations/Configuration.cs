using ShepherdsFramework.Core.Domain.Customer;

namespace ShepherdsFramework.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShepherdsFramework.Data.ShepherdsFrameworkDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShepherdsFramework.Data.ShepherdsFrameworkDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Customer[] customersarr = new Customer[2];
            customersarr[0] = new Customer()
            {
                Password = "123456",
                Phone = "12345678911",
                Username = "shepherds",
                CreateTime = DateTime.Now
            };
            customersarr[1] = new Customer()
            {
                Password = "123456",
                Phone = "13316070024",
                Username = "liganggang",
                CreateTime = DateTime.Now
            };
            context.Set<Customer>().AddOrUpdate(customersarr);
            
        }
    }
}
