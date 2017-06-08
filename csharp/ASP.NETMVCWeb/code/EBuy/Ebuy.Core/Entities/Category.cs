using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Common.Entities
{
    public class Category:Entity<Guid>
    {
        public object Id { get; set; }
        public string Name { get; set; }
    }
}
