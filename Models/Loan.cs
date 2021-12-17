using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibWepApi.Models
{
	public class Loan
	{
		public int loanId { get; set; } = 0;
		public int memberId { get; set; } = 0;
		public int bookId { get; set; } = 0;
		public int employeeId { get; set; } = 0;
		public string loanDate { get; set; } = " ";
		public string returnDate { get; set; } = " ";
	}
}

