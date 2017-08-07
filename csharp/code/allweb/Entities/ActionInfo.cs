using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ActionInfo
    {
        public ActionInfo() { }

        public int Id { get; set; }
        public string ActionName { get; set; }
        public short ActionType { get; set; }
        public DateTime SubTime { get; set; }
        public string RequestHttpType { get; set; }
        public string RequestUrl { get; set; }
        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<ActionGroup> ActionGroup { get; set; }
        public virtual ICollection<R_User_ActionInfo> R_User_ActionInfo { get; set; }
    }
}
