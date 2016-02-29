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
        public List<UserRole> Roles { get; set; }
        public List<UserModule> Modules { get; set; }
        public List<UserOrg> Orgs { get; set; }
    }
    /// <summary>
    /// 用户所分配的角色
    /// </summary>
    public class UserRole
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<UserModule> Modules { get; set; }
    }
    /// <summary>
    /// 用户所分配的模组
    /// </summary>
    public class UserModule
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDesc { get; set; }
        public string WebUrl { get; set; }
        public int ParentModuleId { get; set; }
        public string ParentName { get; set; }
        public int SortNo { get; set; }
        public int IsAutoExpend { get; set; }
        public string IconName { get; set; }
    }
    /// <summary>
    /// 用户所分配的组织
    /// </summary>
    public class UserOrg
    {
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public string OrgDesc { get; set; }
        public int ParentOrgId { get; set; }
        public string ParentName { get; set; }
        public string OrgPath { get; set; }
        public int SortNo { get; set; }
        public int IsAutoExpend { get; set; }
        public string IconName { get; set; }
    }
}
