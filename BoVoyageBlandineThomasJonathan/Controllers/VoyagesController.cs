﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoVoyageBlandineThomasJonathan.Data;
using BoVoyageBlandineThomasJonathan.Models;

namespace BoVoyageBlandineThomasJonathan.Controllers
{
    public class VoyagesController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        // GET: Voyages
        public ViewResult Index(string RechercheParPays, string RechercheParAgence, DateTime? RechercheParDate, int? RechercheParPrixMin, int? RechercheParPrixMax, DateTime? RechercheParDateMax)
        {

            var resultat = from x in db.Voyages.Include(X => X.Agence).Include("Destination")
                           select x;

            if (!String.IsNullOrEmpty(RechercheParPays) && !String.IsNullOrEmpty(RechercheParAgence))
            {
                resultat = db.Voyages.Include(X => X.Agence).Include("Destination").Where(s => s.Destination.Pays.Contains(RechercheParPays)).Where(s => s.Agence.Nom.Contains(RechercheParAgence));
            }

            else if (!String.IsNullOrEmpty(RechercheParPays))
            {
                resultat = db.Voyages.Include(X => X.Agence).Include("Destination").Where(s => s.Destination.Pays.Contains(RechercheParPays));
            }
            else if (!String.IsNullOrEmpty(RechercheParAgence))
            {
                resultat = db.Voyages.Include(X => X.Agence).Include("Destination").Where(s => s.Agence.Nom.Contains(RechercheParAgence));
            }

            if (RechercheParDate != null)
            {
                resultat = resultat.Where(x => x.DateAller > RechercheParDate);
            }

            if (RechercheParDateMax != null)
            {
                resultat = resultat.Where(x => x.DateAller < RechercheParDateMax);
            }

            if (RechercheParPrixMin !=null)
            {
                resultat = resultat.Where(x => x.TarifToutCompris > RechercheParPrixMin);
            }

            if (RechercheParPrixMax != null)
            {
                resultat = resultat.Where(x => x.TarifToutCompris < RechercheParPrixMax);
            }

            ModelState.Clear();



            return View(resultat);
        }





        // GET: Voyages/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var voyage = db.Voyages.Include("Agence").Include("Destination").SingleOrDefault(x=>x.Id==id);

            if (voyage == null)
            {
                return HttpNotFound();
            }
            return View(voyage);
        }

        // GET: Voyages/Create
        public ActionResult Create()
        {
            ViewBag.IdAgence = new SelectList(db.Agences, "Id", "Nom");
            ViewBag.IdDestination = new SelectList(db.Destinations, "Id", "Continent");
            return View();
        }

        // POST: Voyages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateAller,DateRetour,PlacesDisponibles,TarifToutCompris,IdAgence,IdDestination")] Voyage voyage)
        {
            if (ModelState.IsValid)
            {
                db.Voyages.Add(voyage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAgence = new SelectList(db.Agences, "Id", "Nom", voyage.IdAgence);
            ViewBag.IdDestination = new SelectList(db.Destinations, "Id", "Continent", voyage.IdDestination);
            return View(voyage);
        }

        // GET: Voyages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var voyage = db.Voyages.Include("Agence").Include("Destination").SingleOrDefault(x => x.Id == id);

            Voyage voyage = db.Voyages.Find(id);
            if (voyage == null)
            {
                return HttpNotFound();
            }
            //ViewBag.NomAgence = new SelectList(db.Agences, "Nom", voyage.Agence.Nom);
            //ViewBag.Pays = new SelectList(db.Destinations, "Pays", voyage.Destination.Pays);
            //ViewBag.Continent = new SelectList(db.Destinations, "Continent", voyage.Destination.Continent);

            //ViewBag.IdAgence = new SelectList(db.Agences, "Id", "Nom", voyage.IdAgence);
            //ViewBag.IdDestination = new SelectList(db.Destinations, "Id", "Continent", voyage.IdDestination);
            return View(voyage);
        }

        // POST: Voyages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateAller,DateRetour,PlacesDisponibles,TarifToutCompris,IdAgence,IdDestination")] Voyage voyage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voyage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NomAgence = new SelectList(db.Agences, "Nom", voyage.Agence.Nom);
            ViewBag.Pays = new SelectList(db.Destinations, "Pays", voyage.Destination.Pays);
            ViewBag.Continent = new SelectList(db.Destinations, "Continent", voyage.Destination.Continent);

            ViewBag.IdAgence = new SelectList(db.Agences, "Id", "Nom", voyage.IdAgence);
            ViewBag.IdDestination = new SelectList(db.Destinations, "Id", "Continent", voyage.IdDestination);
            return View(voyage);
        }

        // GET: Voyages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voyage voyage = db.Voyages.Find(id);
            if (voyage == null)
            {
                return HttpNotFound();
            }
            return View(voyage);
        }

        // POST: Voyages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voyage voyage = db.Voyages.Find(id);
            db.Voyages.Remove(voyage);
            db.SaveChanges();
            return RedirectToAction("Index");
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
