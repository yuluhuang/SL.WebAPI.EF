﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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
    builder.EntitySet<User>("Login");
    builder.EntitySet<Collection>("Collection"); 
    builder.EntitySet<Info>("Info"); 
    builder.EntitySet<Note>("Note"); 
    builder.EntitySet<Theme>("Theme"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class LoginController : ODataController
    {
        private yuluhuangEntities db = new yuluhuangEntities();

        // GET odata/Login
       [Queryable]
        public IQueryable<User> GetLogin()
        {
            return db.userTable;
        }

         /*// GET odata/Login(5)
        [Queryable]
        public SingleResult<User> GetUser([FromODataUri] int key)
        {
            return SingleResult.Create(db.userTable.Where(user => user.Id == key));
        }

        // PUT odata/Login(5)
        public IHttpActionResult Put([FromODataUri] int key, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(user);
        }
        */
        // POST odata/Login
        public IHttpActionResult Post(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.userTable.Add(user);
            db.SaveChanges();

            return Created(user);
        }
        /*
        // PATCH odata/Login(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<User> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = db.userTable.Find(key);
            if (user == null)
            {
                return NotFound();
            }

            patch.Patch(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(user);
        }

        // DELETE odata/Login(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            User user = db.userTable.Find(key);
            if (user == null)
            {
                return NotFound();
            }

            db.userTable.Remove(user);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Login(5)/collectTable
        [Queryable]
        public IQueryable<Collection> GetcollectTable([FromODataUri] int key)
        {
            return db.userTable.Where(m => m.Id == key).SelectMany(m => m.collectTable);
        }

        // GET odata/Login(5)/infoTable
        [Queryable]
        public IQueryable<Info> GetinfoTable([FromODataUri] int key)
        {
            return db.userTable.Where(m => m.Id == key).SelectMany(m => m.infoTable);
        }

        // GET odata/Login(5)/noteTable
        [Queryable]
        public IQueryable<Note> GetnoteTable([FromODataUri] int key)
        {
            return db.userTable.Where(m => m.Id == key).SelectMany(m => m.noteTable);
        }

        // GET odata/Login(5)/themeTable
        [Queryable]
        public IQueryable<Theme> GetthemeTable([FromODataUri] int key)
        {
            return db.userTable.Where(m => m.Id == key).SelectMany(m => m.themeTable);
        }    */

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    
        private bool UserExists(int key)
        {
            return db.userTable.Count(e => e.Id == key) > 0;
        }
    }
}
