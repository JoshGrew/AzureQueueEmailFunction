using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using PopulateQueue.Model;
using PopulateQueue.QueueConnection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PopulateQueue.QueueConnection
{
	public class QueueEmailMessages
	{
		public const string _emailQueue = "email-queue";

		public const string _connectionString = "UseDevelopmentStorage=true";

		/// <summary>
		/// Creates a connection to the Azure Storage queue and populates
		/// it with messages serialized into Json.
		/// </summary>
		public async Task SendMessages()
		{
			// Retrieve the queue reference and create if it does not exist
			var queueReference = new CloudQueueClientBuilder(_connectionString)
					.GetClient()
					.GetQueueReference(_emailQueue);

			await queueReference.CreateIfNotExistsAsync();

			// Create the Email using the message model
			var message = new Message()
			{
				Recipient = "josh_grew@hotmail.com",
				Subject = "Subject Line",
				Body = "Body Line"
			};

			// Serialize into Json
			var serializedMessage = JsonConvert.SerializeObject(message);
			// Create a new Queue Message object
			var queueMessage = new CloudQueueMessage(serializedMessage);
			// Add the Message to the queue
			await queueReference.AddMessageAsync(queueMessage);
		}
	}
}
