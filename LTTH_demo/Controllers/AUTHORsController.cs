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
using LTTH_demo.Models;

namespace LTTH_demo.Controllers
{
    public class AUTHORsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/AUTHORs
        public IQueryable<AUTHOR> GetAUTHORs()
        {
            return db.AUTHORs;
        }

        // GET: api/AUTHORs/5
        [ResponseType(typeof(AUTHOR))]
        public IHttpActionResult GetAUTHOR(int id)
        {
            AUTHOR aUTHOR = db.AUTHORs.Find(id);
            if (aUTHOR == null)
            {
                return NotFound();
            }

            return Ok(aUTHOR);
        }

        // PUT: api/AUTHORs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAUTHOR(int id, AUTHOR aUTHOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aUTHOR.ID)
            {
                return BadRequest();
            }

            db.Entry(aUTHOR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AUTHORExists(id))
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

        // POST: api/AUTHORs
        [ResponseType(typeof(AUTHOR))]
        public IHttpActionResult PostAUTHOR(AUTHOR aUTHOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AUTHORs.Add(aUTHOR);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aUTHOR.ID }, aUTHOR);
        }

        // DELETE: api/AUTHORs/5
        [ResponseType(typeof(AUTHOR))]
        public IHttpActionResult DeleteAUTHOR(int id)
        {
            AUTHOR aUTHOR = db.AUTHORs.Find(id);
            if (aUTHOR == null)
            {
                return NotFound();
            }

            db.AUTHORs.Remove(aUTHOR);
            db.SaveChanges();

            return Ok(aUTHOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AUTHORExists(int id)
        {
            return db.AUTHORs.Count(e => e.ID == id) > 0;
        }
    }
}