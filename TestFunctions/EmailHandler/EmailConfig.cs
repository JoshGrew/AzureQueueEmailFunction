using System;
using System.Collections.Generic;
using System.Text;

namespace TestFunctions.EmailHandler
{
	/// <summary>
	/// Model for creating a new smtp server connection
	/// </summary>
	public class EmailConfig
	{
		public string Host { get; set; }
		public int Port { get; set; }
		public string Sender { get; set; }
		public string Password { get; set; }
	}
}
