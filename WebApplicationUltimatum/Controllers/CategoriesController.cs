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
using System.Web.Http.Results;
using System.Web.Mvc;
using WebApplicationUltimatum.Models;

namespace WebApplicationUltimatum.Controllers
{
    public class CategoriesController : ApiController
    {
        private NorthwindEntitiesDBContext db = new NorthwindEntitiesDBContext();

        // GET: api/CategoriesAPI
        //[Route("problem")]
        //public IQueryable<Category> GetCategories()
        //{
        //    return db.Categories;
        //}
        public IEnumerable<string> GetCategories()
        {
            int countlist = db.Categories.ToList().Count;
            String[] vs = new string[countlist];

            for (int j = 0; j < countlist; j++)
            {
                vs[j] = "CategoryName" + ": " + db.Categories.ToList()[j].CategoryName
                    + "; " + "Description" + ": " + db.Categories.ToList()[j].Description;
            }
            return vs;

            // db.Categories.;
            //return Request.CreateResponse(HttpStatusCode.OK,db.Categories);
        }
        //public ActionResult GetCategories()
        //{
        //    List<Category> categories = new List<Category>();
        //    for(int i=0;i<db.Categories.ToList().Count;i++)
        //    {
        //        categories[i]=db.Categories.ToList()[i];
        //    }
        //    return categories;
        //}

        // GET: api/CategoriesAPI/5
        //[ResponseType(typeof(Category))]
        //public async Task<IHttpActionResult> GetCategory(int id)
        //{
        //    Category category = await db.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(category);
        //}
        public string GetCategory(int id)
        {
            int index = GetIndexById(id);
            string value;
            value = "ProductName" + ": " + db.Categories.ToList()[index].CategoryName
                 + "; " + "Description" + ": " + db.Categories.ToList()[index].Description;
            return value;
        }
        private int GetIndexById(int id)
        {
            int index = 0;
            for (int i = 0; i < db.Products.ToList().Count; i++)
            {
                if (id == db.Products.ToList()[i].ProductID)
                {
                    index = i;
                    break;
                }

            }
            return index;
        }
        
        // PUT: api/CategoriesAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategory(int id, Category category)
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
                await db.SaveChangesAsync();
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

        // POST: api/CategoriesAPI
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryID }, category);
        }

        // DELETE: api/CategoriesAPI/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> DeleteCategory(int id)
        {
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            await db.SaveChangesAsync();

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