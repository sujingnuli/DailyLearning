using Ebuy.Common.Clz;
using Ebuy.Common.Inter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ebuy.Common.Test
{
   public  class TestDependencyResolver
    {
       /// <summary>
       /// 注册自定义解析器
       /// 通过 System.Web.Mvc.DependencyResolver的静态方法，SetResolver（）方法来注册自定义解析器
       /// </summary>
       public void test() {
           Ninject.IKernel kernel = new Ninject.StandardKernel();
           /// 使用容器注册服务////
           kernel.Bind<IErrorLogger>().To<ErrorLogger>();
           CustomDependencyResolver customDependencyResolver = new CustomDependencyResolver(kernel);
           DependencyResolver.SetResolver(customDependencyResolver);
       }
    }
}
