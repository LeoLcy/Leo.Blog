//using Leo.Blog.Filter;
using System.Web;
using System.Web.Mvc;

namespace Leo.Blog
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new ErrorFilter());//使用filter需要全局注册ErrorFilter
            filters.Add(new HandleErrorAttribute());
        }
    }
}
