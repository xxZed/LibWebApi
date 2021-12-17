using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibWepApi.Models
{
	public class Employee
	{
		public int employeeId { get; set; } = 0;
		public string name { get; set; } = " ";
		public string lastName { get; set; } = " ";
		public string oib { get; set; } = " ";
		public int salary { get; set; }
		public string address { get; set; } = " ";
		public string contact { get; set; } = " ";
		public string note { get; set; } = " ";
		public int employeeLibId { get; set; }
	}
}