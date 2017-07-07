using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJBCTest.Website.Filters
{
    public class MyAuthorizeAttribute:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var crrAction = ConfigurationManager.AppSettings["Index"];
            
            if (httpContext.Session["UserId"] != null) {
                if (httpContext.Session["UserName"] != null)
                {
                    return true;
                }
                else {
                    return false;
                }
            
            }
            return false;
        }
    }
}