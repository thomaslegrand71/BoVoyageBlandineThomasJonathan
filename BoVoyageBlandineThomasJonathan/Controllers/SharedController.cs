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
            var rooms = db.Voyages.OrderByDescending(x => x.TarifToutCompris).Take(5);
            return View("_TopFiveBudget", rooms);
        }
    }
}