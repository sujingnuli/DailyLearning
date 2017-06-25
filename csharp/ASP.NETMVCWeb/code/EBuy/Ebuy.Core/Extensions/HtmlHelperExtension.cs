using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtension
    {
        public static HtmlString TextBoxAccessible(this HtmlHelper html, string id, string text)
        {
           
            return new HtmlString("<span>"+id+"</span><input name='id' value='"+text+"'/>");
           
        }
    }
}
