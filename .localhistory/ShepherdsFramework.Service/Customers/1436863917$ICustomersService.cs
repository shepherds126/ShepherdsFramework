using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShepherdsFramework.Core;
using ShepherdsFramework.Model.Customers;

namespace ShepherdsFramework.Service.Customers
{
    public interface ICustomersService
    {
        IPageList<Customer> GetAllCustomers(bool isDelete = false,int pageIndex = 0,int pageSize = int.MaxValue);
    }
}
