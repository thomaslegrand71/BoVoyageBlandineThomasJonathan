using BoVoyageBlandineThomasJonathan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoVoyageBlandineThomasJonathan.Data;
using BoVoyageBlandineThomasJonathan.Controllers;

namespace BoVoyageBlandineThomasJonathan.Controllers
{
    public class HomeController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        // GET: Home
        public ActionResult Index()
        {

            var model = db.Voyages.Include("Destination").Where(x => x.DateAller > DateTime.Now).OrderBy(x => x.DateAller);

            /*var model = (from x in db.Voyages 
                         //join Pays in db.Destinations 

                         where x.DateAller > DateTime.Now
                         orderby x.DateAller
                         select x
                         );
            */
            return View(model);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

       

    }
}