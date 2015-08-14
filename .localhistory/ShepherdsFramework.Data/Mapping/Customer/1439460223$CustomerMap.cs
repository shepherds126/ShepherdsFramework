using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdsFramework.Core.Domain;
namespace ShepherdsFramework.Data.Mapping.Customer
{
    public class CustomerMap : ShepherdsFrameworkEntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.ToTable("Customer");
        }
    }
}
