using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ebuy.Common.Extensions
{
    public static class CacheExtension
    {
        public delegate string CacheCallback(HttpContextBase context);

        public static object Substitution(this HtmlHelper html,CacheCallback ccb){
            html.ViewContext.HttpContext.Response.WriteSubstitution(c =>
            {
              return  HttpUtility.HtmlEncode(ccb(new HttpContextWrapper(c)));
            });
            return null;
        }
    }
}
