﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using a2.Models;

namespace a2.Controllers.lookup
{
    public class HIVMedsController : Controller
    {
        private SamaritanContext db = new SamaritanContext();

        // GET: HIVMeds
        public ActionResult Index()
        {
            return View(db.HIVMeds.ToList());
        }

        // GET: HIVMeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HIVMeds hIVMeds = db.HIVMeds.Find(id);
            if (hIVMeds == null)
            {
                return HttpNotFound();
            }
            return View(hIVMeds);
        }

        // GET: HIVMeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HIVMeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HIVMedsId,YesNoNA")] HIVMeds hIVMeds)
        {
            if (ModelState.IsValid)
            {
                db.HIVMeds.Add(hIVMeds);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hIVMeds);
        }

        // GET: HIVMeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HIVMeds hIVMeds = db.HIVMeds.Find(id);
            if (hIVMeds == null)
            {
                return HttpNotFound();
            }
            return View(hIVMeds);
        }

        // POST: HIVMeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HIVMedsId,YesNoNA")] HIVMeds hIVMeds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hIVMeds).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hIVMeds);
        }

        // GET: HIVMeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HIVMeds hIVMeds = db.HIVMeds.Find(id);
            if (hIVMeds == null)
            {
                return HttpNotFound();
            }
            return View(hIVMeds);
        }

        // POST: HIVMeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HIVMeds hIVMeds = db.HIVMeds.Find(id);
            db.HIVMeds.Remove(hIVMeds);
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
