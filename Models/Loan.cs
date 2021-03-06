using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;

namespace LibWepApi.Models
{
	public class Loan : DatabaseConnection
	{
		public int memberID { get; set; }
		public int bookID { get; set; }
		public int employeeID { get; set; }
		public DateTime loanDate { get; set; }
		public DateTime returnDate { get; set; }
		public double pay { get; set; }
		public int loanID { get; set; }

		public DataTable dt = new DataTable();
		public DataSet ds = new DataSet();

		public void Create_data(Loan loan)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "INSERT INTO `loan`(`MemberID`, `BookID`, `EmployeeID`, `LoanDate`, `ReturnDate`) VALUES (@memberID,@bookID,@employeeID,@loanDate,@returnDate)";

				cmd.Connection = con;
				cmd.Parameters.Add("@memberID", MySqlDbType.Int32).Value = loan.memberID;
				cmd.Parameters.Add("@bookID", MySqlDbType.Int32).Value = loan.bookID;
				cmd.Parameters.Add("@employeeID", MySqlDbType.Int32).Value = loan.employeeID;
				cmd.Parameters.Add("@loanDate", MySqlDbType.Date).Value = loan.loanDate.Date;
				cmd.Parameters.Add("@returnDate", MySqlDbType.Date).Value = loan.returnDate.Date;

				cmd.ExecuteNonQuery();

				string CommandText = "UPDATE `book` SET book.Stock = (book.Stock - 1) WHERE book.BookID = @bookID";
				MySqlCommand myCommand = new MySqlCommand(CommandText, con);
				myCommand.Parameters.Add("@bookID", MySqlDbType.Int32).Value = loan.bookID;
				myCommand.ExecuteNonQuery();
				con.Close();

				TimeSpan ts = loan.returnDate.Date - loan.loanDate.Date;

				if (ts.Days > 30)
				{
					con.Open();

					pay = (ts.Days - loan.returnDate.Day) * 2;
					cmd.CommandText = "UPDATE `loan` SET Pay = @pay";
					cmd.Parameters.Add("@pay", MySqlDbType.Double).Value = pay;
					cmd.ExecuteNonQuery();
					con.Close();
				}
			}

		}
		public void Update_data(int id, Loan loan)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "UPDATE `loan` SET `MemberID`= @memberID,`BookID`= @bookID,`EmployeeID`= @employeeID,`LoanDate`= @loanDate,`ReturnDate`= @returnDate WHERE LoanID = @loanID";

				cmd.Connection = con;
				cmd.Parameters.Add("@memberID", MySqlDbType.Int32).Value = loan.memberID;
				cmd.Parameters.Add("@bookID", MySqlDbType.Int32).Value = loan.bookID;
				cmd.Parameters.Add("@employeeID", MySqlDbType.Int32).Value = loan.employeeID;
				cmd.Parameters.Add("@loanDate", MySqlDbType.Date).Value = loan.loanDate;
				cmd.Parameters.Add("@returnDate", MySqlDbType.Date).Value = loan.returnDate;

				cmd.Parameters.Add("@loanID", MySqlDbType.Int32).Value = id;

				cmd.ExecuteNonQuery();
				con.Close();

				TimeSpan ts = loan.returnDate.Date - loan.loanDate.Date;

				if (ts.Days > 30)
				{
					con.Open();

					pay = (ts.Days - loan.returnDate.Day) * 2;
					cmd.CommandText = "UPDATE `loan` SET Pay = @pay";
					cmd.Parameters.Add("@pay", MySqlDbType.Double).Value = pay;
					cmd.ExecuteNonQuery();
					con.Close();
				}
			}
		}

		public void Delete_data(int id)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "DELETE FROM loan WHERE LoanID = @loanID";
				cmd.Connection = con;

				cmd.Parameters.Add("@loanID", MySqlDbType.Int32).Value = id;

				cmd.ExecuteNonQuery();

				string CommandText = "UPDATE `book` INNER JOIN loan SET book.Stock = (book.Stock + 1) WHERE book.BookID = loan.BookID";
				MySqlCommand myCommand = new MySqlCommand(CommandText, con);
				myCommand.ExecuteNonQuery();
				con.Close();
			}

		}

		
		public DataTable Read_data()
		{
			dt.Clear();
			string query = "SELECT * FROM loan ";
			MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
			MDA.Fill(ds);
			DataTable data = ds.Tables[0];
			con.Close();
			return data;
		}

		public DataTable Read_data(int id)
		{
			con.Open();

			dt.Clear();
			MySqlCommand cmd = new MySqlCommand();

			cmd.CommandText = "SELECT * FROM `loan` WHERE LoanID = @loanID";
			cmd.Connection = con;
			cmd.Parameters.Add("@loanID", MySqlDbType.Int32).Value = id;
			cmd.ExecuteNonQuery();

			MySqlDataAdapter MDA = new MySqlDataAdapter();
			MDA.SelectCommand = cmd;
			MDA.Fill(ds);

			DataTable data = ds.Tables[0];
			con.Close();
			return data;
		}
		public DataTable Read_Book()
		{
			con.Open();
			dt.Clear();
			string query = "SELECT * FROM `book`";
			MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
			MDA.Fill(ds);
			DataTable data = ds.Tables[0];
			con.Close();
			return data;
		}
		public DataTable Read_Member()
		{
			con.Open();
			dt.Clear();
			string query = "SELECT * FROM `member`";
			MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
			MDA.Fill(ds);
			DataTable data = ds.Tables[0];
			con.Close();
			return data;
		}
		public DataTable Read_Employee()
		{
			con.Open();
			dt.Clear();
			string query = "SELECT * FROM `employee`";
			MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
			MDA.Fill(ds);
			DataTable data = ds.Tables[0];
			con.Close();
			return data;
		}
	}
}

