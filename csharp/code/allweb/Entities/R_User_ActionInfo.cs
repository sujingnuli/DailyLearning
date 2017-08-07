using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class R_User_ActionInfo
    {
        public R_User_ActionInfo() { }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int ActionInfoId { get; set; }
        public bool HasPermission { get; set; }
        public virtual User User { get; set; }
        public virtual ActionInfo ActionInfo { get; set; }

    }
}
