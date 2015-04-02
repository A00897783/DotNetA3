using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using a2.Models;

namespace a2.Controllers
{
    public class Clients1Controller : ApiController
    {
        private SamaritanContext db = new SamaritanContext();

        // GET: api/Clients1
        public IQueryable<Clients> GetClients()
        {
            return db.Clients;
        }

        // GET: api/Clients1/5
        [ResponseType(typeof(Clients))]
        public IHttpActionResult GetClients(int id)
        {
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        // PUT: api/Clients1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClients(int id, Clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clients.ClientReferenceNumber)
            {
                return BadRequest();
            }

            db.Entry(clients).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clients1
        [ResponseType(typeof(Clients))]
        public IHttpActionResult PostClients(Clients clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(clients);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clients.ClientReferenceNumber }, clients);
        }

        // DELETE: api/Clients1/5
        [ResponseType(typeof(Clients))]
        public IHttpActionResult DeleteClients(int id)
        {
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return NotFound();
            }

            db.Clients.Remove(clients);
            db.SaveChanges();

            return Ok(clients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientsExists(int id)
        {
            return db.Clients.Count(e => e.ClientReferenceNumber == id) > 0;
        }
    }
}