using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Erp.DAL
{
    public partial class EFContextFactory
    {
        public static DbContext GetCurrentDbContext()
        {
            DbContext dbContext = CallContext.GetData("DbContext") as DbContext;
            if (dbContext == null) {
                dbContext = new DataModelContainer();
                CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;
        }
    }
}
