using BoVoyageBlandineThomasJonathan.Areas.BackOfficeConseiller.Models;
using Roomy.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoVoyageBlandineThomasJonathan.Areas.BackOfficeConseiller.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: BackOfficeConseiller/Authentication
        public ActionResult Index()
        {
            return View();
        }

        // POST: BackOfficeConseiller/Authentication/Login
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(AuthenticationLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = model.Password.HashMD5();
                var conseiller = db.ConseillerClientele.SingleOrDefault(x => x.Mail == model.Login && x.Password == passwordHash);
                if (conseiller == null)

                {
                   
                    ViewBag.ErrorMessage = "Utilisateur ou mot de passe incorrect ";

                    return View(model);

                }
                else
                {
                    Session.Add("USER_BO", conseiller);
                    return RedirectToAction("Index", "Dashboard", new { area = "BackOfficeConseiller" });
                }
            }
            return View(model);
        }

        // GET: BackOffice/Authentication/Logout
        [AuthenticationFilter]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        
            
        
    }
}
