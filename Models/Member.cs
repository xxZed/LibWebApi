using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibWepApi.Models
{
	public class Member
	{
		public int memberId { get; set; } = 0;
		public string name { get; set; } = " ";
		public string lastName { get; set; } = " ";
		public string oib { get; set; } = " ";

		public string address { get; set; } = " ";
		public string contact { get; set; } = " ";
		public string email { get; set; } = " ";
		public string enrollmentDate { get; set; } = " ";
		public int memberLibID { get; set; }
	}
}


