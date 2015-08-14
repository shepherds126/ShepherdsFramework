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
    /// 用户会员业务逻辑处理
    /// </summary>
    public class CustomerService : ICustomersService
    {
        public readonly IRepository<Customer> _CustomerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            this._CustomerRepository = customerRepository;
        }
        /// <summary>
        /// 获取所有的会员信息
        /// </summary>
        /// <param name="isDelete"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public virtual IPageList<Customer> GetAllCustomers(bool isDelete = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _CustomerRepository.Table;
            query = query.Where(q => !q.IsDelete);
            query = query.OrderByDescending(q => q.CreateTime);
            var customer = new PageList<Customer>(query,pageIndex,pageSize);
            return customer;
        }


    }
}
