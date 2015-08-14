using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;
using ShepherdsFramework.Core;

namespace ShepherdsFramework.Model.Customers
{
    public class Customer:BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Avtar { get; set; }
    }
}
