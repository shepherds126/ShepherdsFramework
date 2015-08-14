using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShepherdsFramework.Service.Customers;

namespace ShepherdsFramework.Web.Controllers
{
    public partial class CustomerController : Controller
    {

        private readonly ICustomersService _customerService;
        //
        // GET: /Customer/
        public CustomerController()
        {

        }

        public ActionResult Index()
        {
            var customers = _customerService.GetAllCustomers();
            return View(customers);
        }

    }
}
