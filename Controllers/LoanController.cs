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
    public class LoanController : ApiController
    {
        // GET: api/Loan
        Loan loan = new Loan();
        public LoanController()
        {

        }
        public DataSet Get()
        {
            return loan.Read_data();
        }

        // GET: api/Loan/5
        public DataSet Get(int id)
        {
            return loan.Read_data(id);
        }

        // POST: api/Loan
        public void Post(Loan val)
        {
            loan.Create_data(val);
        }

        // PUT: api/Loan/5
        public void Put(int id, [FromBody]Loan value)
        {
            loan.Update_data(id,value);
        }

        // DELETE: api/Loan/5
        public void Delete(int id)
        {
            loan.Delete_data(id);
        }
    }
}
