using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace TestWeb.cs
{
    public class HtmlUtil
    {
        public static string GetUlStr(DataTable dt,string id) {
            StringBuilder sb = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0) {
                id = id == null ? string.Format("ul_{0}", new Random().Next(1000)) : id;
               sb.AppendFormat("<ul id='{0}'>",id);
                foreach (DataRow dr in dt.Rows) {
                    sb.AppendFormat("<li value='{1}'>{0}</li>", dr[0],dr[1]);   
                }
                sb.Append("</ul>");
            }
            return sb.ToString();
        }
    }
}