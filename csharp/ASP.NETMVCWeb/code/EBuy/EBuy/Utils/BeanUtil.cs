using DAL;
using System;
using System.Collections.Generic;
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
        private static object HackInsObj(object value, string type) {
            if (type.Equals("string")) {
                value = value == null || string.IsNullOrEmpty(value.ToString()) ? null : value;
            }
            return value;
        }
    }
}