using System;
using Leo.Blog.DAL.SysModule;
using Leo.Blog.Model;
using Leo.Blog.ViewModel.SysModule;

namespace Leo.Blog.BLL.SysModule
{
    public class Sys_Account_B
    {
        private  Sys_Account_D _sysAccountD = new Sys_Account_D();
        public UserAccountVM Login(string userId, string password)
        {
            Sys_Account account = _sysAccountD.FindSingle(m => m.Account == userId&&m.Password==password);
            if (account == null)
            {
                throw new Exception("账号或密码错误");
            }
            //账号密码正确，查找各种权限组织
            UserAccountVM accountVM = new UserAccountVM();

            return accountVM;

        }
    }
}
