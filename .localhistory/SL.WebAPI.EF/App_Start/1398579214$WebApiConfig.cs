using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using SL.WebAPI.EF.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;


namespace SL.WebAPI.EF
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //GlobalConfiguration.Configuration.MessageHandlers.Add(new HttpMethodOverrideHandler());
            //ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            //builder.EntitySet<Collection>("Collections");
            //builder.EntitySet<User>("userTable");
            //config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "sl/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
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
