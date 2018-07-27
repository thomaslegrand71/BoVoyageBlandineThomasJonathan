using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageBlandineThomasJonathan.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["USER_BO"] == null)
            {
                filterContext.Result = new RedirectResult("\\BackOfficeConseiller\\Authentication\\Login");
            }
        }
    }
}