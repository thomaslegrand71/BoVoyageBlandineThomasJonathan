using BoVoyageBlandineThomasJonathan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageBlandineThomasJonathan.Controllers
{
    public class SharedController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        // GET: Shared


        public ActionResult TopFiveBudget()
        {
            var voyage = db.Voyages.Include("Destination").Where(x => x.DateAller > DateTime.Now).OrderBy(x => x.TarifToutCompris).Take(5);


            return View("_TopFiveBudget", voyage);
        }

        public ActionResult TopFiveTrending()
        {

            var trending = db.Voyages.Include("Destination")
                                    .GroupBy(x => x.Destination.Pays)
                                    .OrderByDescending(y => y.Count())
                                    .Take(3).ToList();
            
            return View("_TopFiveTrending", trending);
        }
    }
}