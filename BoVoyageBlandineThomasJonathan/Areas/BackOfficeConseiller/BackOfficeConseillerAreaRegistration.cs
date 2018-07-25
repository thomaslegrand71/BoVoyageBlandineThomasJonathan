using System.Web.Mvc;

namespace BoVoyageBlandineThomasJonathan.Areas.BackOfficeConseiller
{
    public class BackOfficeConseillerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BackOfficeConseiller";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BackOfficeConseiller_default",
                "BackOfficeConseiller/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}