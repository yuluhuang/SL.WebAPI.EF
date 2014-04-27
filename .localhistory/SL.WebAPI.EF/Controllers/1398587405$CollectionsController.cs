using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using SL.WebAPI.EF.Models;

namespace SL.WebAPI.EF.Controllers
{
    /*
    若要为此控制器添加路由，请将这些语句合并到 WebApiConfig 类的 Register 方法中。请注意 OData URL 区分大小写。

    using System.Web.Http.OData.Builder;
    using SL.WebAPI.EF.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Collection>("Collections");
    builder.EntitySet<User>("userTable"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CollectionsController : ODataController
    {
        private yuluhuangEntities db = new yuluhuangEntities();

        // GET odata/Collections
        [Queryable]
        public IQueryable<Collection> GetCollections()
        {
            return db.collectTable;
        }

        // GET odata/Collections(5)
        [Queryable]
        public SingleResult<Collection> GetCollection([FromODataUri] int key)
        {
            return SingleResult.Create(db.collectTable.Where(collection => collection.collectId == key));
        }
        [AcceptVerbs("POST", "PUT")]
        // PUT odata/Collections(5)
        public IHttpActionResult Put([FromODataUri] int key, Collection collection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != collection.collectId)
            {
                return BadRequest();
            }

            db.Entry(collection).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(collection);
        }

        // POST odata/Collections
        public IHttpActionResult Post(Collection collection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.collectTable.Add(collection);
            db.SaveChanges();

            return Created(collection);
        }

        // PATCH odata/Collections(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Collection> patch) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Collection collection = db.collectTable.Find(key);
            if (collection == null)
            {
                return NotFound();
            }

            patch.Patch(collection);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(collection);
        }
        // DELETE odata/Collections(5)
         [HttpPost, ActionName("Delete")]
        public IHttpActionResult Delete([FromODataUri] int key,[FromBody] string test)
        {
            Collection collection = db.collectTable.Find(key);
            if (collection == null)
            {
                return NotFound();
            }

            db.collectTable.Remove(collection);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Collections(5)/userTable
        [Queryable]
        public SingleResult<User> GetuserTable([FromODataUri] int key)
        {
            return SingleResult.Create(db.collectTable.Where(m => m.collectId == key).Select(m => m.userTable));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CollectionExists(int key)
        {
            return db.collectTable.Count(e => e.collectId == key) > 0;
        }
    }
}
