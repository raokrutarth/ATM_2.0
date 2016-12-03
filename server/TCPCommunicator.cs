using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

namespace AtmServer {

	// State object for reading client data asynchronously
	public class StateObject {
		// Client  socket.
		public Socket workSocket = null;
		// Size of receive buffer.
		public const int BufferSize = 500000;
		// Receive buffer.
		public byte[] buffer = new byte[BufferSize];
		// Received data string.
		public StringBuilder sb = new StringBuilder();
		// Client data.
		public ClientData clientData = new ClientData();
	}

	//local class that holds command information
	public class Command {
		//client command
		public string command;
		//amount of data
		public int size;
		//data passed with the command
		public string data;

        public Command() {
            this.command = String.Empty;
            this.size = 0;
            this.data = String.Empty;
        }

        public Command(string c, string d) {
            this.command = c;
            this.data = d;
            this.size = c.Length + d.Length;
        }

        public Command(string c, int s, string d) {
            this.command = c;
            this.size = s;
            this.data = d;
        }
	}

    public class TCPCommunicator {
		//private ServerController controller = new ServerController();

		// Thread signal.
		public static ManualResetEvent allDone = new ManualResetEvent(false);

		//used for callback functions
		//private Dictionary<string, TCPDataCallback> callbacks;
		
		//holds the current command data
		public Command currentCommand;
		
		//socket used for client connection
		public Socket listener;		
		//constructor
		public TCPCommunicator() {
			//this.callbacks = new Dictionary<string, TCPDataCallback>();
			this.currentCommand = new Command();
			//ServerController.currentController.RegisterCallback("authenticatePIN", Send);
			//ServerController.currentController.RegisterCallback("Send", Send);
		}

        public void StartListening() {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];


			try
			{
				// Establish the local endpoint for the socket.
				// The DNS name of the computer
				// running the listener is "host.contoso.com".
				IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				int port = 11000;
				IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

				Console.WriteLine("TCP server is listening at {0} on port {1}.", ipAddress.ToString(), port);

				// Create a TCP/IP socket.
				this.listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


				// Bind the socket to the local endpoint and listen for incoming connections.
				listener.Bind(localEndPoint);
				listener.Listen(100);

				while (true)
				{

					// Set the event to nonsignaled state.
					allDone.Reset();

					// Start an asynchronous socket to listen for connections.
					Console.WriteLine("Waiting for a connection...");
					listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

					// Wait until a connection is made before continuing.
					allDone.WaitOne();
				}

			}
			catch (SocketException s) {
				try
				{
					this.listener.Shutdown(SocketShutdown.Both);
				}
				catch (Exception e)
				{
					
				}
				this.listener.Close();
				StartListening();

			} catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }

        public void AcceptCallback(IAsyncResult ar) {
            // Signal the main thread to continue.
            allDone.Set();
            Console.WriteLine("Setting up connection\n");
            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;
			this.listener = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        public void ReadCallback(IAsyncResult ar) {
            String content = String.Empty;
			//Console.WriteLine("Reading Data");




			try {

				// Retrieve the state object and the handler socket
				// from the asynchronous state object.
				StateObject state = (StateObject)ar.AsyncState;
				Socket handler = state.workSocket;

				// Read data from the client socket. 
				int bytesRead = handler.EndReceive(ar);

				

				if (bytesRead > 0) {
                    // There  might be more data, so store the data received so far.
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Check for end-of-file tag. If it is not there, read 
                    // more data.
                    content = state.sb.ToString();

                    if (this.currentCommand.size == 0 && content.Contains("\n")) {
                        string s = content.Substring(0, content.IndexOf('\n'));
						Console.WriteLine("s:\"{0}\"", s);
                        this.currentCommand.size = Int32.Parse(s);
						state.sb.Remove(0, s.Length + 1);
                    }

					Console.WriteLine("state.size: {0}\ncurrentCommand.size: {1}", state.sb.Length, (this.currentCommand.size));
                    if (state.sb.Length >= (this.currentCommand.size)) {
						// this.currentCommand.size.ToString().Length
						// All the data has been read from the client. Display it on the console.
						Console.WriteLine("Read {0} bytes from socket.", content.Length);
      
                        // Echo the data back to the client.
                        //Send(handler, content);


                        //call the message decoder method to determine the command given
                        this.decoder(state.clientData, state.sb.ToString(), this.currentCommand.size);
                        state.sb.Clear();
						this.currentCommand = new Command();

					}

                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
            } catch (System.IO.IOException e) {
                Console.WriteLine("IOException: {0}", e);
                //return null;
            } catch (SocketException e) {
                Console.WriteLine("SocketException: {0}", e);

				this.listener.Shutdown(SocketShutdown.Both);
				this.listener.Close();
				StartListening();
			}
        }

       /* public void Send(Socket handler, String data) {
			// Calculate packet size.
			int size = Encoding.ASCII.GetByteCount(data);
			Console.WriteLine("Sending {0} bytes of data.", size);

			// Prepend header to packet.
			data = "$Size: " + size.ToString() + "\n" + data;

			// Convert the string data to byte data using ASCII encoding.
			byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }*/

		public bool Send(Command c) {
			Socket handler = this.listener;
			String data;

			data = c.size.ToString();
			data = data + "\n" + c.command + "\n" + c.data;

			Console.WriteLine("Sending data: {0}", data);

			// Convert the string data to byte data using ASCII encoding.
			byte[] byteData = Encoding.ASCII.GetBytes(data);

			//handler.EndSend();
			handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
			return true;
		}

        private void SendCallback(IAsyncResult ar) {
            try {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                //handler.Shutdown(SocketShutdown.Both);
                //handler.Close();
				//handler.BeginReceive(ar.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

		//decodes information from client and stores it in currentCommand
		private void decoder(ClientData clientData, string data, int size) {
			int index = 0;

			//begin decoding

			this.currentCommand.command = data.Substring(0, data.IndexOf('\n'));
			this.currentCommand.size = size;

			index = this.currentCommand.command.Length + 1;

			Console.WriteLine("Reveived command: {0}", this.currentCommand.command);
			
			this.currentCommand.data = data.Substring(index, size - index + 1);
			Console.WriteLine("data length: {0}", this.currentCommand.data.Length);
            ServerController.currentController.executeCommand(clientData, this.currentCommand);
		}
		/*
		private void decoder(byte[] data, int size) {
			string[] temp;

			//begin decoding
			//temp = data.Split('\n');
			data.

			this.currentCommand.command = temp[1];
			this.currentCommand.size = size;
			this.currentCommand.data = temp[2];

			ServerController.currentController.executeCommand(this.currentCommand);
		}*/

    }
}
