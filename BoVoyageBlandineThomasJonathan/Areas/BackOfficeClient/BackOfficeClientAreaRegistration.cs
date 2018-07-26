using System.Web.Mvc;

namespace BoVoyageBlandineThomasJonathan.Areas.BackOfficeClient
{
    public class BackOfficeClientAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BackOfficeClient";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BackOfficeClient_default",
                "BackOfficeClient/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}