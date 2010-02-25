using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NHibernate.Validator.Event;
using NHibernate.Validator.Cfg.Loquacious;
using System.Reflection;
using ValidationResourceMessages.Models;

namespace ValidationResourceMessages
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Customer", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            var engineProvider = new NHibernateSharedEngineProvider();
            engineProvider.GetEngine().Configure();

            NHibernate.Validator.Cfg.Environment.SharedEngineProvider = engineProvider;
        }
    }
}