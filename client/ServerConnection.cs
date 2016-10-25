using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ATM
{
	public class ServerConnection
	{
		private static int MAX_PACKET_SIZE = 4096;

		// The port number for the remote device.
		private int port;
		private string server;

		// The response from the remote device.
		private String response = String.Empty;

		// The client socket.
		TcpClient client;
		NetworkStream stream;

		/*
		 * Creates a new ServerConnection object. This connection will remain
		 * until the object is destroyed.
		 * \param host The hostname or IP address of the server.
		 * \param port The port that the server is listening on.
		 */
		public ServerConnection(string server, int port)
		{
			this.server = server;
			this.port = port;
		}

		/*
		 * Destroys the TCP connection.
		 */
		~ServerConnection()
		{
			this.Close();
		}

		/*
		 * \brief Sends text data to the server.
		 * \param dataType The data type descriptor.
		 * \param data The data itself.
		 * \param expectResponse Whether to wait for a response.
		 * \returns The response received or emtpy string if response not expected.
		 */
		public string SendData(string dataType, string data, bool expectResponse=false)
		{
			byte[] byteData = Encoding.ASCII.GetBytes(data);
			return this.SendData(dataType, byteData, expectResponse);
		}

		/*
		 * Sends binary data to the server.
		 * \param dataType The data type descriptor.
		 * \param data The data itself.
		 * \param expectResponse Whether to wait for a response.
		 * \returns The response received or emtpy string if response not expected.
		 */
		private string SendData(string dataType, byte[] data, bool expectResponse = false)
		{
			int size = data.Length;
			Console.WriteLine("Sending with payload size of {0} bytes.", size);

			// Create header.
			string header = size.ToString() + "\n" + dataType + "\n";
			byte[] headerData = Encoding.ASCII.GetBytes(header);

			// Send the data.
			this.stream.Write(headerData, 0, headerData.Length);
			this.stream.Write(data, 0, data.Length);

			if(expectResponse)
			{
				return this.ReceiveData();
			}
			return String.Empty;
		}

		/*
		 * Establishes the connection to the server.
		 */
		public void Connect()
		{
			try
			{
				TcpClient client = new TcpClient(this.server, this.port);
				Console.WriteLine("Connected to {0}:{1}", this.server, this.port);
			}
			catch (ArgumentNullException e)
			{
				Console.WriteLine("ArgumentNullException: {0}", e);
			}
			catch (SocketException e)
			{
				Console.WriteLine("SocketException: {0}", e);
			}
		}

		/*
		 * Releases the connection to the server.
		 * This is performed before object deletion.
		 */
		public void Close()
		{
			try
			{
				// Release the socket.
				stream.Close();
				client.Close();
			}
			catch (SocketException e)
			{
				Console.WriteLine("SocketException: {0}", e);
			}
		}

		/*
		 * Receives data from the server.
		 */
		private string ReceiveData()
		{
			try
			{
				Console.WriteLine("Receiving data");
				byte[] data = new Byte[MAX_PACKET_SIZE];
				string response = string.Empty;
				Int32 bytes = stream.Read(data, 0, data.Length);
				response = Encoding.ASCII.GetString(data, 0, bytes);
				Console.WriteLine("Received response:\n{0}", response);
				return response;
			}
			catch (SocketException e)
			{
				Console.WriteLine("SocketException: {0}", e);
				return string.Empty;
			}
		}

		/*private void ReceiveCallback( IAsyncResult ar )
		{
			try
			{
				// Retrieve the state object and the client socket 
				// from the asynchronous state object.
				TCPStateObject state = (TCPStateObject) ar.AsyncState;
				Socket client = state.workSocket;

				// Read data from the remote device.
				int bytesRead = client.EndReceive(ar);

				if (bytesRead > 0 && (state.dataLength == 0 || bytesRead >= state.dataLength))
				{
					// There might be more data, so store the data received so far.
					string ascii = Encoding.ASCII.GetString(state.buffer, 0, bytesRead);
					state.sb.Append(ascii);

					Console.WriteLine("Have received {0} bytes:\n{1}", bytesRead, ascii);

					// Check if data length is specified.
					if (state.dataLength == 0 && ascii.IndexOf('\n') >= 0)
					{
						string[] lines = ascii.Split('\n');
						state.dataLength = Int32.Parse(lines[0]);
						Console.WriteLine("Got data length of {0}", state.dataLength);
					}

					// Get the rest of the data.
					client.BeginReceive(state.buffer,0,TCPStateObject.BUFFER_SIZE,0,
						new AsyncCallback(ReceiveCallback), state);
				}
				else
				{
					Console.WriteLine("sb length: {0}", state.sb.Length);
					// All the data has arrived; put it in response.
					if (state.sb.Length > 1)
					{
						response = state.sb.ToString();

						Console.WriteLine("RECEIVED DATA FROM SERVER:\n{0}\n", response);

						// Parse out data here.
						int idx = response.IndexOf("\n");
						if (idx >= 0)
						{
							string type = response.Substring(0, idx);
							string data = response.Substring(idx, response.Length - 1);

							// Call our callback here.
							if (this.callbacks.ContainsKey(type))
							{
								bool success = this.callbacks[type](data);
							}
							else
							{
								Console.WriteLine("ERROR: Invalid message name received.");
							}
						}
						else
							Console.WriteLine("bad");

						// Reset the data length for the next packet.
						state.dataLength = 0;
					}

					// Clear the buffer.
					state.sb.Clear();

					// Signal that all bytes have been received.
					//receiveDone.Set();
				}
			} catch (Exception e) {
				Console.WriteLine(e.ToString());
			}
		}*/
	}
}