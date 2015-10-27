using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.Mvc;
using ShepherdsFramework.Core;
using ShepherdsFramework.Core.Domain.Customer;
using ShepherdsFramework.Core.Tool;
using ShepherdsFramework.Framework;
using ShepherdsFramework.Framework.Model;
using ShepherdsFramework.Framework.MVC.Attribute;
using ShepherdsFramework.Framework.Utilities.Captcha;
using ShepherdsFramework.Service.Customers;

namespace ShepherdsFramework.Web.Controllers
{
    public class AccountController:Controller
    {

        private readonly IWorkContext _workContext;
        private readonly ICustomersService _customersService;
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IWorkContext workContext,ICustomersService customersService,IAuthenticationService authenticationService)
        {
            this._workContext = workContext;
            this._customersService = customersService;
            this._authenticationService = authenticationService;
        }

        /// <summary>
        /// 登录的页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            string returnUrl = StringHelper.GetQueryString("returnUrl");
            if (_workContext.CurrentCustomer != null && !string.IsNullOrEmpty(returnUrl)) return Redirect(returnUrl);
            return View(new LoginModel());
        }
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Captcha(VerifyScenarios.Login)]
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            Customer customer = null;
            if (!ModelState.IsValid)
            {
                model.Password = "";
                return View(model);
            }
            CustomerLoginResult customerLoginResult = _customersService.ValidateCustomer(model.UserName,model.Password);
            if (customerLoginResult == CustomerLoginResult.UserNameOrPasswordError)
            {
                model.Password = string.Empty;
                return View(model);
            }
            else
            {
                customer = _customersService.GetCustomerByEmailOrPhone(model.UserName);
            }

            if (customerLoginResult == CustomerLoginResult.Success ||
                customerLoginResult == CustomerLoginResult.NotActivated)
            {
                _authenticationService.SignIn(customer,model.RememberPassword);
            }

            if (customerLoginResult == CustomerLoginResult.Success)
            {
                if (string.IsNullOrEmpty(model.ReturnUrl)) return Redirect("/");
                return Redirect(model.ReturnUrl);
            }else if (customerLoginResult == CustomerLoginResult.Banned)
            {

            }else if (customerLoginResult == CustomerLoginResult.NotActivated)
            {
            }
            model.Password = string.Empty;
            return View(model);
        }

    }
}