using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ebuy.Core.Clz
{
   
    /// <summary>
    /// 自定义依赖解析器
    /// Resolver:解析器
    /// </summary>
    public class CustomDependencyResolver:IDependencyResolver
    {
        private readonly IKernel _kernel;
        public CustomDependencyResolver(IKernel kernel) {
            _kernel = kernel;
        }
        public object GetService(Type serviceType) {
            return _kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType) {
            return _kernel.GetAll(serviceType);
        }
    }
}
