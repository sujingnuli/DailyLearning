using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Common.Inter
{
    public interface ISearchProvider
    {
        List<T> Search<T>(string criteria);
    }
}
