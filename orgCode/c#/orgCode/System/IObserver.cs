using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /**
     * 逆变的
     * */
    public interface IObserver<in T>
    {
        void OnNext(T value);
        void OnError(Exception error);
        void OnComplete();
    }
}
