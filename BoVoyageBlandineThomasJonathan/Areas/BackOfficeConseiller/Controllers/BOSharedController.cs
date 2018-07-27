using BoVoyageBlandineThomasJonathan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageBlandineThomasJonathan.Controllers
{
    public class BOSharedController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        // GET: Shared
        public ActionResult UpcomingTrips()
        {
            DateTime today = DateTime.Now;
            DateTime endPeriod = today.AddDays(15);
            var model = db.Voyages.Include("Destination").Where(x => x.DateAller >= today && x.DateAller >= endPeriod );


            return View("_Upcoming", model);
        }

        public ActionResult MesReservations(int id)
        {

            var mesDossiers = db.DossierReservation.Include("MesDossiers").Where(x => x.IdConseillerClientele == id);
                 
            return View("_MyReservations", mesDossiers);
        }
    }
}
