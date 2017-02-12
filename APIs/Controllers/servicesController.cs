using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using APIs.Models;
using Modelos;
using Modelos.ViewModel;

namespace APIs.Controllers
{
    public class servicesController : ApiController
    {
        private APIsContext db = new APIsContext();

        // GET: Services/Articles
        [HttpGet]
        public Object articles()
        {
            var _result = new List<articles>();
            _result.Add(new articles() { id = 1, store_id = 1, description = "Descripcion", name = "Name" });
            return new { Articles = _result };
        }
        // GET: api/Stores

        //[HttpGet]
        //public Object stores()
        //{
        //    var _result = new List<stores>();
        //    _result.Add(new stores() { id = 1, name = "Tienda 1", address = "Direccion 1" });
        //    return new { Stores = _result };
        //}

        [HttpGet]
        public Object stores()
        {
            var _result = new List<stores>();
            _result.Add(new stores() { id = 1, address = "Direccion 1", name = "Tienda 1"});
            return new storesViewModel() { sucess = true, stores = _result};
        }

        // GET: Services/Articles/5
        [ResponseType(typeof(articles))]
        public async Task<IHttpActionResult> GetArticles(int id)
        {
            articles articles = await db.Articles.FindAsync(id);
            if (articles == null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        // PUT: Services/Articles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArticles(int id, articles articles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != articles.id)
            {
                return BadRequest();
            }

            db.Entry(articles).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticlesExists(id))
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

        // POST: Services/Articles
        [ResponseType(typeof(articles))]
        public async Task<IHttpActionResult> PostArticles(articles articles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Articles.Add(articles);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = articles.id }, articles);
        }

        // DELETE: Services/Articles/5
        [ResponseType(typeof(articles))]
        public async Task<IHttpActionResult> DeleteArticles(int id)
        {
            articles articles = await db.Articles.FindAsync(id);
            if (articles == null)
            {
                return NotFound();
            }

            db.Articles.Remove(articles);
            await db.SaveChangesAsync();

            return Ok(articles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArticlesExists(int id)
        {
            return db.Articles.Count(e => e.id == id) > 0;
        }
    }
}