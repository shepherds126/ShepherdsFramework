using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShepherdsFramework.Data
{
    /// <summary>
    /// 扩展EF6 引发的DbEntityValidationException
    /// </summary>
    public static class ExceptionExtension
    {
        public static DbEntityValidationException ThrowDbEntityValidationException(this DbEntityValidationException e)
        {
            var errorMessage = e.GetValidationErrorMessage();
            var result = new DbEntityValidationException(errorMessage,e.EntityValidationErrors);
            return result;
        }
        /// <summary>
        /// 获得validateerrormessage
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetValidationErrorMessage(this DbEntityValidationException e)
        {
            string result = "";
            var errorMessage = e.EntityValidationErrors.Select(q => q.GetValidationResult())
                .Aggregate(string.Empty, (current, next) => $"{current}{Environment.NewLine}{next}");
            result = $"{e}{Environment.NewLine}Validation Errors:{errorMessage}";
            return result;
        }

        /// <summary>
        /// 获得验证结果
        /// </summary>
        /// <param name="validationResult"></param>
        /// <returns></returns>
        public static string GetValidationResult(this DbEntityValidationResult validationResult)
        {
            string result = "";
            var entityName = $"[{validationResult.Entry.Entity.GetType().Name}]";
            string indentation = "\t - ";
            var errorMessage =
                validationResult.ValidationErrors.Select(p => $"[{p.PropertyName} - {p.ErrorMessage}]")
                    .Aggregate(string.Empty, (current, text) => current + (Environment.NewLine + indentation + text));
            result = $"{entityName}{errorMessage}";
            return result;
        }

   
    }
}
