using GJBCTest.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace GJBCTest.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        //
        // GET: /Products/

        private DataContext db = new DataContext();

        public IEnumerable<Product> GetProducts() {
            return db.Products;
        }

        public Product GetProduct(int id) {
            Product product= db.Products.Find(id);
            if (product == null) {
                throw new HttpResponseException( Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return product;
        }

        public HttpResponseMessage PutProduct(int id, Product product) {
            if (ModelState.IsValid && id == product.Id)
            {
                db.Entry(product).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            else {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage PostProduct(Product product) {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, product);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = product.Id }));
                return response;
            }
            else {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        public HttpResponseMessage DeleteProduct(int id) {
            Product product = db.Products.Find(id);
            if (product == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Products.Remove(product);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
