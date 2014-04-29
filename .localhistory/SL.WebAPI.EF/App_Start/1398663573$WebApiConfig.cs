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

            ODataConventionModelBuilder collection = new ODataConventionModelBuilder();
            collection.EntitySet<Collection>("Collection");
            collection.EntitySet<User>("userTable");
            config.Routes.MapODataRoute("odata", "odataCollection", collection.GetEdmModel());


            ODataConventionModelBuilder login = new ODataConventionModelBuilder();
            login.EntitySet<User>("Login");
            login.EntitySet<Collection>("Collection");
            login.EntitySet<Info>("Info");
            login.EntitySet<Note>("Note");
            login.EntitySet<Theme>("Theme");
            config.Routes.MapODataRoute("odata", "odataLogin", login.GetEdmModel());

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
