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
    public class ClientsAuthentifieController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        //// GET: ClientsAuthentifie
        //public ActionResult Index()
        //{
        //    var clients = db.Clients.Include(c => c.Civilite);
        //    return View(clients.ToList());
        //}

        // GET: ClientsAuthentifie/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: ClientsAuthentifie/Create
        public ActionResult Create()
        {
            ViewBag.CivilityID = new SelectList(db.Civilites, "Id", "Label");
            return View();
        }

        // POST: ClientsAuthentifie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Mail,Password,Nom,Prenom,Adresse,Telephone,DateDeNaissance,CivilityID")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CivilityID = new SelectList(db.Civilites, "Id", "Label", client.CivilityID);
            return View(client);
        }

        // GET: ClientsAuthentifie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.CivilityID = new SelectList(db.Civilites, "Id", "Label", client.CivilityID);
            return View(client);
        }

        // POST: ClientsAuthentifie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Mail,Password,Nom,Prenom,Adresse,Telephone,DateDeNaissance,CivilityID")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CivilityID = new SelectList(db.Civilites, "Id", "Label", client.CivilityID);
            return View(client);
        }

        // GET: ClientsAuthentifie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: ClientsAuthentifie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult HistoriqueReservation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DossierReservation dr = db.DossierReservation.Include("Clients").Where(x => x.IdClient == id).SingleOrDefault();
                
            if (dr == null)
            {
                return HttpNotFound();
            }
            return View(dr);
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
