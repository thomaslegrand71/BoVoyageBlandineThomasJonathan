using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoVoyageBlandineThomasJonathan.Data;
using BoVoyageBlandineThomasJonathan.Models;

namespace BoVoyageBlandineThomasJonathan.Controllers
{
    public class VisiteursController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        // GET: Visiteurs
        public ActionResult Index()
        {
            return View(db.Visiteurs.ToList());
        }

        // GET: Visiteurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visiteur visiteur = db.Visiteurs.Find(id);
            if (visiteur == null)
            {
                return HttpNotFound();
            }
            return View(visiteur);
        }

        // GET: Visiteurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visiteurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,Mail,Telephone,Demande")] Visiteur visiteur)
        {
            if (ModelState.IsValid)
            {
                db.Visiteurs.Add(visiteur);
                db.SaveChanges();
                return RedirectToAction("Index", "Home"); ;
            }

            return View(visiteur);
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
