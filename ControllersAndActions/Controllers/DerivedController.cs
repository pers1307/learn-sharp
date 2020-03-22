using System.Web.Mvc;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProduceOutput()
        {
            return RedirectToRoute(new
            {
                controller = "Example",
                action = "Example",
            });
            return new RedirectResult("/Basic/Index");
            return new Redirect("/Basic/Index");
            
            if (Server.MachineName == "TINY")
            {
                Response.Redirect("/Basic/Index");
                return new CustomRedirectResult { Url = "/Basic/Index"};
            }
            else
            {
                Response.Write("");
                return null;
            }
        }

        public HttpStatusCodeResult StatusCode()
        {
            return new HttpStatusCodeResult(404, "Oops!");
        }
    }
}