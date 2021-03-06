using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LibWepApi.Models
{
	public class Member : DatabaseConnection
	{
		public string name { get; set; }
		public string oib { get; set; }
		public string address { get; set; }
		public string contact { get; set; }
		public string email { get; set; }
		public DateTime enrollment { get; set; }
		public int libraryID { get; set; }
		public int memberID { get; set; }

		public DataTable dt = new DataTable();
		public DataSet ds = new DataSet();


		public void Create_data(Member member)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "INSERT INTO `member`(`FullName`, `Oib`, `Address`, `Contact`, `Email`, `EnrollmentDate`, `LibraryID`) VALUES (@name,@oib,@address,@contact,@email,@enrollment,@libraryID)";

				cmd.Connection = con;
				cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = member.name;
				cmd.Parameters.Add("@oib", MySqlDbType.Double).Value = member.oib;
				cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = member.address;
				cmd.Parameters.Add("@contact", MySqlDbType.VarChar).Value = member.contact;
				cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = member.email;
				cmd.Parameters.Add("@enrollment", MySqlDbType.Date).Value = member.enrollment;
				cmd.Parameters.Add("@libraryID", MySqlDbType.Int32).Value = 1;

				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public void Update_data(int id, Member member)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "UPDATE member SET FullName = @name, Oib = @oib, Address = @address, Contact = @contact, Email = @email, EnrollmentDate = @enrollment WHERE MemberID = @memberID";

				cmd.Connection = con;
				cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = member.name;
				cmd.Parameters.Add("@oib", MySqlDbType.Double).Value = member.oib;
				cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = member.address;
				cmd.Parameters.Add("@contact", MySqlDbType.VarChar).Value = member.contact;
				cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = member.email;
				cmd.Parameters.Add("@enrollment", MySqlDbType.VarChar).Value = member.enrollment;
				cmd.Parameters.Add("@libraryID", MySqlDbType.Int32).Value = 1;

				cmd.Parameters.Add("@memberID", MySqlDbType.Int32).Value = id;

				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public void Delete_data(int id)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "DELETE FROM member WHERE MemberID = @memberID";
				cmd.Connection = con;

				cmd.Parameters.Add("@memberID", MySqlDbType.Int32).Value = id;

				cmd.ExecuteNonQuery();
				con.Close();
			}

		}

		public DataSet Read_data()
		{
			string query = "SELECT * FROM `member` ";
			MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
			MDA.Fill(ds);
			return ds;
		}

		public DataSet Read_data(int id)
		{
			con.Open();

			dt.Clear();
			MySqlCommand cmd = new MySqlCommand();

			cmd.CommandText = "SELECT * FROM `member` WHERE MemberID = @memberID";
			cmd.Connection = con;
			cmd.Parameters.Add("@memberID", MySqlDbType.Int32).Value = id;
			cmd.ExecuteNonQuery();

			MySqlDataAdapter MDA = new MySqlDataAdapter();
			MDA.SelectCommand = cmd;
			MDA.Fill(ds);

			con.Close();
			return ds;
		}
	}
}


