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

           

            


            return View();
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