using DBcs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using TestWeb.cs.Sqlcs;

namespace TestWeb.ashx
{
    /// <summary>
    /// GenerableBean 的摘要说明
    /// </summary>
    public class GenerableBean : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //tableName.tableName.ForEach(
            //    name => {
            //        string sql = string.Format("select top(0) * from {0}", name);
            //        DataTable dt=DBWZHelper.GetReader(sql);
            //        if (dt != null && dt.Rows.Count > 0) {
            //            string tableName = name.Split('_').Last();
            //            Type type=Type.GetType(tableName);
            //            foreach (var column in dt.Columns) {
            //                object pro = type.InvokeMember(column.ToString(), BindingFlags.SetProperty, null, null, null);
            //            }
                        
            //        }
            //    }
            // );
         
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}