using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmServer
{
	public class ClientData
	{
		// Current authentication status.
		public int accountNumber { get; set; }
		public bool authPIN { get; set; }
		public bool authFace { get; set; }
		public bool authFinger { get; set; }
		public bool authenticated { get; set; }

		/*
		 * Creates a new ClientData object.
		 */
		public ClientData()
		{
			this.accountNumber = 0;
			this.authPIN = false;
			this.authFace = false;
			this.authFinger = false;
			this.authenticated = false;
		}
	}
}
