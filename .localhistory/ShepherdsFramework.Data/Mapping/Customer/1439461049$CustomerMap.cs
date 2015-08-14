using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdsFramework.Core.Domain;
namespace ShepherdsFramework.Data.Mapping.Customer
{
    public class CustomerMap : ShepherdsFrameworkEntityTypeConfiguration<ShepherdsFramework.Core.Domain.Customer>
    {
        public CustomerMap()
        {
            this.ToTable("Customer");
            this.HasKey(c => c.Id);
        }
    }
}
