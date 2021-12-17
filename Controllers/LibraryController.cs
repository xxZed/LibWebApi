using LibWepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibWepApi.Controllers
{
    public class LibraryController : ApiController
    {
        List<Library> lib = new List<Library>();
        public LibraryController()
		{
            lib.Add(new Library { name = "Project Lib", address = "Trstenik 21", contact = "+385 99 999 1234", email = "projectlib@email.com", oib = "1234567890123", zip = "21000",fine = 1, returnDate = 30 ,libraryId = 1 });
		}

        // GET: api/Library
        public List<Library> Get()
        {
            return lib;
        }

        // GET: api/Library/5
        public Library Get(int id)
        {
            return lib.Where(x => x.libraryId == id).FirstOrDefault();
        }

        // POST: api/Library
        public void Post(Library value)
        {
            lib.Add(value);
        }

        // PUT: api/Library/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Library/5
        public void Delete(int id)
        {
        }
    }
}
