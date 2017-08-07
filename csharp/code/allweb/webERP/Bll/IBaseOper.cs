using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webERP.Bll
{
    public interface IBaseOper<T>
    {
        void Add(T t);
        void Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
        T Update(T t);
    }
}
