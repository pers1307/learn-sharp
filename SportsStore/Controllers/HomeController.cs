using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string[] names = {"Tom", "Dick", "Harry"};

            var result = names.Where(n => n.Length >= 4);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        /*
        public ActionResult CustomVariable()
        {
            ViewBag.Controller     = "Home";
            ViewBag.Action         = "CustomVariable";
            ViewBag.CustomVariable = RouteData.Values["id"];

            return View();
        }
        */

        public ActionResult CustomVariable(string id = "noValue")
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable";
            ViewBag.CustomVariable = id;

            string url = Url.Action("Index", new {id = "MyID"});
            string routeUrl = Url.RouteUrl(new {IController = "Home", action = "Index"});

            return View();
        }
    }
}