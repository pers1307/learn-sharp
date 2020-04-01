using System;
using System.Web.Mvc;
using Filters.Infrastucture;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
//        [CustomAuth(false)]
        [Authorize(Users = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        [GoogleAuth]
        [Authorize(Users = "bob@google.com")]
        public string List()
        {
            return "";
        }

//        [RangeException]
//        Применение стандартного исключения
        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
        public string RangeTest()
        {
            throw new ArgumentOutOfRangeException();
            
            return "";
        }
    }
}