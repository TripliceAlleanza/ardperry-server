using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ardperry_server.Classes;

namespace ardperry_server {
	class Program {
		static void Main(string[] args) {


			TcpComunication tcpComunication = new TcpComunication();
			tcpComunication.BeginComunication();



			Console.ReadKey();

		}
	}
}
