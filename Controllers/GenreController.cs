using LibWepApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibWepApi.Controllers
{
    public class GenreController : ApiController
    {
        Genre gen = new Genre();

        public GenreController()
		{
            
        }

        // GET: api/Genre
        public DataSet Get()
        {
            return gen.Read_data();
        }

        // GET: api/Genre/5
        public DataSet Get(int id)
        {
            return gen.Read_data(id);
        }

        // POST: api/Genre
        public void Post(Genre val)
        {
            gen.Create_data(val);
        }

        // PUT: api/Genre/5
        public void Put(int id, [FromBody]Genre value)
        {
            gen.Update_data(id, value);
        }

        // DELETE: api/Genre/5
        public void Delete(int id)
        {
            gen.Delete_data(id);
        }
    }
}
