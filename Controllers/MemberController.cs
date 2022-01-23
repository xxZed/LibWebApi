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
    public class MemberController : ApiController
    {

        Member mem = new Member();

        // GET: api/Member
        public DataSet Get()
        {
            return mem.Read_data();
        }

        // GET: api/Member/5
        public DataSet Get(int id)
        {
            return mem.Read_data(id);
        }

        // POST: api/Member
        public void Post(Member val)
        {
            mem.Create_data(val);
        }

        // PUT: api/Member/5
        public void Put(int id, [FromBody]Member value)
        {
            mem.Update_data(id, value);
        }

        // DELETE: api/Member/5
        public void Delete(int id)
        {
            mem.Delete_data(id);
        }
    }
}
