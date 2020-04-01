using System.Web;
using System.Web.Mvc;

namespace Filters.Infrastucture
{
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        // Перед выполнением метода
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }

        // После выполнения метода
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }
    }
}