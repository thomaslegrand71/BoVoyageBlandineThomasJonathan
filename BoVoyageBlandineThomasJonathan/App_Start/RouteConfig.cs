﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BoVoyageBlandineThomasJonathan
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Contact",
               url: "contact",
               defaults: new { controller = "Visiteurs", action = "Create" });

            routes.MapRoute(
             name: "Home",
             url: "",
             defaults: new { controller = "Home", action = "Index" });

            routes.MapRoute(
            name: "AboutRoute",
           url: "a-propos",
            defaults: new { controller = "Home", action = "About" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

          



        }
    }
}
