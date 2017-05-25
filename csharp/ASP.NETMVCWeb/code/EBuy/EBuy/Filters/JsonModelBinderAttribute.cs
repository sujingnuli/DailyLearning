using Ebuy.Core.Binder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EBuy.Filters
{
    public class JsonModelBinderAttribute:CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new JsonModelBinder();
        }
    }
}