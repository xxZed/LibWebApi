using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibWepApi.Models
{
	public class Book
	{
		public int bookId { get; set; } = 0;
		public string author { get; set; } = " ";
		public string publishDate { get; set; } = " ";
		public int stock { get; set; }

		public int bookGenreId { get; set; }
		public int bookLibId { get; set; }

		public string bookName { get; set; } = " ";
	}
}

