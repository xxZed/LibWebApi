using LibWepApi.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibWepApi.Controllers
{
    public class BookController : ApiController
    {
        Book books = new Book();       

        // GET: api/Book
        public DataSet Get()
        {
           return books.Read_data();
        }

        // GET: api/Book/5
        public DataSet Get(int id)
        {
            return books.Read_data(id);
        }

        // POST: api/Book
        public void Post(Book value)
        {
            books.Create_data(value);
        }

        // PUT: api/Book/5
        public void Put(int id, [FromBody]Book value)
        {
            books.Update_data(id, value);
        }

        // DELETE: api/Book/5
        public void Delete(int id)
        {
            books.Delete_data(id);
        }
    }
}
