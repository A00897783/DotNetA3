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
    public class FiscalYearsController : Controller
    {
        private SamaritanContext db = new SamaritanContext();

        // GET: FiscalYears
        public ActionResult Index()
        {
            return View(db.FiscalYears.ToList());
        }

        // GET: FiscalYears/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiscalYear fiscalYear = db.FiscalYears.Find(id);
            if (fiscalYear == null)
            {
                return HttpNotFound();
            }
            return View(fiscalYear);
        }

        // GET: FiscalYears/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FiscalYears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FiscalYearId,Years")] FiscalYear fiscalYear)
        {
            if (ModelState.IsValid)
            {
                db.FiscalYears.Add(fiscalYear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fiscalYear);
        }

        // GET: FiscalYears/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiscalYear fiscalYear = db.FiscalYears.Find(id);
            if (fiscalYear == null)
            {
                return HttpNotFound();
            }
            return View(fiscalYear);
        }

        // POST: FiscalYears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FiscalYearId,Years")] FiscalYear fiscalYear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fiscalYear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fiscalYear);
        }

        // GET: FiscalYears/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiscalYear fiscalYear = db.FiscalYears.Find(id);
            if (fiscalYear == null)
            {
                return HttpNotFound();
            }
            return View(fiscalYear);
        }

        // POST: FiscalYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FiscalYear fiscalYear = db.FiscalYears.Find(id);
            db.FiscalYears.Remove(fiscalYear);
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
