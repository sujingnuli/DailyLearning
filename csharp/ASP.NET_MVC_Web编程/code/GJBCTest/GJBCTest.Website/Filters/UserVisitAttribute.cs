using GJBCTest.Website.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJBCTest.Website.Filters
{
    public class UserVisitAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actions = ConfigurationManager.AppSettings["Index"];
            string[] arraction = actions.Split(',');
            var area=filterContext.RouteData.DataTokens;
            string userId = filterContext.HttpContext.Session["UserId"].ToString();
            string userName = filterContext.HttpContext.Session["UserName"].ToString();
            var areaName = area["area"];
            string controller = filterContext.RouteData.Values["controller"].ToString();
            string action = filterContext.RouteData.Values["action"].ToString();
            string url = "/"+areaName+"/" + controller + "/" + action;
            if (userId != null) {
                ///是否是AJAX请求///
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Controller.ViewBag.returnUrl = url;
                }
                else {
                    filterContext.Controller.ViewBag.returnUrl = url;
                    if (actions.IndexOf(controller) >= 0) {
                        var acurl="/"+controller+"/"+action;
                        foreach (var item in arraction) {
                            if (item.IndexOf("*") >= 0 || item.IndexOf(acurl) >= 0)
                            {

                            }
                        }
                       
                    }
                 }
            }
        }
    }
}