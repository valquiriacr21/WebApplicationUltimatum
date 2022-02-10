﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationUltimatum.Models;

namespace WebApplicationUltimatum.Controllers
{
    public class ProductsController : ApiController
    {
        private NorthwindEntitiesDBContext db = new NorthwindEntitiesDBContext();
        // GET: api/Products
        //public IEnumerable<string> GetProducts()
        //{
        //    //Dictionary<string,string>
        //    /* public string QuantityPerUnit { get; set; }
        //public Nullable<decimal> UnitPrice { get; set; }
        //public Nullable<short> UnitsInStock { get; set; }
        //public Nullable<short> UnitsOnOrder { get; set; }
        //public Nullable<short> ReorderLevel { get; set; }
        //public bool Discontinued { get; set; }*/
        //    /*  Dictionary<string, string> productsDictionary = new Dictionary<string, string>();
        //      for(int i=0; i<db.Products.ToList().Count; i++)
        //      {
        //          productsDictionary.Add("ProductName",db.Products.ToList()[i].ProductName);
        //          productsDictionary.Add("QuantityPerUnit", db.Products.ToList()[i].QuantityPerUnit);
        //          productsDictionary.Add("UnitPrice", db.Products.ToList()[i].UnitPrice.ToString());
        //          productsDictionary.Add("UnitsInStock", db.Products.ToList()[i].UnitsInStock.ToString());
        //          productsDictionary.Add("UnitsOnOrder", db.Products.ToList()[i].UnitsOnOrder.ToString());
        //          productsDictionary.Add("ReorderLevel", db.Products.ToList()[i].ReorderLevel.ToString());
        //          productsDictionary.Add("Discontinued", db.Products.ToList()[i].Discontinued.ToString());

        //          //productsDictionary.GetEnumerator();

        //      }*/
        //    int countlist = db.Products.ToList().Count;
        //    String[] vs = new string[countlist];
                            
        //    for (int i = 0; i < db.Products.ToList().Count; i++)
        //    {
        //        vs[i]="ProductName"+": " +db.Products.ToList()[i].ProductName 
        //            +"; "+ "QuantityPerUnit"+": "+ db.Products.ToList()[i].QuantityPerUnit
        //            + "; "+ "UnitPrice"+": "+ db.Products.ToList()[i].UnitPrice.ToString()
        //            + "; "+"UnitsInStock"+ ": "+ db.Products.ToList()[i].UnitsInStock.ToString()
        //            + "; " + "UnitsOnOrder" + ": " + db.Products.ToList()[i].UnitsOnOrder.ToString()
        //            + "; " + "ReorderLevel" + ": " + db.Products.ToList()[i].ReorderLevel.ToString()
        //            + "; " + "Discontinued" + ": " + db.Products.ToList()[i].Discontinued.ToString();
        //    }

        //    //return db.Products.ToList();
        //    return vs;
        //}

        public IHttpActionResult GetProducts()
        {
            //Dictionary<string,string>
            /* public string QuantityPerUnit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
        public Nullable<short> UnitsOnOrder { get; set; }
        public Nullable<short> ReorderLevel { get; set; }
        public bool Discontinued { get; set; }*/
            //Json json 
            int countlist = db.Products.ToList().Count;
            String[] vs = new string[countlist];
            String productName="";
            String quantityPerUnit = "";
            String unitPrice = "";
            String unitsInStock = "";
            String unitsOnOrder = "";
            String reorderLevel = "";
            String discontinued = "";
            Dictionary<string, string> productsDictionary = new Dictionary<string, string>();
            for (int i = 0; i < db.Products.ToList().Count; i++)
            {
                productName = "ProductName " + i.ToString();
                productsDictionary.Add((productName), db.Products.ToList()[i].ProductName);
                quantityPerUnit = "QuantityPerUnit " + i.ToString();
                productsDictionary.Add(quantityPerUnit, db.Products.ToList()[i].QuantityPerUnit);
                unitPrice = "UnitPrice " + i.ToString();
                productsDictionary.Add(unitPrice, db.Products.ToList()[i].UnitPrice.ToString());
                unitsInStock = "UnitsInStock " + i.ToString();
                productsDictionary.Add(unitsInStock, db.Products.ToList()[i].UnitsInStock.ToString());
                unitsOnOrder = "UnitsOnOrder " + i.ToString();
                productsDictionary.Add(unitsOnOrder, db.Products.ToList()[i].UnitsOnOrder.ToString());
                reorderLevel = "ReorderLevel " + i.ToString();
                productsDictionary.Add(reorderLevel, db.Products.ToList()[i].ReorderLevel.ToString());
                discontinued = "Discontinued " + i.ToString();
                productsDictionary.Add(discontinued, db.Products.ToList()[i].Discontinued.ToString());

                //productsDictionary.GetEnumerator();

            }

            //for (int i = 0; i < db.Products.ToList().Count; i++)
            //{
            //    vs[i] = "ProductName" + ": " + db.Products.ToList()[i].ProductName
            //        + "; " + "QuantityPerUnit" + ": " + db.Products.ToList()[i].QuantityPerUnit
            //        + "; " + "UnitPrice" + ": " + db.Products.ToList()[i].UnitPrice.ToString()
            //        + "; " + "UnitsInStock" + ": " + db.Products.ToList()[i].UnitsInStock.ToString()
            //        + "; " + "UnitsOnOrder" + ": " + db.Products.ToList()[i].UnitsOnOrder.ToString()
            //        + "; " + "ReorderLevel" + ": " + db.Products.ToList()[i].ReorderLevel.ToString()
            //        + "; " + "Discontinued" + ": " + db.Products.ToList()[i].Discontinued.ToString();
            //}

            //return db.Products.ToList();
            //return vs;
            return Json(new { productsDictionary });
        }

        // GET: api/Products/5
        public string GetProduct(int id)
        {
            int index = GetIndexById(id);
            string value;
            value=( "ProductName" + ": " +db.Products.ToList()[index].ProductName
                 + "; " + "QuantityPerUnit" + ": " + db.Products.ToList()[index].QuantityPerUnit
                    + "; " + "UnitPrice" + ": " + db.Products.ToList()[index].UnitPrice.ToString()
                    + "; " + "UnitsInStock" + ": " + db.Products.ToList()[index].UnitsInStock.ToString()
                    + "; " + "UnitsOnOrder" + ": " + db.Products.ToList()[index].UnitsOnOrder.ToString()
                    + "; " + "ReorderLevel" + ": " + db.Products.ToList()[index].ReorderLevel.ToString()
                    + "; " + "Discontinued" + ": " + db.Products.ToList()[index].Discontinued.ToString());
            return value;
        }
        private int GetIndexById(int id)
        {
            int index = 0;
            for (int i = 0; i < db.Products.ToList().Count; i++)
            {
                if(id== db.Products.ToList()[i].ProductID)
                {
                    index = i;
                    break;
                }
                                 
            }
            return index;
        }
        [Route("POST")]
        // POST: api/Products
        //ADD
        public void Post(Product product/*[FromBody]string value*/)
        {
            ///Sumary
            ///I need to programmer a read string for add to products key
            ///Necesito programar una lectura de string para adicionar a las variables y llaves de productos
            ///Sumary end
           
            if (!ModelState.IsValid)
            {
               // return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChangesAsync();

            CreatedAtRoute("DefaultApi", new { id = product.CategoryID }, product);
        }
        [Route("PUT")]
        // PUT: api/Products/5
        public void Put(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
               // return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                // return BadRequest();
                Console.WriteLine("Bad request");
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                 db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    //return NotFound();
                    Console.WriteLine("No Found");
                }
                else
                {
                    throw;
                }
            }

           // return StatusCode(HttpStatusCode.NoContent);

        }

        // DELETE: api/Products/5
        [Route("DELETE")]
        public void Delete(int id)
        {
            int index= GetIndexById(id);
            Product product = db.Products.Find(id);
            //if (category == null)
            //{
            //    // NotFound();
            //    Notr
            //}
            db.Products.Remove(product);
            db.SaveChangesAsync();
            Console.WriteLine("Ok");

            //Console.Log(Ok(category);
        }
        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}
