using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShepherdsFramework.Core.Domain.Customer;
using ShepherdsFramework.Service.Customers;

namespace ShepherdsFramework.Web.Controllers
{
    public partial class CustomerController : Controller
    {

        private readonly ICustomersService _customerService;
        //
        // GET: /Customer/
        public CustomerController(ICustomersService customerService)
        {
            this._customerService = customerService;
        }

        public ActionResult Index()
        {
            var customers = _customerService.GetAllCustomers();

            var testcustomer = new Customer()
            {
                Actived = true,
                Avtar = "14324254",
                Baned = false,
                Email = "shepherds@126shepherds126@126.comwqdweefwef",
                Phone = "111111111111111111111111111111111"
            };
            _customerService.InsertCustomer(testcustomer);
            return View(customers);
        }

    }
}
