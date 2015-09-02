using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using OdataSample.Models;

namespace OdataSample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Products>("Product");
            builder.EntitySet<Employee>("Employee");
            builder.EntitySet<Department>("Department");
            builder.EntitySet<Customer>("Customer");
            builder.EntitySet<Order>("Order");
            config.Routes.MapODataRoute("odata", "myodata", builder.GetEdmModel());

        }
    }
}
