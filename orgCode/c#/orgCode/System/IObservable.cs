using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /**
     * 协变
     * */
    public interface IObservable<out T>
    {
        IDisposable Subscribe(IObserver<T> observer);
    }
}
