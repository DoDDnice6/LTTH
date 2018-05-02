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
using LTTH.Models;
using System.Web.Mvc;
using System.Web.Http.Cors;

namespace LTTH.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BOOKsController : ApiController
    {

        
        private DBContext db = new DBContext();

        // GET: api/BOOKs
        public IEnumerable<BOOK> GetBOOKs()
        {
            return db.BOOKs.Include(s=>s.PublishID).ToList();
        }

        // GET: api/BOOKs/5
        [ResponseType(typeof(BOOK))]
        public IHttpActionResult GetBOOK(long id)
        {
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return NotFound();
            }

            return Ok(bOOK);
        }

        // PUT: api/BOOKs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBOOK(long id, [FromBody] BOOK bOOK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                //return Json(new { success = false,  errors = ModelState.Values.Where(i => i.Errors.Count > 0) });
            }

            if (id != bOOK.ID)
            {
                return BadRequest();
            }

            db.Entry(bOOK).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BOOKExists(id))
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

        // POST: api/BOOKs
        [ResponseType(typeof(BOOK))]
        public IHttpActionResult PostBOOK(BOOK bOOK)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Content(HttpStatusCode.NotFound, "Nhap Sai");
            }

            db.BOOKs.Add(bOOK);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bOOK.ID }, bOOK);
        }

        // DELETE: api/BOOKs/5
        [ResponseType(typeof(BOOK))]
        public IHttpActionResult DeleteBOOK(long id)
        {
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return NotFound();
            }

            db.BOOKs.Remove(bOOK);
            db.SaveChanges();

            return Ok(bOOK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BOOKExists(long id)
        {
            return db.BOOKs.Count(e => e.ID == id) > 0;
        }


        public IHttpActionResult GetBOOK_(long id)
        {
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return NotFound();
            }

            return Ok(bOOK);
        }
    }
}