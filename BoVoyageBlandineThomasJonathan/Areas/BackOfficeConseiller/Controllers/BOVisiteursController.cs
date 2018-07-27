using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoVoyageBlandineThomasJonathan.Data;
using BoVoyageBlandineThomasJonathan.Filters;
using BoVoyageBlandineThomasJonathan.Models;

namespace BoVoyageBlandineThomasJonathan.Areas.BackOfficeConseiller.Controllers
{
    [AuthenticationFilter]

    public class BOVisiteursController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        // GET: BackOfficeConseiller/BOVisiteurs
        public ActionResult Index()
        {
            return View(db.Visiteurs.ToList());
        }

        // GET: BackOfficeConseiller/BOVisiteurs/Details/5
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

        // GET: BackOfficeConseiller/BOVisiteurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOfficeConseiller/BOVisiteurs/Create
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
                return RedirectToAction("Index");
            }

            return View(visiteur);
        }

        // GET: BackOfficeConseiller/BOVisiteurs/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: BackOfficeConseiller/BOVisiteurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,Mail,Telephone,Demande")] Visiteur visiteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visiteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visiteur);
        }

        // GET: BackOfficeConseiller/BOVisiteurs/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: BackOfficeConseiller/BOVisiteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visiteur visiteur = db.Visiteurs.Find(id);
            db.Visiteurs.Remove(visiteur);
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
