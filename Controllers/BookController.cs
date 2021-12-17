using LibWepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibWepApi.Controllers
{
    public class BookController : ApiController
    {
        List<Book> books = new List<Book>();
        public BookController()
        {
            books.Add(new Book { bookId = 1, author = "Felix Len", bookName = "How", stock = 2000, bookLibId = 1, publishDate = "11.11.2011", bookGenreId = 1 }) ;
            books.Add(new Book { bookId = 2, author = "Nikola Tesla", bookName = "Power", stock = 3000, bookLibId = 1, publishDate = "11.11.2012", bookGenreId = 2 });
            books.Add(new Book { bookId = 3, author = "Dr Phil", bookName = "Catch me outside", stock = 4000, bookLibId = 1, publishDate = "11.11.2013", bookGenreId = 3 });
            books.Add(new Book { bookId = 4, author = "Ramee", bookName = "How not to", stock = 1000, bookLibId = 1, publishDate = "11.11.2020", bookGenreId = 4 });
            books.Add(new Book { bookId = 5, author = "Rae", bookName = "Reflect xd", stock = 100, bookLibId = 1, publishDate = "11.11.2021", bookGenreId= 5 });          

        }

        [Route("api/Book/BookGenre")]
        [HttpGet]
        public List<string> BookGenre()
		{
            List<string> output = new List<string>();
			foreach (var g in books)
			{
                
                output.Add(g.author + ": " + g.bookName);
			}
            return output;
		}

        // GET: api/Book
        public List<Book> Get()
        {
            return books;
        }

        // GET: api/Book/5
        public Book Get(int id)
        {
            return books.Where(x => x.bookId == id).FirstOrDefault();
        }

        // POST: api/Book
        public void Post(Book value)
        {
            books.Add(value);
        }

        // PUT: api/Book/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Book/5
        public void Delete(int id)
        {
        }
    }
}
