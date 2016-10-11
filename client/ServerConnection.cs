using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace ATM
{
    // This is a delegate for TCP callbacks.
    public delegate bool TCPDataCallback(string data);

	// State object for receiving data from remote device.
	class TCPStateObject
    {
		public Socket workSocket = null;
		public const int BUFFER_SIZE = 256;
		public byte[] buffer = new byte[BUFFER_SIZE];
		public StringBuilder sb = new StringBuilder();
	}

	public class ServerConnection
    {
		// The port number for the remote device.
		private int port;
        private string hostName;
        private Dictionary<string, TCPDataCallback> callbacks;

		// ManualResetEvent instances signal completion.
		private static ManualResetEvent connectDone = new ManualResetEvent(false);
		private static ManualResetEvent sendDone = new ManualResetEvent(false);
		private static ManualResetEvent receiveDone = new ManualResetEvent(false);

		// The response from the remote device.
		private String response = String.Empty;

        /*
         * \brief Sends data to the server.
         * \param dataType The data type descriptor.
         * \param data The data itself.
         * Returns false for failure, true for success.
         */
        public bool sendData(string dataType, string data)
        {
            return false;
        }

        /*
         * Registers a receive data callback function.
         */
        public bool registerCallback(string dataType, TCPDataCallback callback)
        {
            this.callbacks[dataType] = callback;
            return true;
        }

        public ServerConnection(string host, int port)
        {
            this.hostName = host;
            this.port = port;
            this.callbacks = new Dictionary<string, TCPDataCallback>();
        }

        private void connect()
        {
			// Connect to a remote device.
			try
            {
                Console.WriteLine("connection start");
				IPHostEntry ipHostInfo = Dns.GetHostEntry(hostName);
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
                Console.WriteLine("Got IP addr: {0}", ipHostInfo.AddressList[0].ToString());

				// Create a TCP/IP socket.
				Socket client = new Socket(AddressFamily.InterNetwork,
					SocketType.Stream, ProtocolType.Tcp);

                Console.WriteLine("creating socket");
				// Connect to the remote endpoint.
				client.BeginConnect( remoteEP, 
					new AsyncCallback(ConnectCallback), client);
				connectDone.WaitOne();

                Console.WriteLine("sending data");
				// Send test data to the remote device.
				Send(client,"This is a test<EOF>");
				sendDone.WaitOne();

                Console.WriteLine("receiving data");
				// Receive the response from the remote device.
				Receive(client);
				receiveDone.WaitOne();

				// Write the response to the console.
				Console.WriteLine("Response received : {0}", response);

				// Release the socket.
				client.Shutdown(SocketShutdown.Both);
				client.Close();

			} catch (Exception e) {
				Console.WriteLine(e.ToString());
			}
		}

		private void ConnectCallback(IAsyncResult ar) {
			try {
				// Retrieve the socket from the state object.
				Socket client = (Socket) ar.AsyncState;

				// Complete the connection.
				client.EndConnect(ar);

				Console.WriteLine("Socket connected to {0}",
					client.RemoteEndPoint.ToString());

				// Signal that the connection has been made.
				connectDone.Set();
			} catch (Exception e) {
				Console.WriteLine(e.ToString());
			}
		}

		private void Receive(Socket client) {
			try {
				// Create the state object.
				TCPStateObject state = new TCPStateObject();
				state.workSocket = client;

				// Begin receiving the data from the remote device.
				client.BeginReceive( state.buffer, 0, TCPStateObject.BUFFER_SIZE, 0,
					new AsyncCallback(ReceiveCallback), state);
			} catch (Exception e) {
				Console.WriteLine(e.ToString());
			}
		}

		private void ReceiveCallback( IAsyncResult ar ) {
			try {
				// Retrieve the state object and the client socket 
				// from the asynchronous state object.
				TCPStateObject state = (TCPStateObject) ar.AsyncState;
				Socket client = state.workSocket;

				// Read data from the remote device.
				int bytesRead = client.EndReceive(ar);

				if (bytesRead > 0) {
					// There might be more data, so store the data received so far.
				state.sb.Append(Encoding.ASCII.GetString(state.buffer,0,bytesRead));

					// Get the rest of the data.
					client.BeginReceive(state.buffer,0,TCPStateObject.BUFFER_SIZE,0,
						new AsyncCallback(ReceiveCallback), state);
				} else {
					// All the data has arrived; put it in response.
					if (state.sb.Length > 1) {
						response = state.sb.ToString();

                        Console.WriteLine("RECEIVED DATA FROM SERVER:\n{0}\n", response);
                        /*int idx = response.IndexOf("\r\n");
                        string type = response.Substring(0, idx);
                        string data = response.Substring(idx, response.Length);

                        // Call our callback here.
                        bool success = this.callbacks[type](data);*/
                    }
					// Signal that all bytes have been received.
					receiveDone.Set();
				}
			} catch (Exception e) {
				Console.WriteLine(e.ToString());
			}
		}

		private void Send(Socket client, String data) {
			// Convert the string data to byte data using ASCII encoding.
			byte[] byteData = Encoding.ASCII.GetBytes(data);

			// Begin sending the data to the remote device.
			client.BeginSend(byteData, 0, byteData.Length, 0,
				new AsyncCallback(SendCallback), client);
		}

		private void SendCallback(IAsyncResult ar) {
			try {
				// Retrieve the socket from the state object.
				Socket client = (Socket) ar.AsyncState;

				// Complete sending the data to the remote device.
				int bytesSent = client.EndSend(ar);
				Console.WriteLine("Sent {0} bytes to server.", bytesSent);

				// Signal that all bytes have been sent.
				sendDone.Set();
			} catch (Exception e) {
				Console.WriteLine(e.ToString());
			}
		}

        public static int Main(String[] args)
        {
            Console.WriteLine("Connecting...");
            ServerConnection connection = new ServerConnection("128.210.106.57", 1100);
            connection.connect();
            return 0;
        }
    }
}