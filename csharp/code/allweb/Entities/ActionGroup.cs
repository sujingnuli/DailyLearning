using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ActionGroup
    {
        public ActionGroup() { }

        public int Id { get; set; }

        public string GroupName { get; set; }

        public short GroupType { get; set; }

        public short DelFlag { get; set; }

        public virtual ICollection<Role> Role { get; set; }

        public virtual ICollection<ActionInfo> ActionInfo { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
