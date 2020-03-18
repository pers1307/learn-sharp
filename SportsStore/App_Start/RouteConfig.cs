using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Routing.Constraints;

namespace SportsStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Подключение маршрутизации на основе атрибутов
            routes.MapMvcAttributeRoutes();

            routes.MapRoute("MyRoute", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id=UrlParameter.Optional});

            // routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // routes.MapRoute("MyRoute", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id="DefaultId"});
            // routes.MapRoute("MyRoute", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id=UrlParameter.Optional});

            /*
            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional});
            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional},
                new[] {"URLsAndRoutes.AdditionalControllers"}); // приоритетное пространство имен

            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional},
                new
                {
                    controller = "^H.*", action = "^Index$|^About$",
                    httpMethod = new HttpMethodConstraint("GET", "POST"), id = new RangeRouteConstraint(10, 20)
                }, // указание регулярного выражения для поиска контроллера
                new[] {"URLsAndRoutes.AdditionalControllers"});

            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional},
                new
                {
                    controller = "^H.*", action = "^Index$|^About$",
                    httpMethod = new HttpMethodConstraint("GET", "POST"),
                    id = new CompoundRouteConstraint(new IRouteConstraint[]
                    {
                        new AlphaRouteConstraint(),
                        new MinLengthRouteConstraint(6)
                    }) // Объединение условий
                },
                new[] {"URLsAndRoutes.AdditionalControllers"});
            */
            /*
            Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            routes.Add(myRoute);

            routes.MapRoute("myRoute", "{controller}/{action}");

            // стандартный маршрут
            // "Public/{controller}/{action}"
            // "X{controller}/{action}"

            routes.MapRoute("myRoute", "{controller}/{action}", new { controller = "Home", action = "Index"});
            routes.MapRoute("Shop", "Shop/{action}", new { controller = "Home"});
            routes.MapRoute("Shop2", "Shop/new", new { controller = "Home", action = "Index"});

            routes.MapRoute("MyRoute", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id="DefaultId"});
            */

            /*
            routes.MapRoute(
                null,
                "",
                new
                {
                    controller = "Product", action = "List",
                    category = (string) null, page = 1
                }
            );

            routes.MapRoute(
                null,
                "Page{page}",
                new {controller = "Product", action = "List", category = (string) null},
                new {page = @"\d+"}
            );

            routes.MapRoute(
                null,
                "{category}",
                new
                {
                    controller = "Product", action = "List", page = 1
                }
            );

            routes.MapRoute(
                name: null,
                url: "{category}/Page{page}",
                defaults: new {Controller = "Products", action = "List"},
                new {page = @"\d+"}
            );

            routes.MapRoute(null, "{controller}/{action}");
            */

            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Product", action = "List", id = UrlParameter.Optional}
            );
            */
        }
    }
}