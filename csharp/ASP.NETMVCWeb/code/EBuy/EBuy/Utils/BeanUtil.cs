using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace EBuy.Utils
{
    public class BeanUtil
    {
        public static void BeanAdd<T>(T t, string table)
        {
            if (t == null) { return ; }
            StringBuilder keys = new StringBuilder();
            StringBuilder values=new StringBuilder();
            PropertyInfo[] properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo prop in properties) {
                var name = prop.Name;
                var type = prop.PropertyType.Name.ToLower();
                var value = prop.GetValue(t, null);
                value=HackInsObj(value, type);
                if (value != null&&!name.Equals("id")) {
                    keys.AppendFormat("{0},", name);
                    values.AppendFormat("'{0}',", value);
                }
            }
            string key = keys.ToString().TrimEnd(',');
            string val = values.ToString().TrimEnd(',');
            string Instr = string.Format("insert into {0}({1}) values({2})", table, key, val);
             DBWZHelper.GetScalar(Instr);
        }
        public static T GetById<T>(long id,string table){
            string sql = string.Format("select * from {0} where id={1}", table, id);
            DataTable dt=DBWZHelper.GetReader(sql);
            if (dt == null || dt.Rows.Count <= 0) { return default(T); }
            Type type = typeof(T);
            T instance =(T)Activator.CreateInstance(type);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            DataRow dr=dt.Rows[0];
            foreach (PropertyInfo prop in properties) {
                string tp = prop.PropertyType.Name.ToLower();
                string name = prop.Name;
                object value = dr[name];
               value= HackInsObj(value,tp);
                prop.SetValue(instance, value, null);
            }
            return instance;

        }
        public static List<T> GetSelTable<T>(string table, string whereStr, string orderStr) {
            whereStr = string.IsNullOrEmpty(whereStr) ? "" : string.Format(" where {0}", whereStr);
            orderStr = string.IsNullOrEmpty(orderStr) ? "" : string.Format(" order by {1}", orderStr);
            string selStr = string.Format("select * from {0} {1} {2}", table, whereStr, orderStr);
            DataTable dt = DBWZHelper.GetReader(selStr);
            if (dt == null && dt.Rows.Count <= 0) {  return  null; }
            List<T> lists = new List<T>();
            for (int i = 0; i < dt.Rows.Count; i++) {
                DataRow dr = dt.Rows[i];
                Type tp = typeof(T);
                T instance =(T) Activator.CreateInstance(tp);
                PropertyInfo[] properties = tp.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo prop in properties) {
                    string name = prop.Name;
                    string type = prop.PropertyType.Name.ToLower();
                    object value = dr[name];
                    value = HackInsObj(value, type);
                    prop.SetValue(instance, value, null);
                }
                lists.Add(instance);
            }
            return lists;
        }
        private static object HackInsObj(object value, string type) {
            if (type.Equals("string")) {
                value = value == null || string.IsNullOrEmpty(value.ToString()) ? null : value;
            }
            if (type.Equals("datetime")) {
               value= value == null||string.IsNullOrEmpty(value.ToString()) ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(value);
            }
            return value;
        }
    }
}