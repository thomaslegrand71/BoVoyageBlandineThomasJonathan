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
                return RedirectToAction("Index");
            }

            return View(visiteur);
        }

        // GET: Visiteurs/Edit/5
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

        // POST: Visiteurs/Edit/5
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

        // GET: Visiteurs/Delete/5
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

        // POST: Visiteurs/Delete/5
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
