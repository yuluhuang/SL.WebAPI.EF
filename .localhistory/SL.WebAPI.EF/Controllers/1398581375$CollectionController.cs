using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SL.WebAPI.EF.Models;
using System.ServiceModel.Web;

namespace SL.WebAPI.EF.Controllers
{
    public class CollectionController : ApiController
    {
        private yuluhuangEntities db = new yuluhuangEntities();
        static readonly ISLRepository<Collection> repository = new CollectionRepository();
        /// <summary>
        /// get all collect
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Collection> GetAllCollects()
        {
            //return repository.GetAll();
            object a= db.collectTable;
            return db.collectTable;
        }
        /// <summary>
        /// get one by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Collection GetCollect(int id)
        {
            Collection item = GetAllCollects().First(p => p.collectId == id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
            //Collection item = repository.Get(id);
            //if (item == null) {
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            //return item;
        }
        /// <summary>
        ///  match by condition
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public IEnumerable<Collection> GetCollectByTime(string time)
        {
            return repository.GetAll().Where(p =>
                string.Equals(p.time, time, StringComparison.OrdinalIgnoreCase));
        }
        /// <summary>
        /// add a record
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public HttpResponseMessage PostCollect(Collection item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Collection>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.collectId });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        public void PutCollect(int id, Collection collect)
        {
            collect.collectId = id;
            if (!repository.Update(collect))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        [HttpPost, ActionName("Delete")]
        public HttpResponseMessage Delete(string key)
        {
            Collection collection = db.collectTable.Find(key);
            if (collection == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.collectTable.Remove(collection);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
