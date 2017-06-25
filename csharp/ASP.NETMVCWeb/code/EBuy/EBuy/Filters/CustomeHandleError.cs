using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBuy.Filters
{
    public class CustomeHandleError:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null) {
                base.OnException(filterContext);
            }
            LogException(filterContext.Exception);
            if (filterContext.HttpContext.IsCustomErrorEnabled)
            {
                filterContext.ExceptionHandled = true;
                new CustomWebRequestErrorEvent("An unhandled exception has occured", "this", 103005, filterContext.Exception).Raise();
            }
            
        }
        private void LogException(Exception ex) {
            EventLog log = new EventLog();
            log.Source = "Ebuy";
            log.WriteEntry(ex.Message);
        }
    }
}