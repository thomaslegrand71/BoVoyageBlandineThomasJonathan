using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoVoyageBlandineThomasJonathan.Models;

namespace BoVoyageBlandineThomasJonathan.Areas.BackOfficeClient.Controllers
{
    public class DashboardClientController : Controller
    {
        // GET: BackOfficeClient/DashboardClient
        public ActionResult Index()
        {
            return View();
        }
    }
}