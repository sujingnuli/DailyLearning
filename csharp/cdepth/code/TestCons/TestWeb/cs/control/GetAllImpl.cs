using DBcs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TestWeb.cs.control.inter;

namespace TestWeb.cs.control
{
    public class GetAllImpl:IGetAll
    {
        public static DataTable GetAllData(string sql)
        {
            if (string.IsNullOrEmpty(sql)) {
                return null;
            }
            return DBWZHelper.GetReader(sql);
        }
    }
}