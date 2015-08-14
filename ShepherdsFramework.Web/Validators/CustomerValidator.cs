using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
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
            this.RuleFor(customer => customer.Username).NotEmpty();
            this.RuleFor(customer => customer.Email).NotEmpty().WithMessage("邮箱不能为空");
            this.RuleFor(customer => customer.Phone).NotEmpty().WithMessage("手机不能为空");
            this.RuleFor(customer => customer.Password).NotEmpty().WithMessage("密码不能为空");
            this.RuleFor(customer => customer.Password).NotEqual(customer => customer.Username);
        }
    }
}