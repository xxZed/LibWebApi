using LibWepApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace LibWepApi.Controllers
{
    public class LoanController : ApiController
    {
        // GET: api/Loan

        DatabaseConnection con = new DatabaseConnection();
        Loan loan = new Loan();

       [HttpGet]
        public HttpResponseMessage Get()
        {
            DataTable dt = loan.Read_data();           
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        // GET: api/Loan/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            DataTable dt = loan.Read_data(id);
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }
        
        [Route("api/Loan/BookCombo")]
        [HttpGet]
        public HttpResponseMessage BookCombo()
		{
            DataTable dt = loan.Read_Book();
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        [Route("api/Loan/MemberCombo")]
        [HttpGet]
        public HttpResponseMessage MemberCombo()
        {
            DataTable dt = loan.Read_Member();
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        [Route("api/Loan/EmployeeCombo")]
        [HttpGet]
        public HttpResponseMessage EmployeeCombo()
        {
            DataTable dt = loan.Read_Employee();
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }
        // POST: api/Loan
        [HttpPost]
        public void Post([FromBody] Loan val)
        {
            loan.Create_data(val);
        }

        // PUT: api/Loan/5
        [HttpPut]
        public void Put(int id, [FromBody]Loan value)
        {
            loan.Update_data(id,value);
        }

        // DELETE: api/Loan/5
        [HttpDelete]
        public void Delete(int id)
        {
            loan.Delete_data(id);
        }
    }
}
