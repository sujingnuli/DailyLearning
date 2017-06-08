using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Common.Entities
{
   public  class CategoriesViewModel:Entity<Guid>
    {
       public ICollection<Category> Categories { get; set; }
       public CategoriesViewModel() {
           Categories = new Collection<Category>();
       }
    }
}
