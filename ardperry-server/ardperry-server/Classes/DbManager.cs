using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ardperry_server.Classes {
	class DbManager {

		private string command_query;
		private SqlConnection connection;

		public DbManager(string command_query) {
			connection = new SqlConnection("Data Source=C215-026;Initial Catalog=Rilevazioni;Integrated Security=True");
			try {
				connection.Open();
			} catch {
				Console.WriteLine("Errore timeout server");
			} finally {
				
			}
			this.command_query = command_query;
		}

		public string Command_query { get => command_query; set => command_query = value; }

		public void PublishToDatabase() {

			using (SqlCommand sqlCommand = new SqlCommand(command_query, connection) { CommandType = CommandType.Text }) {
				sqlCommand.ExecuteNonQuery();
			}



		}
	}


}






