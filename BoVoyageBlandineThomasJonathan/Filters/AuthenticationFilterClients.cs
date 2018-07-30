using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageBlandineThomasJonathan.Filters
{
    public class AuthenticationFilterClients : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["USER"] == null)
            {
                filterContext.Result = new RedirectResult("\\AuthenticationClients\\LoginClients");
            }
        }
    }
}