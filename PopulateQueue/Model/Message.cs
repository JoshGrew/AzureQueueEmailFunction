using System;
using System.Collections.Generic;
using System.Text;

namespace PopulateQueue.Model
{
	/// <summary>
	/// The Model for storing the chosen details
	/// to be added to Azure Email queue
	/// </summary>
	public class Message
	{
		public string Recipient { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
	}
}
