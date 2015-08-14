using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShepherdsFramework.Core.Domain;
using ShepherdsFramework.Framework.Validator;

namespace ShepherdsFramework.Web.Validators
{
    /// <summary>
    /// 通过FluentValidation组件验证服务端规则
    /// </summary>
    public class CustomerValidator:BaseValidator<Customer>
    {
        public CustomerValidator()
        {

        }
    }
}