using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ebuy.Common.Json;

namespace EBuy.Filters
{
    public class MultipleResponseFormatsAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            var request = filterContext.HttpContext.Request;
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult == null) {
                return;
            }
            if (request.IsJsonRequest()) {
                filterContext.Result = new JsonResult
                {
                    Data=viewResult.Model,
                    JsonRequestBehavior=JsonRequestBehavior.AllowGet
                };
            }
            else if (request.IsAjaxRequest()) {
                filterContext.Result = new PartialViewResult
                {
                    TempData=viewResult.TempData,
                    ViewData=viewResult.ViewData,
                    ViewName=viewResult.ViewName
                };
            }
        }
    }
}