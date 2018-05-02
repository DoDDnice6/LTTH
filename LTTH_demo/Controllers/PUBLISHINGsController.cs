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
    public class PUBLISHINGsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/PUBLISHINGs
        public IQueryable<PUBLISHING> GetPUBLISHINGs()
        {
            return db.PUBLISHINGs;
        }

        // GET: api/PUBLISHINGs/5
        [ResponseType(typeof(PUBLISHING))]
        public IHttpActionResult GetPUBLISHING(int id)
        {
            PUBLISHING pUBLISHING = db.PUBLISHINGs.Find(id);
            if (pUBLISHING == null)
            {
                return NotFound();
            }

            return Ok(pUBLISHING);
        }

        // PUT: api/PUBLISHINGs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPUBLISHING(int id, PUBLISHING pUBLISHING)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pUBLISHING.ID)
            {
                return BadRequest();
            }

            db.Entry(pUBLISHING).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PUBLISHINGExists(id))
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

        // POST: api/PUBLISHINGs
        [ResponseType(typeof(PUBLISHING))]
        public IHttpActionResult PostPUBLISHING(PUBLISHING pUBLISHING)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PUBLISHINGs.Add(pUBLISHING);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pUBLISHING.ID }, pUBLISHING);
        }

        // DELETE: api/PUBLISHINGs/5
        [ResponseType(typeof(PUBLISHING))]
        public IHttpActionResult DeletePUBLISHING(int id)
        {
            PUBLISHING pUBLISHING = db.PUBLISHINGs.Find(id);
            if (pUBLISHING == null)
            {
                return NotFound();
            }

            db.PUBLISHINGs.Remove(pUBLISHING);
            db.SaveChanges();

            return Ok(pUBLISHING);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PUBLISHINGExists(int id)
        {
            return db.PUBLISHINGs.Count(e => e.ID == id) > 0;
        }
    }
}