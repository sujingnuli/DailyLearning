using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class R_User_Role
    {
        public R_User_Role() { }

        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
        public DateTime SubTime { get; set; }

    }
}
