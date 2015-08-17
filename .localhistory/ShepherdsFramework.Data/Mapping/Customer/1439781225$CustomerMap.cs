﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Data.Mapping.Customer
{
    public partial class CustomerMap : ShepherdsFrameworkEntityTypeConfiguration<ShepherdsFramework.Core.Domain.Customer.Customer>
    {
        /// <summary>
        /// 将用户模型映射到数据实体中
        /// </summary>
        public CustomerMap()
        {
            this.ToTable("Customer");
            this.HasKey(c => c.Id);
            this.Property(c => c.Username).HasMaxLength(10);
            this.Property(c => c.Email).HasMaxLength(50);
            this.Property(c => c.Phone).HasMaxLength(11);
            this.Property(c => c.Avtar).HasMaxLength(100);
        }
    }
}
