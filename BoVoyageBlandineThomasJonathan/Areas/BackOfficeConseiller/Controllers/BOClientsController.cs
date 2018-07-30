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

    public class BOClientsController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        // GET: BackOfficeConseiller/BOClients
        public ViewResult Index(string RechercheParNom, string RechercheParVille, DateTime? RechercheParDate)
        {

            var resultat = from x in db.Clients.Include("Civilite")
                           select x;

            if (!String.IsNullOrEmpty(RechercheParNom) && !String.IsNullOrEmpty(RechercheParVille))
            {
                resultat = db.Clients.Include("Civilite").Where(s => s.Nom.Contains(RechercheParNom)).Where(s => s.Adresse.Contains(RechercheParVille));
            }

            else if (!String.IsNullOrEmpty(RechercheParNom))
            {
                resultat = db.Clients.Include("Civilite").Where(s => s.Nom.Contains(RechercheParNom));
            }
            else if (!String.IsNullOrEmpty(RechercheParVille))
            {
                resultat = db.Clients.Include("Civilite").Where(s => s.Nom.Contains(RechercheParVille));
            }

            if (RechercheParDate != null)
            {
                resultat = resultat.Where(x => x.DateDeNaissance > RechercheParDate);
            }


            ModelState.Clear();



            return View(resultat);
        }
        // GET: BackOfficeConseiller/BOClients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Include(X => X.Civilite).Where(x => x.Id == id).SingleOrDefault();
                
                
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: BackOfficeConseiller/BOClients/Create
        public ActionResult Create()
        {
            ViewBag.CivilityID = new SelectList(db.Civilites, "Id", "Label");
            return View();
        }

        // POST: BackOfficeConseiller/BOClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Mail,Password,ConfirmedPassword,Nom,Prenom,Adresse,Telephone,DateDeNaissance,Age,CivilityID")] Client client)
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

        // GET: BackOfficeConseiller/BOClients/Edit/5
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

        // POST: BackOfficeConseiller/BOClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Mail,Password,Nom,Prenom,Adresse,Telephone,DateDeNaissance,Age,CivilityID")] Client client)
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

        // GET: BackOfficeConseiller/BOClients/Delete/5
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

        // POST: BackOfficeConseiller/BOClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
