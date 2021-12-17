using LibWepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibWepApi.Controllers
{
    public class MemberController : ApiController
    {

        List<Member> mem = new List<Member>();

        public MemberController()
		{
            mem.Add(new Member { memberId = 1, name = "Anto", lastName = "Last", address = "Sucidar 21", email = "antolast@gmail.com", contact = "+385 97 231 3123", oib = "3214567890123", enrollmentDate = "13.12.2020", memberLibID = 1 });
		}
        // GET: api/Member
        public List<Member> Get()
        {
            return mem;
        }

        // GET: api/Member/5
        public Member Get(int id)
        {
            return mem.Where(x => x.memberId == id).FirstOrDefault();
        }

        // POST: api/Member
        public void Post(Member val)
        {
            mem.Add(val);
        }

        // PUT: api/Member/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Member/5
        public void Delete(int id)
        {
        }
    }
}
