using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LibWepApi.Models
{
	public class Genre : DatabaseConnection
	{

		public string name { get; set; }
		public string genreID { get; set; }

		public DataTable dt = new DataTable();
		public DataSet ds = new DataSet();

		public void Create_data(Genre genre)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "INSERT INTO `genre`(`Genre`) VALUES (@name)";

				cmd.Connection = con;
				cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = genre.name;

				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public void Update_data(int id, Genre genre)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "UPDATE `genre` SET `Genre`= @name WHERE GenreID = @genreID";

				cmd.Connection = con;
				cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = genre.name;

				cmd.Parameters.Add("@genreID", MySqlDbType.Int32).Value = id;

				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public void Delete_data(int id)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "DELETE FROM genre WHERE GenreID = @genreID";
				cmd.Connection = con;

				cmd.Parameters.Add("@genreID", MySqlDbType.Int32).Value = id;

				cmd.ExecuteNonQuery();
				con.Close();
			}

		}

		public DataSet Read_data()
		{
			dt.Clear();
			string query = "SELECT * FROM `genre` ";
			MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);

			MDA.Fill(ds);
			return ds;
		}
		public DataSet Read_data(int id)
		{
			con.Open();

			dt.Clear();
			MySqlCommand cmd = new MySqlCommand();

			cmd.CommandText = "SELECT* FROM `genre` WHERE GenreID = @genreID";
			cmd.Connection = con;
			cmd.Parameters.Add("@genreID", MySqlDbType.Int32).Value = id;
			cmd.ExecuteNonQuery();

			MySqlDataAdapter MDA = new MySqlDataAdapter();
			MDA.SelectCommand = cmd;
			MDA.Fill(ds);

			con.Close();
			return ds;
		}

	}

}
