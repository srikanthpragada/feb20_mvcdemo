using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcDemo.Controllers
{
    public class TitlesController : ApiController
    {
        
        public IEnumerable<Title> Get()
        {
            CatalogContext ctx = new CatalogContext();
            return ctx.Titles;
        }

       
        public IHttpActionResult Get(int id)
        {
            CatalogContext ctx = new CatalogContext();
            var title = ctx.Titles.Find(id);
            if (title == null)
                return this.NotFound();
            else
                return this.Ok(title); 
        }

        
        public void Post([FromBody] Title title)
        {
            try {
                CatalogContext ctx = new CatalogContext();
                ctx.Titles.Add(title);
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] Title newTitle)
        {
            CatalogContext ctx = new CatalogContext();
            var title = ctx.Titles.Find(id);  // get title from DB
            if (title == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            // update db object with data coming from request 
            title.Name = newTitle.Name;
            title.Price = newTitle.Price;
            title.Author = newTitle.Author;
            ctx.SaveChanges();
        }

        
        public void Delete(int id)
        {
            CatalogContext ctx = new CatalogContext();
            var title = ctx.Titles.Find(id);
            if (title == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            ctx.Titles.Remove(title);
            ctx.SaveChanges();
        }
    }
}