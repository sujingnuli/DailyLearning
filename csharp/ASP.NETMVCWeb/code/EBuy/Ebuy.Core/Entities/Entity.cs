using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Common.Entities
{
    public interface IEntity { 
        
    }
    public class Entity<TId>:IEntity,IEquatable<Entity<TId>>
    {

        public bool Equals(Entity<TId> other)
        {
            throw new NotImplementedException();
        }
    }
}
