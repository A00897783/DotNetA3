﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using a2.Models;

namespace a2.Controllers
{
    public class ClientsController : Controller
    {
        private SamaritanContext db = new SamaritanContext();

        // GET: Clients1
        public ActionResult Index()
        {
            var clients = db.Clients.Include(c => c.AbuserRelationship).Include(c => c.Age).Include(c => c.AssignedWorker).Include(c => c.Crisis).Include(c => c.DuplicateFile).Include(c => c.Ethnicity).Include(c => c.FamilyViolenceFile).Include(c => c.FiscalYear).Include(c => c.Incident).Include(c => c.Program).Include(c => c.ReferralContact).Include(c => c.ReferralSource).Include(c => c.RepeatClient).Include(c => c.RiskLevel).Include(c => c.RiskStatus).Include(c => c.Service).Include(c => c.StatusOfFile).Include(c => c.VictimOfIncident);
            return View(clients.ToList());
        }

        // GET: Clients1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // GET: Clients1/Create
        public ActionResult Create()
        {
            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationships, "AbuserRelationshipId", "Relationship");
            ViewBag.AgeId = new SelectList(db.Ages, "AgeId", "Range");
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkers, "AssignedWorkerId", "Name");
            ViewBag.CrisisId = new SelectList(db.Crises, "CrisisId", "Type");
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFiles, "DuplicateFileId", "YesOrNull");
            ViewBag.EthnicityId = new SelectList(db.Ethnicities, "EthnicityId", "Description");
            ViewBag.FamilyViolenceFileId = new SelectList(db.FamilyViolenceFiles, "FamilyViolenceFileId", "FileExists");
            ViewBag.FiscalYearId = new SelectList(db.FiscalYears, "FiscalYearId", "Years");
            ViewBag.IncidentId = new SelectList(db.Incidents, "IncidentId", "Type");
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Type");
            ViewBag.ReferralContactId = new SelectList(db.ReferralContacts, "ReferralContactId", "Contact");
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSources, "ReferralSourceId", "Source");
            ViewBag.RepeatClientId = new SelectList(db.RepeatClients, "RepeatClientId", "YesOrNull");
            ViewBag.RiskLevelId = new SelectList(db.RiskLevels, "RiskLevelId", "Level");
            ViewBag.RiskStatusId = new SelectList(db.RiskStatus, "RiskStatusId", "Status");
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Type");
            ViewBag.StatusOfFileId = new SelectList(db.StatusOfFiles, "StatusOfFileId", "Status");
            ViewBag.VictimOfIncidentId = new SelectList(db.VictimOfIncidents, "VictimOfIncidentId", "PrimaryOrSecondary");
            return View();
        }

        // POST: Clients1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientReferenceNumber,FiscalYearId,Month,Day,Surname,FirstName,PoliceFileNumber,CourtFileNumber,SWCFileNumber,RiskLevelId,CrisisId,ServiceId,ProgramId,RiskAssessmentAssignedTo,RiskStatusId,AssignedWorkerId,ReferralSourceId,ReferralContactId,IncidentId,AbuserSurnameFirstName,AbuserRelationshipId,VictimOfIncidentId,FamilyViolenceFileId,Gender,EthnicityId,AgeId,RepeatClientId,DuplicateFileId,NumberOfChildren0to6,NumberOfChildren7to12,NumberOfChildren13to18,StatusOfFileId,DateLastTransferred,DateClosed,DateReOpened")] Clients clients)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(clients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationships, "AbuserRelationshipId", "Relationship", clients.AbuserRelationshipId);
            ViewBag.AgeId = new SelectList(db.Ages, "AgeId", "Range", clients.AgeId);
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkers, "AssignedWorkerId", "Name", clients.AssignedWorkerId);
            ViewBag.CrisisId = new SelectList(db.Crises, "CrisisId", "Type", clients.CrisisId);
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFiles, "DuplicateFileId", "YesOrNull", clients.DuplicateFileId);
            ViewBag.EthnicityId = new SelectList(db.Ethnicities, "EthnicityId", "Description", clients.EthnicityId);
            ViewBag.FamilyViolenceFileId = new SelectList(db.FamilyViolenceFiles, "FamilyViolenceFileId", "FileExists", clients.FamilyViolenceFileId);
            ViewBag.FiscalYearId = new SelectList(db.FiscalYears, "FiscalYearId", "Years", clients.FiscalYearId);
            ViewBag.IncidentId = new SelectList(db.Incidents, "IncidentId", "Type", clients.IncidentId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Type", clients.ProgramId);
            ViewBag.ReferralContactId = new SelectList(db.ReferralContacts, "ReferralContactId", "Contact", clients.ReferralContactId);
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSources, "ReferralSourceId", "Source", clients.ReferralSourceId);
            ViewBag.RepeatClientId = new SelectList(db.RepeatClients, "RepeatClientId", "YesOrNull", clients.RepeatClientId);
            ViewBag.RiskLevelId = new SelectList(db.RiskLevels, "RiskLevelId", "Level", clients.RiskLevelId);
            ViewBag.RiskStatusId = new SelectList(db.RiskStatus, "RiskStatusId", "Status", clients.RiskStatusId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Type", clients.ServiceId);
            ViewBag.StatusOfFileId = new SelectList(db.StatusOfFiles, "StatusOfFileId", "Status", clients.StatusOfFileId);
            ViewBag.VictimOfIncidentId = new SelectList(db.VictimOfIncidents, "VictimOfIncidentId", "PrimaryOrSecondary", clients.VictimOfIncidentId);
            return View(clients);
        }

        // GET: Clients1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationships, "AbuserRelationshipId", "Relationship", clients.AbuserRelationshipId);
            ViewBag.AgeId = new SelectList(db.Ages, "AgeId", "Range", clients.AgeId);
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkers, "AssignedWorkerId", "Name", clients.AssignedWorkerId);
            ViewBag.CrisisId = new SelectList(db.Crises, "CrisisId", "Type", clients.CrisisId);
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFiles, "DuplicateFileId", "YesOrNull", clients.DuplicateFileId);
            ViewBag.EthnicityId = new SelectList(db.Ethnicities, "EthnicityId", "Description", clients.EthnicityId);
            ViewBag.FamilyViolenceFileId = new SelectList(db.FamilyViolenceFiles, "FamilyViolenceFileId", "FileExists", clients.FamilyViolenceFileId);
            ViewBag.FiscalYearId = new SelectList(db.FiscalYears, "FiscalYearId", "Years", clients.FiscalYearId);
            ViewBag.IncidentId = new SelectList(db.Incidents, "IncidentId", "Type", clients.IncidentId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Type", clients.ProgramId);
            ViewBag.ReferralContactId = new SelectList(db.ReferralContacts, "ReferralContactId", "Contact", clients.ReferralContactId);
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSources, "ReferralSourceId", "Source", clients.ReferralSourceId);
            ViewBag.RepeatClientId = new SelectList(db.RepeatClients, "RepeatClientId", "YesOrNull", clients.RepeatClientId);
            ViewBag.RiskLevelId = new SelectList(db.RiskLevels, "RiskLevelId", "Level", clients.RiskLevelId);
            ViewBag.RiskStatusId = new SelectList(db.RiskStatus, "RiskStatusId", "Status", clients.RiskStatusId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Type", clients.ServiceId);
            ViewBag.StatusOfFileId = new SelectList(db.StatusOfFiles, "StatusOfFileId", "Status", clients.StatusOfFileId);
            ViewBag.VictimOfIncidentId = new SelectList(db.VictimOfIncidents, "VictimOfIncidentId", "PrimaryOrSecondary", clients.VictimOfIncidentId);
            return View(clients);
        }

        // POST: Clients1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientReferenceNumber,FiscalYearId,Month,Day,Surname,FirstName,PoliceFileNumber,CourtFileNumber,SWCFileNumber,RiskLevelId,CrisisId,ServiceId,ProgramId,RiskAssessmentAssignedTo,RiskStatusId,AssignedWorkerId,ReferralSourceId,ReferralContactId,IncidentId,AbuserSurnameFirstName,AbuserRelationshipId,VictimOfIncidentId,FamilyViolenceFileId,Gender,EthnicityId,AgeId,RepeatClientId,DuplicateFileId,NumberOfChildren0to6,NumberOfChildren7to12,NumberOfChildren13to18,StatusOfFileId,DateLastTransferred,DateClosed,DateReOpened")] Clients clients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationships, "AbuserRelationshipId", "Relationship", clients.AbuserRelationshipId);
            ViewBag.AgeId = new SelectList(db.Ages, "AgeId", "Range", clients.AgeId);
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkers, "AssignedWorkerId", "Name", clients.AssignedWorkerId);
            ViewBag.CrisisId = new SelectList(db.Crises, "CrisisId", "Type", clients.CrisisId);
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFiles, "DuplicateFileId", "YesOrNull", clients.DuplicateFileId);
            ViewBag.EthnicityId = new SelectList(db.Ethnicities, "EthnicityId", "Description", clients.EthnicityId);
            ViewBag.FamilyViolenceFileId = new SelectList(db.FamilyViolenceFiles, "FamilyViolenceFileId", "FileExists", clients.FamilyViolenceFileId);
            ViewBag.FiscalYearId = new SelectList(db.FiscalYears, "FiscalYearId", "Years", clients.FiscalYearId);
            ViewBag.IncidentId = new SelectList(db.Incidents, "IncidentId", "Type", clients.IncidentId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "Type", clients.ProgramId);
            ViewBag.ReferralContactId = new SelectList(db.ReferralContacts, "ReferralContactId", "Contact", clients.ReferralContactId);
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSources, "ReferralSourceId", "Source", clients.ReferralSourceId);
            ViewBag.RepeatClientId = new SelectList(db.RepeatClients, "RepeatClientId", "YesOrNull", clients.RepeatClientId);
            ViewBag.RiskLevelId = new SelectList(db.RiskLevels, "RiskLevelId", "Level", clients.RiskLevelId);
            ViewBag.RiskStatusId = new SelectList(db.RiskStatus, "RiskStatusId", "Status", clients.RiskStatusId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Type", clients.ServiceId);
            ViewBag.StatusOfFileId = new SelectList(db.StatusOfFiles, "StatusOfFileId", "Status", clients.StatusOfFileId);
            ViewBag.VictimOfIncidentId = new SelectList(db.VictimOfIncidents, "VictimOfIncidentId", "PrimaryOrSecondary", clients.VictimOfIncidentId);
            return View(clients);
        }

        // GET: Clients1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // POST: Clients1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clients clients = db.Clients.Find(id);
            db.Clients.Remove(clients);
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
