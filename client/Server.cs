using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;


namespace ATM {

	//class for the server
	public class Server {
		private TcpListener listener;   //object for listening for a client
		private TcpClient client;
		private NetworkStream stream;

		public Server() {
			this.listener = new TcpListener(IPAddress.Any, 1200);
			this.listener.Start();
		}

		//finds a new client for the server
		public bool wait() {
			this.client = this.listener.AcceptTcpClient();
			this.stream = this.client.GetStream();

			if (this.client == null) {
				return false; //error client not connected
			} else {
				return true; //client connected successfully
			}
		}

		//reads data sent by the client
		public void recieveData() {
			byte[] buffer = new byte[this.client.ReceiveBufferSize];
			int data;
			string message;

			data = stream.Read(buffer, 0, this.client.ReceiveBufferSize);
			message = Encoding.Unicode.GetString(buffer, 0, data);

			/*for testing purposes*/
			Console.WriteLine("Message recieved" + message);
		}

		public static void main() {
			Server s = new Server();
			bool check = false;

			while(true) {
				check = s.wait();
				if (check) {

				}
			}
		}
	}
}
