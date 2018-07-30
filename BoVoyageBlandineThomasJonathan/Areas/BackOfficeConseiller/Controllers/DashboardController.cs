using BoVoyageBlandineThomasJonathan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageBlandineThomasJonathan.Areas.BackOfficeConseiller.Controllers
{
    public class DashboardController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();
        // GET: BackOfficeConseiller/Dashboard
        public ActionResult Index()
        {
            

            var today = DateTime.Now;
            var quinze = today.AddDays(15);
            var model = db.Voyages.Include("Destination").Where(x => x.DateAller > today && x.DateAller < quinze).OrderBy(x => x.DateAller).Take(5);
            return View(model);

        }


    }
}