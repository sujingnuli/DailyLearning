using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace EBuy.Extension
{
    public static class HtmlHelperExtension
    {
        public static HtmlString TextBoxAccessible(this HtmlHelper html, string id, string text) {
            return new HtmlString(html.Label(id) + html.TextBox(id, text).ToString());
        }
    }
}