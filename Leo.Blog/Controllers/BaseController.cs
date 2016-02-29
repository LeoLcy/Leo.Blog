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
    }
}