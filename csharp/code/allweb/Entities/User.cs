using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public User() { }
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string UName { get; set; }
        [Required]
        [RegularExpression("[1-9][0-9]{5}", ErrorMessage = "密码为非0开头6位数字")]
        public string Pwd { get; set; }
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage="邮箱格式不对")]
        public string Mail { get; set; }
        public short DelFlag { get; set; }
        public DateTime SubTime { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public virtual ICollection<EntryUser> EntryUser { get; set; }
        public virtual ICollection<ActionGroup> ActionGroup { get; set; }
        public virtual ICollection<R_User_Role> R_User_Role { get; set; }
        public virtual ICollection<R_User_ActionInfo> R_User_ActionInfo { get; set; }
    }
}
