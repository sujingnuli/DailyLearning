using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace Ebuy.Core.Inter
{
    public class NinjectWebApiScope:IDependencyScope
    {
        private IResolutionRoot resolutionRoot;
        public NinjectWebApiScope(IResolutionRoot resolutionRoot) {
            this.resolutionRoot = resolutionRoot;
        }




        public object GetService(Type serviceType)
        {
            return resolutionRoot.Resolve(this.CreateRequest(serviceType)).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return resolutionRoot.Resolve(this.CreateRequest(serviceType));
        }

        public void Dispose()
        {
            resolutionRoot = null;
        }
        private IRequest CreateRequest(Type serviceType) {
            return resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);

        }
    }
}
