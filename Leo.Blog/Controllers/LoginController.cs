using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Leo.Blog.BLL.SysModule;
using Leo.Blog.Common;
using Leo.Blog.ViewModel.SysModule;

namespace Leo.Blog.Controllers
{
    public class LoginController : BaseController
    {
        private Sys_Account_B _accountB= new Sys_Account_B();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VerifyImage()
        {
            string code = (new VerifyImage()).GenerateCheckCode();
            Session["ValidateCode"] = code;
            byte[] bytes = new VerifyImage().CreateCheckCodeImage(code);
            return File(bytes, "image/jpeg");
        }
        [HttpPost]
        public ActionResult Index(LoginVM model)
        {
            string password = model.Password;
            UserAccountVM accountVM = _accountB.Login(model.UserId, password);
            UserId = model.UserId;
            return View();
        }
    }
}