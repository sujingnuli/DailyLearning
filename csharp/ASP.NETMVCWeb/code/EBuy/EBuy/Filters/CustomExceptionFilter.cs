using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace EBuy.Filters
{
    public class CustomExceptionFilter:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context == null) {
                context.Response = new HttpResponseMessage();
            }
            context.Response.StatusCode = HttpStatusCode.NotFound;
            context.Response.Content = new StringContent("Custome Message");
            base.OnException(context);
        }
    }
}