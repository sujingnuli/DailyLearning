using Ebuy.Common.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBuy.Controllers
{
    public class baseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null) {
                base.OnException(filterContext);
            }
            Logger.LogException(filterContext.Exception);
            if (filterContext.HttpContext.IsCustomErrorEnabled) {
                filterContext.ExceptionHandled = true;
                this.View("Error").ExecuteResult(this.ControllerContext);
            }
        }
    }
}
