using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShepherdsFramework.Core;
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

        public AccountController(IWorkContext workContext,ICustomersService customersService)
        {
            this._workContext = workContext;
            this._customersService = customersService;
        }

        /// <summary>
        /// 登录的页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            string returnUrl = Request.QueryString.Get("returnUrl");
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
            if (!ModelState.IsValid)
            {
                model.Password = "";
                return View(model);
            }
            return View();
        }

    }
}