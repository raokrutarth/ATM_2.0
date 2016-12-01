using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ATM
{
	public class Message
	{
		public string type;
		public string data;
		public int size;
	}

	public class ServerConnection
	{
		private static int MAX_PACKET_SIZE = 4096;

		// The port number for the remote device.
		private int port;
		private string server;

		// The response from the remote device.
		private String response = String.Empty;

		// The client socket.
		private TcpClient client;
		private NetworkStream stream;

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
		public Message SendData(string dataType, string data, bool expectResponse=false)
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
		public Message SendData(string dataType, byte[] data, bool expectResponse = false)
		{
			int size = data.Length + dataType.Length;
			Console.WriteLine("Send data of size {0}", size);

			// Create header.
			string header = size.ToString() + "\n" + dataType + "\n";
			byte[] headerData = Encoding.ASCII.GetBytes(header);

			// Send the data.
			try
			{
				this.stream.Write(headerData, 0, headerData.Length);
				this.stream.Write(data, 0, data.Length);
			}
			catch (System.IO.IOException e)
			{
				Console.WriteLine("IOException: {0}", e);
			}
			catch (SocketException e)
			{
				Console.WriteLine("SocketException: {0}", e);
			}

			if (expectResponse)
			{
				return this.ReceiveData();
			}
			return null;
		}

		/*
		 * Establishes the connection to the server.
		 */
		public bool Connect()
		{
			try
			{
				this.client = new TcpClient(this.server, this.port);
				this.stream = this.client.GetStream();
				Console.WriteLine("Connected to {0}:{1}", this.server, this.port);
			}
			catch (ArgumentNullException e)
			{
				Console.WriteLine("ArgumentNullException: {0}", e);
				return false;
			}
			catch (SocketException e)
			{
				Console.WriteLine("SocketException: {0}", e);
				return false;
			}
			return true;
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
		 * \returns a Message class instance with the appropriate data.
		 */
		private Message ReceiveData()
		{
			try
			{
				// Read data.
				byte[] data = new Byte[MAX_PACKET_SIZE];
				string response = string.Empty;
				Int32 bytes = stream.Read(data, 0, data.Length);
				response = Encoding.ASCII.GetString(data, 0, bytes);
				//Console.WriteLine("Got response of length {1}:\n\"\"\"\n{0}\n\"\"\"\n", response, response.Length);

				// Create Message instance.
				Message result = new Message();
				string[] lines = response.Split("\n".ToCharArray(), 3);

				// Parse data.
				result.size = Int32.Parse(lines[0]);
				result.type = lines[1];
				result.data = lines[2];

				return result;
			}
			catch (System.IO.IOException e)
			{
				Console.WriteLine("IOException: {0}", e);
				return null;
			}
			catch (SocketException e)
			{
				//Console.WriteLine("SocketException: {0}", e);
				return null;
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