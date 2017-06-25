using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EBuy.Filters.test
{
    public class AspCompatHandler : System.Web.UI.Page,IHttpAsyncHandler
    {
        public RequestContext RequestContext { get; set; }
        public AspCompatHandler(RequestContext requestContext) {
            this.RequestContext = requestContext;
        }

        protected override void OnInit(EventArgs e)
        {
            string requiredString = this.RequestContext.RouteData.GetRequiredString("controller");
            var controllerFactory = ControllerBuilder.Current.GetControllerFactory();
            var controller = controllerFactory.CreateController(this.RequestContext, requiredString);
            if (controller == null) {
                throw new InvalidOperationException("Could not find Controller:" + requiredString);
            }
            try
            {
                controller.Execute(this.RequestContext);
            }
            finally {
                controllerFactory.ReleaseController(controller);
            }
            this.Context.ApplicationInstance.CompleteRequest();
        }


        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            throw new NotImplementedException();
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            throw new NotImplementedException();
        }
    }
}