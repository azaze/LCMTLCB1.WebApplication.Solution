using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LCMTLCB1WebApplication.Utility
{
    public class RequireLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (currentUser.User == null)
            //{
            //    filterContext.Result = new RedirectResult("~");
            //}
            //else
            //{
            //    //System.Web.HttpContext.Current.Session.Timeout = 180;
            //}
        }
    }
}
