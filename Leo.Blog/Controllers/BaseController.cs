using Leo.Blog.Common.LogHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leo.Blog.Controllers
{
    public class BaseController : Controller
    {
        private string _userId = string.Empty;
        public string UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                this._userId = value;
            }
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
            }
            else
            {
                _userId = this.User.Identity.Name;
            }
            base.OnAuthorization(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            //获取异常信息
            Exception Error = filterContext.Exception;
            string Message = Error.Message;//错误信息 
            string Url = filterContext.HttpContext.Request.RawUrl;//错误发生地址 
            filterContext.ExceptionHandled = true;
            //filterContext.Result = new RedirectResult("/Error");//跳转至错误提示页面 
            Log4netHelper.Info(DateTime.Now+":"+ Url + "\n" + Message);
        }
    }
}