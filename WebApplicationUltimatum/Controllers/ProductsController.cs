using System;
using System.Collections.Generic;
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
        public IEnumerable<string> GetProducts()
        {
            //Dictionary<string,string>
            /* public string QuantityPerUnit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
        public Nullable<short> UnitsOnOrder { get; set; }
        public Nullable<short> ReorderLevel { get; set; }
        public bool Discontinued { get; set; }*/
            /*  Dictionary<string, string> productsDictionary = new Dictionary<string, string>();
              for(int i=0; i<db.Products.ToList().Count; i++)
              {
                  productsDictionary.Add("ProductName",db.Products.ToList()[i].ProductName);
                  productsDictionary.Add("QuantityPerUnit", db.Products.ToList()[i].QuantityPerUnit);
                  productsDictionary.Add("UnitPrice", db.Products.ToList()[i].UnitPrice.ToString());
                  productsDictionary.Add("UnitsInStock", db.Products.ToList()[i].UnitsInStock.ToString());
                  productsDictionary.Add("UnitsOnOrder", db.Products.ToList()[i].UnitsOnOrder.ToString());
                  productsDictionary.Add("ReorderLevel", db.Products.ToList()[i].ReorderLevel.ToString());
                  productsDictionary.Add("Discontinued", db.Products.ToList()[i].Discontinued.ToString());

                  //productsDictionary.GetEnumerator();

              }*/
            int countlist = db.Products.ToList().Count;
            String[] vs = new string[countlist];
                            
            for (int i = 0; i < db.Products.ToList().Count; i++)
            {
                vs[i]="ProductName"+": " +db.Products.ToList()[i].ProductName 
                    +"; "+ "QuantityPerUnit"+": "+ db.Products.ToList()[i].QuantityPerUnit
                    + "; "+ "UnitPrice"+": "+ db.Products.ToList()[i].UnitPrice.ToString()
                    + "; "+"UnitsInStock"+ ": "+ db.Products.ToList()[i].UnitsInStock.ToString()
                    + "; " + "UnitsOnOrder" + ": " + db.Products.ToList()[i].UnitsOnOrder.ToString()
                    + "; " + "ReorderLevel" + ": " + db.Products.ToList()[i].ReorderLevel.ToString()
                    + "; " + "Discontinued" + ": " + db.Products.ToList()[i].Discontinued.ToString();
            }

            //return db.Products.ToList();
            return vs;
        }

        // GET: api/Products/5
        public string Get(int id)
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
        [Route("post")]
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
        [Route("put")]
        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        { 

        }

        // DELETE: api/Products/5
        [Route("del")]
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
    }
}
