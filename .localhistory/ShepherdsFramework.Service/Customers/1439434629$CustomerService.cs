using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdsFramework.Core;
using ShepherdsFramework.Core.Domain;
using ShepherdsFramework.Data;


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
        /// <param name="isDelete">是否删除标记</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页的信息条数</param>
        /// <returns></returns>
        public virtual IPageList<Customer> GetAllCustomers(bool isDelete = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _CustomerRepository.Table;
            query = query.Where(q => !q.IsDelete);
            query = query.OrderByDescending(q => q.CreateTime);
            var customer = new PageList<Customer>(query,pageIndex,pageSize);
            return customer;
        }
        /// <summary>
        /// 获取一个用户对象
        /// </summary>
        /// <param name="customerId">用户Id</param>
        /// <returns></returns>
        public virtual Customer GetCustomerById(int customerId)
        {
            if (customerId == 0) return null;
            return _CustomerRepository.GetById(customerId);
        }


    }
}
