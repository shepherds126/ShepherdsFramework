using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShepherdsFramework.Core.Domain.Customer;
using ShepherdsFramework.Core.Tool;

namespace ShepherdsFramework.Service.Customers
{
    /// <summary>
    /// 用户密码辅助类
    /// </summary>
    public class UserPasswordHelper
    {
        /// <summary>
        /// 检查用户密码是否正确
        /// </summary>
        /// <param name="password">明码</param>
        /// <param name="stroedpassword">暗码</param>
        /// <param name="passwordFormat">存储格式</param>
        /// <returns></returns>
        public static bool CheckPassword(string password, string stroedpassword, UserPasswordFormat passwordFormat)
        {
            string encodedpassword = EncodePassword(password, passwordFormat);
            if (encodedpassword != null)
                return encodedpassword.Equals(stroedpassword, StringComparison.CurrentCultureIgnoreCase);
            else return false;
        }

        /// <summary>
        /// 对用户密码进行编码
        /// </summary>
        /// <param name="password">明码</param>
        /// <param name="passwordFormat">密码的存储格式</param>
        /// <returns></returns>
        public static string EncodePassword(string password, UserPasswordFormat passwordFormat)
        {
            if (passwordFormat == UserPasswordFormat.MD5)
                return EncryptionUtility.MD5(password);
            return password;
        }
    }
}
