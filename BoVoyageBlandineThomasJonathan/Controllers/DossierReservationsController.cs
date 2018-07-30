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
    public class DossierReservationsController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        // GET: DossierReservations
        public ActionResult Index()
        {
            var dossierReservation = db.DossierReservation.Include(d => d.Client).Include(d => d.ConseillerClientele).Include(d => d.Participants).Include(d => d.Voyage);
            return View(dossierReservation.ToList());
        }

        // GET: DossierReservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DossierReservation dossierReservation = db.DossierReservation.Find(id);
            if (dossierReservation == null)
            {
                return HttpNotFound();
            }
            return View(dossierReservation);
        }

        // GET: DossierReservations/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Mail");
            ViewBag.IdConseillerClientele = new SelectList(db.ConseillersClientele, "Id", "Mail");
            ViewBag.IdParticipant = new SelectList(db.Participants, "Id", "Nom");
            ViewBag.IdVoyage = new SelectList(db.Voyages, "Id", "Id");
            return View();
        }

        // POST: DossierReservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroCarteBancaire,PrixTotal,NombreDeVoyageurs,SolvaviliteCompteBancaire,IdVoyage,IdClient,IdConseillerClientele,AssuranceAnnulation,IdParticipant")] DossierReservation dossierReservation)
        {
            if (ModelState.IsValid)
            {
                db.DossierReservation.Add(dossierReservation);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Mail", dossierReservation.IdClient);
            ViewBag.IdConseillerClientele = new SelectList(db.ConseillersClientele, "Id", "Mail", dossierReservation.IdConseillerClientele);
            ViewBag.IdParticipant = new SelectList(db.Participants, "Id", "Nom", dossierReservation.IdParticipant);
            ViewBag.IdVoyage = new SelectList(db.Voyages, "Id", "Id", dossierReservation.IdVoyage);
            return View(dossierReservation);
        }

        // GET: DossierReservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DossierReservation dossierReservation = db.DossierReservation.Find(id);
            if (dossierReservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Mail", dossierReservation.IdClient);
            ViewBag.IdConseillerClientele = new SelectList(db.ConseillersClientele, "Id", "Mail", dossierReservation.IdConseillerClientele);
            ViewBag.IdParticipant = new SelectList(db.Participants, "Id", "Nom", dossierReservation.IdParticipant);
            ViewBag.IdVoyage = new SelectList(db.Voyages, "Id", "Id", dossierReservation.IdVoyage);
            return View(dossierReservation);
        }

        // POST: DossierReservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroCarteBancaire,PrixTotal,NombreDeVoyageurs,SolvaviliteCompteBancaire,IdVoyage,IdClient,IdConseillerClientele,AssuranceAnnulation,IdParticipant")] DossierReservation dossierReservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dossierReservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Clients, "Id", "Mail", dossierReservation.IdClient);
            ViewBag.IdConseillerClientele = new SelectList(db.ConseillersClientele, "Id", "Mail", dossierReservation.IdConseillerClientele);
            ViewBag.IdParticipant = new SelectList(db.Participants, "Id", "Nom", dossierReservation.IdParticipant);
            ViewBag.IdVoyage = new SelectList(db.Voyages, "Id", "Id", dossierReservation.IdVoyage);
            return View(dossierReservation);
        }

        // GET: DossierReservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DossierReservation dossierReservation = db.DossierReservation.Find(id);
            if (dossierReservation == null)
            {
                return HttpNotFound();
            }
            return View(dossierReservation);
        }

        // POST: DossierReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DossierReservation dossierReservation = db.DossierReservation.Find(id);
            db.DossierReservation.Remove(dossierReservation);
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
