using BoVoyageBlandineThomasJonathan.Models;
using BoVoyageBlandineThomasJonathan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoVoyageBlandineThomasJonathan.Utils;
using BoVoyageBlandineThomasJonathan.Utils.Validators;

namespace BoVoyageBlandineThomasJonathan.Controllers
{
    public class AuthenticationClientsController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        // GET: Authentication/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Authentication/Login
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(AuthenticationLoginViewModelClients model)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = model.Password.HashMD5();
                var user = db.Clients.SingleOrDefault(x => x.Mail == model.Login && x.Password == passwordHash);
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
                    Session.Add("USER", user);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);

            //var user = db.Clients.SingleOrDefault(x => x.Mail == model.Login && x.Password == model.Password.HashMD5());
            //if (user == null)
            //{
            //    return RedirectToAction("Login");
            //}
            //else
            //{
            //    Session.Add("USER", user);
            //    return RedirectToAction("Index", "Home");
            //}
        }

        // GET: Authentication/Logout
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