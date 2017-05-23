using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBuy.Filters
{
    public class SingleSignOnAttribute:ActionFilterAttribute,IActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext) { 
            //检查用户令牌并验证用户
        }
        public  override void OnActionExecuting(ActionExecutingContext filterContext) { 
            //用来检查安全令牌是否存在预处理代码
         }
    }
}