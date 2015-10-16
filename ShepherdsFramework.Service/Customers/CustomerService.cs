using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdsFramework.Core;

using ShepherdsFramework.Core.Domain.Customer;
using ShepherdsFramework.Core.Tool;
using ShepherdsFramework.Data;


namespace ShepherdsFramework.Service.Customers
{
    /// <summary>
    /// 用户会员业务逻辑处理
    /// </summary>
    public class CustomerService : ICustomersService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IDbContext _dbContext;
        public CustomerService(IRepository<Customer> customerRepository,IDbContext dbContext)
        {
            this._customerRepository = customerRepository;
            this._dbContext = dbContext;
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
            var query = _customerRepository.Table;
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
            return _customerRepository.GetById(customerId);
        }
        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <param name="username">账户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public virtual CustomerLoginResult ValidateCustomer(string username, string password)
        {
            Customer customer = null;
            var query = _customerRepository.Table;
            //手机号登录
            if (ValidateHelper.IsMobile(username)) customer = query.FirstOrDefault(q => q.Phone == username);
            //邮箱登录
            else if (ValidateHelper.IsEmail(username)) customer = query.FirstOrDefault(q => q.Email == username);
            if(customer == null) return CustomerLoginResult.UserNameOrPasswordError;
            //密码不正确
            if(!UserPasswordHelper.CheckPassword(password,customer.Password,(UserPasswordFormat)customer.PasswordFormat))
                return CustomerLoginResult.UserNameOrPasswordError;
            //未激活
            if(!customer.Actived) return CustomerLoginResult.NotActivated;
            //禁止
            if(customer.Baned) return CustomerLoginResult.Banned;

            return CustomerLoginResult.Success;
        }


    }
}
