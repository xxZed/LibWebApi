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
    public class EmployeeController : ApiController
    {
        Employee employee = new Employee();
        

        // GET: api/Employee
        public DataSet Get()
        {
            return employee.Read_data();
        }

        // GET: api/Employee/5
        public DataSet Get(int id)
        {
            return employee.Read_data(id);
        }

        // POST: api/Employee
        public void Post(Employee val)
        {
            employee.Create_data(val);
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]Employee value)
        {
            employee.Update_data(id, value);
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            employee.Delete_data(id);
        }
    }
}
