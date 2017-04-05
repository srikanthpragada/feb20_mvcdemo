using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcDemo
{
    public class BooksController : ApiController
    {
           List<Book> books = new List<Book>
            {
                new Book {  Id = 1, Title = "Asp.Net MVC", Price = 550},
                new Book { Id = 2, Title = "Entity Framework", Price = 500 }
            };

        // GET api/<controller>
        public IEnumerable<Book> Get()
        {
           
            return books; 

        }

        // GET api/<controller>/5
        public Book Get(int id)
        {
            foreach(Book b in books)
            {
                if (b.Id == id)
                    return b;
            }

            // book is not found
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        /*
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        */

    }
}