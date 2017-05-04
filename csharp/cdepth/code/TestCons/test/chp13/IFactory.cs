using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp13
{
    /**
     * 泛型的协变性
     * 操作项的返回值
     * */
    public interface IFactory<T>
    {
         T CreateInstace();
    }
}
