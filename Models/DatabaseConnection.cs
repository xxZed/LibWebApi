using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibWepApi.Models
{
	public class DatabaseConnection
	{
		public MySqlConnection con;
		public DatabaseConnection()
		{
			string host = "localhost";
			string db = "library";
			string port = "3306";
			string user = "root";
			string pass = "";
			string constring = "datasource = " + host + "; database = " + db + "; port = " + port + "; username = " + user + "; password = " + pass + "; SslMode=none";
			con = new MySqlConnection(constring);
		}
	}
}