using LibWepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibWepApi.Controllers
{
    public class GenreController : ApiController
    {
        List<Genre> gen = new List<Genre>();

        public GenreController()
		{
            gen.Add(new Genre { genreID = 1, genre = "Sci-fi" });
            gen.Add(new Genre { genreID = 2, genre = "Thriller" });
            gen.Add(new Genre { genreID = 3, genre = "Comedy" });
            gen.Add(new Genre { genreID = 4, genre = "Action" });

        }
        [Route("api/Genre/GetGenreName/")]
        [HttpGet]
        public List<string> GetGenreName()
        {
            List<string> output = new List<string>();
            foreach (var g in gen)
            {

                output.Add(g.genre);
            }
            return output;
        }
        // GET: api/Genre
        public List<Genre> Get()
        {
            return gen;
        }

        // GET: api/Genre/5
        public Genre Get(int id)
        {
            return gen.Where(x => x.genreID == id).FirstOrDefault();
        }

        // POST: api/Genre
        public void Post(Genre val)
        {
            gen.Add(val);
        }

        // PUT: api/Genre/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Genre/5
        public void Delete(int id)
        {
        }
    }
}
