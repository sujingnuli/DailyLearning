using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Compare
{
    public class EntityCompare:IEqualityComparer<ActionGroup>
    {

        public bool Equals(ActionGroup x, ActionGroup y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(ActionGroup obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
