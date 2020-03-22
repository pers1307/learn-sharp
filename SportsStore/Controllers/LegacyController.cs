using System.Web.Mvc;
using SportsStore.Infrastructure.Abstract;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class LegacyController : Controller
    {
        public ActionResult GetLegacyURL(string legacyURL)
        {
            return View((object)legacyURL);
        }
    }
}