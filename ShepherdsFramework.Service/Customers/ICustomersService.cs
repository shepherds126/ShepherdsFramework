using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShepherdsFramework.Core;
using ShepherdsFramework.Core.Domain;


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


    }
}
