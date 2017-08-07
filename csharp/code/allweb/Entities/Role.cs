using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class Role
    {
        public Role() { 
        
        }
        public int Id { get; set; }
        public string RoleName { get; set; }
        public short RoleType { get; set; }
        public short DelFlag { get; set; }
        public DateTime SubTime { get; set; }

        public virtual ICollection<R_User_Role> R_User_Role { get; set; }

        public virtual ICollection<ActionInfo> ActionInfo { get; set; }

        public virtual ICollection<ActionGroup> ActionGroup { get; set; }
        
    }
}
