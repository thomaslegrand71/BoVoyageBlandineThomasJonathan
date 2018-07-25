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
    public class ConseillerClientelesController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        // GET: BackOfficeConseiller/ConseillerClienteles
        public ActionResult Index()
        {
            var conseillersClientele = db.ConseillersClientele.Include(c => c.Civilite);
            return View(conseillersClientele.ToList());
        }

        // GET: BackOfficeConseiller/ConseillerClienteles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConseillerClientele conseillerClientele = db.ConseillersClientele.Find(id);
            if (conseillerClientele == null)
            {
                return HttpNotFound();
            }
            return View(conseillerClientele);
        }

        // GET: BackOfficeConseiller/ConseillerClienteles/Create
        public ActionResult Create()
        {
            ViewBag.CivilityID = new SelectList(db.Civilites, "Id", "Label");
            return View();
        }

        // POST: BackOfficeConseiller/ConseillerClienteles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Mail,Password,Nom,Prenom,Adresse,Telephone,DateDeNaissance,Age,CivilityID")] ConseillerClientele conseillerClientele)
        {
            if (ModelState.IsValid)
            {
                db.ConseillersClientele.Add(conseillerClientele);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CivilityID = new SelectList(db.Civilites, "Id", "Label", conseillerClientele.CivilityID);
            return View(conseillerClientele);
        }

        // GET: BackOfficeConseiller/ConseillerClienteles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConseillerClientele conseillerClientele = db.ConseillersClientele.Find(id);
            if (conseillerClientele == null)
            {
                return HttpNotFound();
            }
            ViewBag.CivilityID = new SelectList(db.Civilites, "Id", "Label", conseillerClientele.CivilityID);
            return View(conseillerClientele);
        }

        // POST: BackOfficeConseiller/ConseillerClienteles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Mail,Password,Nom,Prenom,Adresse,Telephone,DateDeNaissance,Age,CivilityID")] ConseillerClientele conseillerClientele)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conseillerClientele).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CivilityID = new SelectList(db.Civilites, "Id", "Label", conseillerClientele.CivilityID);
            return View(conseillerClientele);
        }

        // GET: BackOfficeConseiller/ConseillerClienteles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConseillerClientele conseillerClientele = db.ConseillersClientele.Find(id);
            if (conseillerClientele == null)
            {
                return HttpNotFound();
            }
            return View(conseillerClientele);
        }

        // POST: BackOfficeConseiller/ConseillerClienteles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConseillerClientele conseillerClientele = db.ConseillersClientele.Find(id);
            db.ConseillersClientele.Remove(conseillerClientele);
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
