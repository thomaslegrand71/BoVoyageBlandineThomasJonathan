﻿using System;
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
    public class ParticipantsController : Controller
    {
        private BoVoyageBTJDbContext db = new BoVoyageBTJDbContext();

        // GET: Participants
        public ActionResult Index()
        {
            var participants = db.Participants.Include(p => p.Civilite);
            return View(participants.ToList());
        }

        // GET: Participants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // GET: Participants/Create
        public ActionResult Create()
        {
            ViewBag.CivilityID = new SelectList(db.Civilites, "Id", "Label");
            return View();
        }

        // POST: Participants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Reduction,Nom,Prenom,Adresse,Telephone,DateDeNaissance,Age,CivilityID")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                db.Participants.Add(participant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CivilityID = new SelectList(db.Civilites, "Id", "Label", participant.CivilityID);
            return View(participant);
        }

        // GET: Participants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            ViewBag.CivilityID = new SelectList(db.Civilites, "Id", "Label", participant.CivilityID);
            return View(participant);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Reduction,Nom,Prenom,Adresse,Telephone,DateDeNaissance,Age,CivilityID")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CivilityID = new SelectList(db.Civilites, "Id", "Label", participant.CivilityID);
            return View(participant);
        }

        // GET: Participants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participant participant = db.Participants.Find(id);
            db.Participants.Remove(participant);
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
