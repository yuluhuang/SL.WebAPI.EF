using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace SL.WebAPI.EF
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           // GlobalConfiguration.Configuration.MessageHandlers.Add(new HttpMethodOverrideHandler());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        //public class HttpMethodOverrideHandler : DelegatingHandler
        //{
        //    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        //    {
        //        IEnumerable<string> methodOverrideHeader;
        //        if (request.Headers.TryGetValues("X-HTTP-Method-Override", out methodOverrideHeader))
        //        {
        //            request.Method = new HttpMethod(methodOverrideHeader.First());
        //        }
        //        return base.SendAsync(request, cancellationToken);
        //    }
        //}
    }
}
