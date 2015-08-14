using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdsFramework.Data;
using ShepherdsFramework.Model.Customers;

namespace ShepherdsFramework.Service.Customers
{
    /// <summary>
    /// 用户会员逻辑处理
    /// </summary>
    public class CustomerService : ICustomersService
    {
        public readonly IRepository<Customer> _CustomerRepository;
    }
}
