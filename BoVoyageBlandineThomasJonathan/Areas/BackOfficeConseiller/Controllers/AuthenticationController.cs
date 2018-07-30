using BoVoyageBlandineThomasJonathan.Areas.BackOfficeConseiller.Models;
using BoVoyageBlandineThomasJonathan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoVoyageBlandineThomasJonathan.Utils;
using BoVoyageBlandineThomasJonathan.Utils.Validators;

namespace BoVoyageBlandineThomasJonathan.Areas.BackOfficeConseiller.Controllers
{
    public class AuthenticationController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        // GET: BackOffice/Authentication/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: BackOffice/Authentication/Login
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(AuthenticationLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = model.Password.HashMD5();
                var user = db.ConseillersClientele.SingleOrDefault(x => x.Mail == model.Login && x.Password == passwordHash);
                if (user == null)
                {
                    // Méthode 1 
                    // ModelState.AddModelError("", "Utilisateur ou mot de passe incorrect");

                    // Méthode 2
                    ViewBag.ErrorMessage = "Utilisateur ou mot de passe incorrect";
                    return View(model);
                }

                else
                {
                    Session.Add("USER_BO", user);
                    return RedirectToAction("Index", "Dashboard", new { area = "BackOfficeConseiller" });
                }
            }

            return View(model);

            //var user = db.ConseillersClientele.SingleOrDefault(x => x.Mail == model.Login && x.Password == model.Password.HashMD5());
            //if (user == null)
            //{
            //    return RedirectToAction("Login");
            //}
            //else
            //{
            //    Session.Add("USER_BO", user);
            //    return RedirectToAction("Index", "BOVoyages", new { area = "BackOfficeConseiller" });
            //}
        }

        // GET: BackOffice/Authentication/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}