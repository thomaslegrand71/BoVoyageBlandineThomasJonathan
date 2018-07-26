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

namespace BoVoyageBlandineThomasJonathan.Areas.BackOfficeConseiller.Controllers
{
    public class BackOfficeVoyagesController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        // GET: BackOfficeConseiller/BackOfficeVoyages
        public ActionResult Index()
        {
            var voyages = db.Voyages.Include(v => v.Agence).Include(v => v.Destination);
            return View(voyages.ToList());
        }

        // GET: BackOfficeConseiller/BackOfficeVoyages/Details/5
        public ActionResult Details(int? id)
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

        // GET: BackOfficeConseiller/BackOfficeVoyages/Create
        public ActionResult Create()
        {
            ViewBag.IdAgence = new SelectList(db.Agences, "Id", "Nom");
            ViewBag.IdDestination = new SelectList(db.Destinations, "Id", "Continent");
            return View();
        }

        // POST: BackOfficeConseiller/BackOfficeVoyages/Create
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

        // GET: BackOfficeConseiller/BackOfficeVoyages/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.IdAgence = new SelectList(db.Agences, "Id", "Nom", voyage.IdAgence);
            ViewBag.IdDestination = new SelectList(db.Destinations, "Id", "Continent", voyage.IdDestination);
            return View(voyage);
        }

        // POST: BackOfficeConseiller/BackOfficeVoyages/Edit/5
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
            ViewBag.IdAgence = new SelectList(db.Agences, "Id", "Nom", voyage.IdAgence);
            ViewBag.IdDestination = new SelectList(db.Destinations, "Id", "Continent", voyage.IdDestination);
            return View(voyage);
        }

        // GET: BackOfficeConseiller/BackOfficeVoyages/Delete/5
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

        // POST: BackOfficeConseiller/BackOfficeVoyages/Delete/5
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
