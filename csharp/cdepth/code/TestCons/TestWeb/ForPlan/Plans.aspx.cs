using DBcs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestWeb.cs.Bean;

namespace TestWeb.ForPlan
{
    public partial class Plans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PlanBean bean = new PlanBean();
            DataTable dt=selectPlan(bean,"tplan",null);
            string table=GetTableStr(dt).Replace("\r\n","<br/>");
            ScriptManager.RegisterStartupScript(this,this.GetType(),"","TbAp('"+table+"')",true);
            //this.HidTab.Value = table;
            BindNames();
        }
        protected void BtnSave_Click(object sender, EventArgs e) {
            var hidOp = this.HidOp.Value;
           var id = this.addno.Text.Trim();
           id = id == "" ? "0" : id;
            //var name = this.addName.Text.Trim();
            //var date = this.addDate.Text.Trim();
            //var statu = this.AddStatu.Checked;
            PlanBean bean=new PlanBean{
                id=Convert.ToInt32(id),
                Name=addName.Text.Trim(),
                Date=addDate.Text.Trim(),
                Content=addContent.Text.Trim(),
                Status=this.AddStatu.Checked
            };
            if (hidOp.Equals("1")) { AddPlan(bean); }
            else if (hidOp.Equals("2")) { UpdatePlan(bean); }
        }
        private void BindNames() {
            SelectType("tplan", "Name");
        }
        private void AddPlan(PlanBean bean) {
            AddPlan(bean,"tplan");
        }
        private void UpdatePlan(PlanBean bean) {
            UpdatePlan(bean,"tplan",bean.id);
        }   
        private void AddPlan<T>(T t,string table) {
            PropertyInfo[] properties = t.GetType().GetProperties();
            StringBuilder keys = new StringBuilder();
            StringBuilder values = new StringBuilder();
            int i = 1, len = properties.Length; ;
            foreach (PropertyInfo prop in properties) {
                var name = prop.Name;
                var value = prop.GetValue(t, null);
                if (i != 1)
                {
                    var sp = i == len ? "" : ",";
                    keys.Append(name + sp);
                    values.Append("'" + value + "'" + sp);
                }
                i++;
            }
            
            string sql = string.Format("insert into {0}({1}) values({2})", table, keys.ToString(), values.ToString());
            DBWZHelper.GetScalar(sql);
        }
        private void UpdatePlan<T>(T t,string table,int key) {
            PropertyInfo[] properties = t.GetType().GetProperties();
            StringBuilder kv = new StringBuilder();
            int i = 1, len = properties.Length;
            foreach (PropertyInfo prop in properties) {
                var name = prop.Name;
                var value = prop.GetValue(t, null);
                value = value == null ? null : "'" + value + "'";
                string str = i == len ? "{0}='{1}'" : "{0}='{1}',";
                kv.AppendFormat(str, name, value);
            }
            string sql = string.Format("update {0} set {1} where id='{2}'",table, kv.ToString(),key);
            DBWZHelper.GetScalar(sql);
        }
        private DataTable selectPlan<T>(T t, string table,string where) {
            PropertyInfo[] properties = t.GetType().GetProperties();
            StringBuilder sb=new StringBuilder();
            int i = 1, len = properties.Length;
            foreach (PropertyInfo prop in properties) { 
                var name=prop.Name;
                var end = i == len ? "" : ",";
                sb.Append(name).Append(end);
                i++;
            }
            string sql = string.Format("select {0} from {1}", sb.ToString(), table);
           
            if (where != null)
            {
                sql += " where " + where;
            }
            return DBWZHelper.GetReader(sql);
        }
        protected string GetTableStr(DataTable dt) {
            StringBuilder trs = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                trs.Append("<tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    trs.AppendFormat("<td>{0}</td>", dr[dc.ColumnName]);
                }
                trs.Append("</tr>");
            }

            return string.Format("{0}",trs);
            
        }
        protected void SelectType(string table,string type) {
            string sql = string.Format("select {0} from {1}", type, table);
            DataTable dt= DBWZHelper.GetReader(sql);
            this.DdlNames.DataSource = dt;
            this.DdlNames.DataTextField = type;
            this.DdlNames.DataValueField = type;
            this.DdlNames.DataBind();
        }
        private void DdlNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = this.DdlNames.Text;

            DataTable dt= selectPlan(new PlanBean(),"tplan", string.Format(" name like '%{0}%'", name));
            string table = GetTableStr(dt);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "TbAp('" + table + "')", true);
        }
    }
}