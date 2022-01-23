using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LibWepApi.Models
{
	public class Book : DatabaseConnection
	{
		public string author { get; set; }
		public string bookname { get; set; }
		public string publishdate { get; set; }
		public int stock { get; set; }
		public int genreID { get; set; }
		public string libraryID { get; set; }
		public int bookID { get; set; }

		public DataTable dt = new DataTable();
		public DataSet ds = new DataSet();

		public void Create_data(Book book)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "INSERT INTO `book`( `Author`, `BookName`, `PublishDate`, `Stock`, `GenreID`, `LibraryID`) VALUES (@author,@bookname,@publishdate,@stock,@genreID,@libraryID)";
				cmd.Connection = con;
				cmd.Parameters.Add("@author", MySqlDbType.VarChar).Value = book.author;
				cmd.Parameters.Add("@bookname", MySqlDbType.VarChar).Value = book.bookname;
				cmd.Parameters.Add("@publishdate", MySqlDbType.VarChar).Value = book.publishdate;
				cmd.Parameters.Add("@stock", MySqlDbType.Int32).Value = book.stock;
				cmd.Parameters.Add("@genreID", MySqlDbType.Int32).Value = book.genreID;
				cmd.Parameters.Add("@libraryID", MySqlDbType.Int32).Value = 1;
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public void Update_data(int id, Book book)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "UPDATE `book` SET `Author`= @author,`BookName`= @bookname,`PublishDate`= @publishdate,`Stock`= @stock,`GenreID`= @genreID  WHERE BookID = @bookID";

				cmd.Connection = con;
				cmd.Parameters.Add("@author", MySqlDbType.VarChar).Value = book.author;
				cmd.Parameters.Add("@bookname", MySqlDbType.VarChar).Value = book.bookname;
				cmd.Parameters.Add("@publishdate", MySqlDbType.VarChar).Value = book.publishdate;
				cmd.Parameters.Add("@stock", MySqlDbType.Int32).Value = book.stock;
				cmd.Parameters.Add("@genreID", MySqlDbType.Int32).Value = book.genreID;
				cmd.Parameters.Add("@libraryID", MySqlDbType.Int32).Value = 1;

				cmd.Parameters.Add("@bookID", MySqlDbType.Int32).Value = id;

				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public void Delete_data(int id)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "DELETE FROM book WHERE BookID = @bookID";
				cmd.Connection = con;

				cmd.Parameters.Add("@bookID", MySqlDbType.Int32).Value = id;

				cmd.ExecuteNonQuery();
				con.Close();
			}

		}

		public DataSet Read_data()
		{
			dt.Clear();
			string query = "SELECT * FROM `book` ";
			MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);

			MDA.Fill(ds);
			return ds;
		}
		public DataSet Read_data(int id)
		{
			con.Open();

			dt.Clear();
			MySqlCommand cmd = new MySqlCommand();

			cmd.CommandText = "SELECT * FROM `book` WHERE BookID = @bookID";
			cmd.Connection = con;			
			cmd.Parameters.Add("@bookID", MySqlDbType.Int32).Value = id;			
			cmd.ExecuteNonQuery();

			MySqlDataAdapter MDA = new MySqlDataAdapter();
			MDA.SelectCommand = cmd;
			MDA.Fill(ds);

			con.Close();
			return ds;
		}

	}
}


