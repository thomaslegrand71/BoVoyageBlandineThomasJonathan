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
    public class VoyageFilesController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        // GET: VoyageFiles
        public ActionResult Index()
        {
            return View(db.VoyageFiles.ToList());
        }

        // GET: VoyageFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoyageFile voyageFile = db.VoyageFiles.Find(id);
            if (voyageFile == null)
            {
                return HttpNotFound();
            }
            return View(voyageFile);
        }

        // GET: VoyageFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VoyageFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ContentType,Content")] VoyageFile voyageFile)
        {
            if (ModelState.IsValid)
            {
                db.VoyageFiles.Add(voyageFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(voyageFile);
        }

        // GET: VoyageFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoyageFile voyageFile = db.VoyageFiles.Find(id);
            if (voyageFile == null)
            {
                return HttpNotFound();
            }
            return View(voyageFile);
        }

        // POST: VoyageFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ContentType,Content")] VoyageFile voyageFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voyageFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voyageFile);
        }

        // GET: VoyageFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoyageFile voyageFile = db.VoyageFiles.Find(id);
            if (voyageFile == null)
            {
                return HttpNotFound();
            }
            return View(voyageFile);
        }

        // POST: VoyageFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VoyageFile voyageFile = db.VoyageFiles.Find(id);
            db.VoyageFiles.Remove(voyageFile);
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
