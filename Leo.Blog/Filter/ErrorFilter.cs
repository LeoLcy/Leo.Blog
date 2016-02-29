using Leo.Blog.Common.LogHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leo.Blog.Filter
{
    //在过滤器中定义异常捕获，需要注册到全局环境中去应用到所有controller
    public class ErrorFilter : ActionFilterAttribute, IExceptionFilter 
    {
        public void OnException(ExceptionContext filterContext)
        {
            //获取异常信息
            Exception Error = filterContext.Exception;
            string Message = Error.Message;//错误信息 
            string Url = HttpContext.Current.Request.RawUrl;//错误发生地址 
            filterContext.ExceptionHandled = true;//标记异常已处理
            //filterContext.Result = new RedirectResult("/Error/Show/");//跳转至错误提示页面 
            Log4netHelper.Info(Url + "\n" + Message);
        }  
    }
}