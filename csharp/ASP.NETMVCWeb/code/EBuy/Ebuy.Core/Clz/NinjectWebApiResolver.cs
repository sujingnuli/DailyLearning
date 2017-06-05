using Ebuy.Common.Inter;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace Ebuy.Common.Clz
{
    public  class NinjectWebApiResolver:NinjectWebApiScope,IDependencyResolver
    {
        private IKernel kernel;
        public NinjectWebApiResolver(IKernel kernel):base(kernel) {
            this.kernel = kernel;
        }
        
        public IDependencyScope BeginScope() {
            return new NinjectWebApiScope(kernel.BeginBlock());
        }
    }
}
