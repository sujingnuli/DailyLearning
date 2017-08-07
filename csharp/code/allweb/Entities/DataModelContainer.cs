using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DataModelContainer:DbContext
    {
        public DataModelContainer() : base("name=ErpDbContext") { }

        public DbSet<ActionGroup> ActionGroup { get; set; }
        public DbSet<ActionInfo> ActionInfo { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<R_User_Role> R_User_Role { get; set; }
        public DbSet<R_User_ActionInfo> R_User_ActionInfo { get; set; }
        public DbSet<EntryUser> EntryUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
