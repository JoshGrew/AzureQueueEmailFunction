using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopulateQueue.QueueConnection
{
	public class CloudQueueClientBuilder
	{
		private string _cloudConnectionString { get; }

		public CloudQueueClientBuilder(string cloudConnectionString)
		{
			_cloudConnectionString = cloudConnectionString;
		}

		/// <summary>
		/// Create a new connection to the dev Storage account
		/// and create a Queue client.
		/// </summary>
		public CloudQueueClient GetClient()
		{
			// Create a connection to the Cloud Storage account using 
			// settings supplied
			var storageAccount = CloudStorageAccount.Parse(_cloudConnectionString);
			// Return a new instance of Cloud Queue Client
			return storageAccount.CreateCloudQueueClient();

		}
	}
}
