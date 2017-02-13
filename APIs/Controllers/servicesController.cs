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
        public articlesViewModel articles()
        {
            var _result = db.articles.Include(x => x.stores).ToList();
            return new articlesViewModel() { sucess = true, articles = _result };
        }
        // GET: services/articles/{id}
        [HttpGet]
        public articles articles(int id)
        {
            var _result = db.articles.Find(id);
            return _result;
        }
        // POST: services/articles/postarticle
        [HttpPost]
        [Route("services/articles/postarticle")]
        public articles postarticle(articles _entidad)
        {
            var _result = db.articles.AsNoTracking().Any(x => x.id == _entidad.id);
            // preguntar si es nula
            db.articles.Attach(_entidad);
            var entry = db.Entry(_entidad);
            entry.State = EntityState.Modified;
            db.SaveChanges();
            return _entidad;
        }
        // PUT: services/articles/putarticle
        [HttpPut]
        [Route("services/articles/putarticle")]
        public Object putarticle(articles _entidad)
        {
            var _result = db.articles.AsNoTracking().Any(x => x.id == _entidad.id);
            // preguntar si existe y retornas error
            if (_result)
            {
                db.articles.Add(_entidad);
                db.SaveChanges();
                return _entidad;
            }
            else
            {
                return new errorViewModel() { error_msg = "Record already exist ", error_code = 400, sucess = false };
            }
            
        }


        // GET: /services/stores
        [HttpGet]
        public storesViewModel stores()
        {
            var _result = db.stores.ToList();
            return new storesViewModel() { sucess = true, stores = _result };
        }

        // GET: /services/articles/stores/:id 
        [HttpGet]
        [Route("services/articles/stores/{id_str}")]
        public object article_by_store(string id_str)
        {
            int id;
            if (!int.TryParse(id_str, out id))
            {
                return new errorViewModel() { error_msg = "Bad Request", error_code =400, sucess = false };
            }
            else
            {
                var _result = db.articles.Include(x => x.stores).Where(x => x.store_id == id).ToList();
                if (_result.Any(x => x.store_id == id))
                {
                    return new articlesViewModel() { sucess = true, articles = _result };
                }
                else
                {
                    return new errorViewModel() { error_msg = "Record not Found ", error_code = 404, sucess = false };
                }               
            }  
        }

        //[HttpGet]
        //public Object stores()
        //{
        //    var _result = new List<stores>();
        //    _result.Add(new stores() { id = 1, name = "Tienda 1", address = "Direccion 1" });
        //    return new { Stores = _result };
        //}

        //[HttpGet]
        //public Object stores()
        //{
        //    var _result = new List<stores>();
        //    _result.Add(new stores() { id = 1, address = "Direccion 1", name = "Tienda 1"});
        //    return new storesViewModel() { sucess = true, stores = _result};
        //}

        // GET: Services/Articles/5
        [ResponseType(typeof(articles))]
        public async Task<IHttpActionResult> GetArticles(int id)
        {
            articles articles = await db.articles.FindAsync(id);
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

            db.articles.Add(articles);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = articles.id }, articles);
        }

        // DELETE: Services/Articles/5
        [ResponseType(typeof(articles))]
        public async Task<IHttpActionResult> DeleteArticles(int id)
        {
            articles articles = await db.articles.FindAsync(id);
            if (articles == null)
            {
                return NotFound();
            }

            db.articles.Remove(articles);
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
            return db.articles.Count(e => e.id == id) > 0;
        }
    }
}