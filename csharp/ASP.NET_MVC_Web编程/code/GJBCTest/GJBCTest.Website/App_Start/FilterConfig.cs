using GJBCTest.Website.Filters;
using System.Web;
using System.Web.Mvc;

namespace GJBCTest.Website
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MyAuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}