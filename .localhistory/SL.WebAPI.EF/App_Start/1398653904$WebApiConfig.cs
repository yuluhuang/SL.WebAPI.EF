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
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Collection>("Collections");
            builder.EntitySet<User>("userTable");

            builder.EntitySet<User>("Login");
            builder.EntitySet<Collection>("Collection");
            builder.EntitySet<Info>("Info");
            builder.EntitySet<Note>("Note");
            builder.EntitySet<Theme>("Theme"); 
            config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());

            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "odata/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
      
    }
}
