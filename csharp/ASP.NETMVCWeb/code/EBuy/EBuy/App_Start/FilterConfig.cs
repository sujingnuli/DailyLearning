﻿using EBuy.Filters;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace EBuy
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomeHandleError());
            filters.Add(new HandleErrorAttribute());
           // filters.Add(new CustomExceptionFilter());
        }
    }
}