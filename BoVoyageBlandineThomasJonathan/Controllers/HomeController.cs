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
            //var quinze = intParse(DateTime).Now + 15;
            var model = db.Voyages.Include("Destination").Where(x => x.DateAller > DateTime.Now).OrderBy(x => x.DateAller).Take(5);
            
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

        public ActionResult Maintenance()
        {
            return View();
        }
    }
}