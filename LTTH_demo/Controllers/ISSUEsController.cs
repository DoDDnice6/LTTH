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
    public class ISSUEsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/ISSUEs
        public IQueryable<ISSUE> GetISSUEs()
        {
            return db.ISSUEs;
        }

        // GET: api/ISSUEs/5
        [ResponseType(typeof(ISSUE))]
        public IHttpActionResult GetISSUE(long id)
        {
            ISSUE iSSUE = db.ISSUEs.Find(id);
            if (iSSUE == null)
            {
                return NotFound();
            }

            return Ok(iSSUE);
        }

        // PUT: api/ISSUEs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutISSUE(long id, ISSUE iSSUE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != iSSUE.ID)
            {
                return BadRequest();
            }

            db.Entry(iSSUE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ISSUEExists(id))
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

        // POST: api/ISSUEs
        [ResponseType(typeof(ISSUE))]
        public IHttpActionResult PostISSUE(ISSUE iSSUE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ISSUEs.Add(iSSUE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = iSSUE.ID }, iSSUE);
        }

        // DELETE: api/ISSUEs/5
        [ResponseType(typeof(ISSUE))]
        public IHttpActionResult DeleteISSUE(long id)
        {
            ISSUE iSSUE = db.ISSUEs.Find(id);
            if (iSSUE == null)
            {
                return NotFound();
            }

            db.ISSUEs.Remove(iSSUE);
            db.SaveChanges();

            return Ok(iSSUE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ISSUEExists(long id)
        {
            return db.ISSUEs.Count(e => e.ID == id) > 0;
        }
    }
}