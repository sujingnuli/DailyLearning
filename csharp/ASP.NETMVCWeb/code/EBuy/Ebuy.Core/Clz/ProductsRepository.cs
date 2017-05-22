using Ebuy.Core.Inter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Core.Clz
{
    public class ProductsRepository<T>:ISearchProvider,IRepository<T>
    {
        public T GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T product)
        {
            throw new NotImplementedException();
        }

        public void Save(T product)
        {
            throw new NotImplementedException();
        }

        public List<T> Search<T>(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}
