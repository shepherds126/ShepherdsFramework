using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdsFramework.Core;
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

        public CustomerService(IRepository<Customer> customerRepository)
        {
            this._CustomerRepository = customerRepository;
        }

        public virtual IPageList<Customer> GetAllCustomers(bool isDelete = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _CustomerRepository.Table;
            query = query.Where(q => !q.IsDelete);
            query = query.OrderByDescending(q=>q.CreateTime)
        }


    }
}
