using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Core.Inter
{
    interface IRepository<T>
    {
        T GetById(string id);
        void Delete(T t);
        void Save(T t);
    }
}
