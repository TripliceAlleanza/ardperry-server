using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ardperry_server.Classes;


namespace ardperry_server.Classes {
	class TcpComunication {



		public void BeginComunication () {


			


			byte[] buffer = new byte[1024];                     
			int intNumBytesRec = 0;                          
			string strData = null;

			Socket sckListener = new Socket(AddressFamily.InterNetwork,
											 SocketType.Stream,
											 ProtocolType.Tcp);

			sckListener.Bind(new IPEndPoint(IPAddress.Any, 65432));

			Console.WriteLine("********************************************");
			Console.WriteLine("         Simple TCP Server V 1.0          \n");
			Console.WriteLine("Showing everything received from  client ...");
			Console.WriteLine("********************************************\n");

			Console.WriteLine("STCPS running ...                           ");
			sckListener.Listen(2);  

			Socket sckWorker = sckListener.Accept();
			Console.WriteLine("Client connected; waiting to receive data ...");

			sckWorker.Shutdown(SocketShutdown.Send);                     


			while (strData != "quit") {
				intNumBytesRec = sckWorker.Receive(buffer);

				strData = Encoding.UTF8.GetString(buffer, 0, intNumBytesRec);

				var valori = strData.Split('#');
				
				Console.WriteLine("IdDispositivo: {0}       Valore : {1}", valori[0], valori[1]);

				var data_ora = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");


				DbManager dbManager = new DbManager($"insert into Rilevazioni(IdDispositivo, DataRilevazione, Valore) values ('{valori[0]}','{data_ora}','{valori[1]}')");
				dbManager.PublishToDatabase();
			}

			
			sckListener.Close();
			sckWorker.Close();

			Console.WriteLine("STCPS quitting!!!\n");

		}




	}
}
