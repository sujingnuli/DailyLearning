using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestWeb.cs;
using TestWeb.cs.control;
using TestWeb.cs.control.inter;
using TestWeb.cs.Sqlcs;

namespace TestWeb.html
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                DataTable dt = GetAllImpl.GetAllData(SqlStr.TEMNU_STR);
                string li = HtmlUtil.GetUlStr(dt,"top_menu");
                this.divMenu.InnerHtml = li;
            }
        }
     
     
    }
}