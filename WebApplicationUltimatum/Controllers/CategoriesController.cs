using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplicationUltimatum.Models;

namespace WebApplicationUltimatum.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        private NorthwindEntitiesDBContext db = new NorthwindEntitiesDBContext();

        // GET: api/Categories
        [AllowAnonymous]
        [HttpGet]
       //[Route("Get")]
        public IQueryable<Category> GetCategories()
        {
            //ObservableCollection<Category> categories=new ObservableCollection<Category>();

            //for (int i = 0; i
            //    < db.Categories.ToList().Count; i++)
            //{
            //    //categories[i] = db.Categories.ToList()[i];
            //}
            return db.Categories;//.ToList();
        }
        /* public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/
        
        //[Route("[id]")]
        // GET: api/Categories/5
        [AllowAnonymous]
        [ResponseType(typeof(Category))]
        [HttpGet]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [AllowAnonymous]
        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryID)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [AllowAnonymous]
        [ResponseType(typeof(Category))]
        [HttpPost]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryID }, category);
        }

        // DELETE: api/Categories/5
        [AllowAnonymous]
        [Route("{id}")]
        [ResponseType(typeof(Category))]
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.CategoryID == id) > 0;
        }
    }
}