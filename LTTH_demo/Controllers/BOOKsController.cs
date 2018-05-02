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
using LTTH_demo.Models.DTO;

namespace LTTH_demo.Controllers
{
    public class BOOKsController : ApiController
    {
        private MyDbContext db = new MyDbContext();

        // GET: api/BOOKs
        public IQueryable<BOOK> GetBOOKs()
        {
            return db.BOOKs;
        }

        [HttpGet]
        public IList<BOOKdto> ListBook()
        {
            var list = (from b in db.BOOKs
                        join a in db.AUTHORs on b.AuthorID equals a.ID into author
                        from a in author.DefaultIfEmpty()
                        join p in db.PUBLISHINGs on b.PublishID equals p.ID into pub
                        from p in pub.DefaultIfEmpty()
                        join c in db.CATEGORies on b.CategoryID equals c.ID into cate
                        from c in cate.DefaultIfEmpty()
                        select new BOOKdto() { ID = b.ID,Name=b.Name,Author=a.Name,Publish=p.Name }).ToList();
            return list.ToList();
        }
        [HttpGet]
        public BOOKdto BookDetail(long id)
        {
            BOOK book = db.BOOKs.Find(id);
            if (book == null) return new BOOKdto();
            var obj = (from b in db.BOOKs
                        join a in db.AUTHORs on b.AuthorID equals a.ID into author
                        from a in author.DefaultIfEmpty()
                        join p in db.PUBLISHINGs on b.PublishID equals p.ID into pub
                        from p in pub.DefaultIfEmpty()
                        join c in db.CATEGORies on b.CategoryID equals c.ID into cate
                        from c in cate.DefaultIfEmpty()
                        where b.ID == id
                        select new BOOKdto() { ID = b.ID, Name = b.Name, Author = a.Name, Publish = p.Name }).ToList().SingleOrDefault();
            return obj;
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
        public IHttpActionResult PutBOOK(long id, BOOK bOOK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
                return BadRequest(ModelState);
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
    }
}