using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LibWepApi.Models
{
	public class Employee : DatabaseConnection
	{

		public string name { get; set; }
		public string oib { get; set; }
		public string address { get; set; }
		public string contact { get; set; }
		public string salary { get; set; }
		public string note { get; set; }
		public string libraryID { get; set; }
		public int employeeID { get; set; }

		public DataTable dt = new DataTable();
		public DataSet ds = new DataSet();


		public void Create_data(Employee employee)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "INSERT INTO `employee`(`FullName`, `Oib`, `Address`, `Contact`, `Salary`, `Note`, `LibraryID`) VALUES (@name,@oib,@address,@contact,@salary,@note,@libraryID)";

				cmd.Connection = con;
				cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = employee.name;
				cmd.Parameters.Add("@oib", MySqlDbType.Double).Value = employee.oib;
				cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = employee.address;
				cmd.Parameters.Add("@contact", MySqlDbType.VarChar).Value = employee.contact;
				cmd.Parameters.Add("@salary", MySqlDbType.Int32).Value = employee.salary;
				cmd.Parameters.Add("@note", MySqlDbType.VarChar).Value = employee.note;
				cmd.Parameters.Add("@libraryID", MySqlDbType.Int32).Value = 1;

				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public void Update_data(int id, Employee employee)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "UPDATE `employee` SET `FullName`=@name,`Oib`= @oib,`Address`= @address,`Contact`= @contact,`Salary`= @salary,`Note`= @note WHERE EmployeeID = @employeeID";

				cmd.Connection = con;
				cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = employee.name;
				cmd.Parameters.Add("@oib", MySqlDbType.Double).Value = employee.oib;
				cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = employee.address;
				cmd.Parameters.Add("@contact", MySqlDbType.VarChar).Value = employee.contact;
				cmd.Parameters.Add("@salary", MySqlDbType.Int32).Value = employee.salary;
				cmd.Parameters.Add("@note", MySqlDbType.VarChar).Value = employee.note;
				cmd.Parameters.Add("@libraryID", MySqlDbType.Int32).Value = 1;

				cmd.Parameters.Add("@employeeID", MySqlDbType.Int32).Value = id;

				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public void Delete_data(int id)
		{
			con.Open();
			using (MySqlCommand cmd = new MySqlCommand())
			{
				cmd.CommandText = "DELETE FROM employee WHERE EmployeeID = @employeeID";
				cmd.Connection = con;

				cmd.Parameters.Add("@employeeID", MySqlDbType.Int32).Value = id;

				cmd.ExecuteNonQuery();
				con.Close();
			}

		}

		public DataSet Read_data()
		{
			string query = "SELECT * FROM `employee`";
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
			cmd.Parameters.Add("@employeeID", MySqlDbType.Int32).Value = id;
			cmd.ExecuteNonQuery();

			MySqlDataAdapter MDA = new MySqlDataAdapter();
			MDA.SelectCommand = cmd;
			MDA.Fill(ds);

			con.Close();
			return ds;
		}
	}
}