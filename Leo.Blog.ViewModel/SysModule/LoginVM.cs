using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.Blog.ViewModel.SysModule
{
    /// <summary>
    /// 登录
    /// </summary>
    public class LoginVM
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string ValidCode { get; set; }
    }
    /// <summary>
    /// 存放登录成功后个人信息，包括所属角色，组织，模块
    /// </summary>
    public class UserAccountVM
    {

    }
}
