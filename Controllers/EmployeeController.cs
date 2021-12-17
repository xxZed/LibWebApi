using LibWepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibWepApi.Controllers
{
    public class EmployeeController : ApiController
    {
        List<Employee> employee = new List<Employee>();
        

        public EmployeeController()
		{
            employee.Add(
                new Employee 
                { employeeId = 1, name = "Zed", lastName = "Name", address = "Split 60", contact = "+385 97 777 2222", salary = 70000, oib = "2134567890123", note = "Random note on a random person with a random mouse", employeeLibId = 1 }
                );
		}

        // GET: api/Employee
        public List<Employee> Get()
        {
            return employee;
        }

        // GET: api/Employee/5
        public Employee Get(int id)
        {
            return employee.Where(x => x.employeeId == id).FirstOrDefault();
        }

        // POST: api/Employee
        public void Post(Employee val)
        {
            employee.Add(val);
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
