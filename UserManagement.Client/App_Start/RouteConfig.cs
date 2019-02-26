using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UserManagement.Client
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapPageRoute(
            //routeName: "Default/",
            //routeUrl: "Default/{Home}/{chart}",
            //physicalFile: "~/Views/{Home}/{chart}.aspx"
            //);


            routes.MapRoute(
             "Default",
             "{controller}/{action}/{id}",
             new { controller = "Home", action = "Index", id = UrlParameter.Optional },
             new[] { "UserManagement.Client.Controllers" }
         );

        }
    }
}
