using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserLogin
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [RegularExpression("[1-9][0-9]{5}", ErrorMessage = "密码为非0开头6位数字")]
        public string PassWord { get; set; }
    }
}
