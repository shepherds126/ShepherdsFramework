﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShepherdsFramework.Core;

using ShepherdsFramework.Core.Domain.Customer;


namespace ShepherdsFramework.Service.Customers
{
    public interface ICustomersService
    {
        /// <summary>
        /// 获取所有的用户信息
        /// </summary>
        /// <param name="isDelete"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPageList<Customer> GetAllCustomers(bool isDelete = false,int pageIndex = 0,int pageSize = int.MaxValue);
        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        CustomerLoginResult ValidateCustomer(string username, string password);
        /// <summary>
        /// 利用手机或邮箱获取用户
        /// </summary>
        /// <param name="phoneoremail"></param>
        /// <returns></returns>
        Customer GetCustomerByEmailOrPhone(string phoneoremail);
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        void InsertCustomer(Customer customer);


    }
}
