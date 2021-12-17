using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibWepApi.Models
{
	public class Library
	{
		public int libraryId { get; set; } = 0;
		public string name { get; set; } = " ";
		public string address { get; set; } = " ";
		public string oib { get; set; } = " ";
		public string contact { get; set; } = "";
		public string email { get; set; } = " ";
		public string zip { get; set; } = " ";
		public int returnDate { get; set; }
		public int fine { get; set; }
	}
}