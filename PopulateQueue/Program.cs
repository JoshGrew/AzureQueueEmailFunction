using PopulateQueue.QueueConnection;
using System;
using System.Threading.Tasks;

namespace PopulateQueue
{
	class Program
	{
		static void Main(string[] args)
		{
			MainAsync().Wait();
		}

		static async Task MainAsync()
		{
			var newQueue = new QueueEmailMessages();
			await newQueue.SendMessages();
		}
	}
}
