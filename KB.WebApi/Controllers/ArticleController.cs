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
using KB.Entity;

namespace KB.WebApi.Controllers
{
    public class ArticleController : ApiController
    {
        private KBEntities db = new KBEntities();

        // GET: api/Article
        public IQueryable<t_KB_Article> Gett_KB_Article()
        {
            return db.t_KB_Article;
        }

        // GET: api/Article/5
        [ResponseType(typeof(t_KB_Article))]
        public IHttpActionResult Gett_KB_Article(int id)
        {
            t_KB_Article t_KB_Article = db.t_KB_Article.Find(id);
            if (t_KB_Article == null)
            {
                return NotFound();
            }

            return Ok(t_KB_Article);
        }

        // PUT: api/Article/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt_KB_Article(int id, t_KB_Article t_KB_Article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_KB_Article.Id)
            {
                return BadRequest();
            }

            db.Entry(t_KB_Article).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t_KB_ArticleExists(id))
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

        // POST: api/Article
        [ResponseType(typeof(t_KB_Article))]
        public IHttpActionResult Postt_KB_Article(t_KB_Article t_KB_Article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t_KB_Article.Add(t_KB_Article);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t_KB_Article.Id }, t_KB_Article);
        }

        // DELETE: api/Article/5
        [ResponseType(typeof(t_KB_Article))]
        public IHttpActionResult Deletet_KB_Article(int id)
        {
            t_KB_Article t_KB_Article = db.t_KB_Article.Find(id);
            if (t_KB_Article == null)
            {
                return NotFound();
            }

            db.t_KB_Article.Remove(t_KB_Article);
            db.SaveChanges();

            return Ok(t_KB_Article);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t_KB_ArticleExists(int id)
        {
            return db.t_KB_Article.Count(e => e.Id == id) > 0;
        }
    }
}