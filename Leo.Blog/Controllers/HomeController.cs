using Leo.Blog.Common.LogHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leo.Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            //获取异常信息
            Exception Error = filterContext.Exception;
            string Message = Error.Message;//错误信息 
            string Url = filterContext.HttpContext.Request.RawUrl;//错误发生地址 
            filterContext.ExceptionHandled = true;
            //filterContext.Result = new RedirectResult("/Error/Show/");//跳转至错误提示页面 
            Log4netHelper.Info(Url + "\n" + Message);
        }
    }
}