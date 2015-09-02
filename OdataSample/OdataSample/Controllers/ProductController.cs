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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using OdataSample.Models;

namespace OdataSample.Controllers
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using OdataSample.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Products>("Product");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ProductController : ODataController
    {
        private ODataContext db = new ODataContext();

        // GET odata/Product
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<Products> Get()
        {
            return db.Products.AsQueryable();
        }

        // GET odata/Product(5)
        [EnableQuery]
        public SingleResult<Products> Get([FromODataUri] int key)
        {
            return SingleResult.Create(db.Products.Where(products => products.ProductId == key));
        }

        // PUT odata/Product(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != products.ProductId)
            {
                return BadRequest();
            }

            db.Entry(products).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(products);
        }

        // POST odata/Product
        public async Task<IHttpActionResult> Post(Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(products);
            await db.SaveChangesAsync();

            return Created(products);
        }

        // PATCH odata/Product(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Products> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Products products = await db.Products.FindAsync(key);
            if (products == null)
            {
                return NotFound();
            }

            patch.Patch(products);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(products);
        }

        // DELETE odata/Product(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Products products = await db.Products.FindAsync(key);
            if (products == null)
            {
                return NotFound();
            }

            db.Products.Remove(products);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductsExists(int key)
        {
            return db.Products.Count(e => e.ProductId == key) > 0;
        }
    }
}
