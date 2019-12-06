using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PopulateQueue.Model;

namespace TestFunctions.EmailHandler
{
	/// <summary>
	/// Azure Queue function used to send Emails from the email queue 
	/// to the Email specified, including a subject and body
	/// </summary>
	/// <param name="message"> The message stored </param>
	/// <param name="logger"> Logger for checking any issues </param>
	public static class EmailQueueTrigger
    {
        [FunctionName("EmailQueueTrigger")]
        public static async Task Run(
			[QueueTrigger("email-queue", Connection = "AzureWebJobsStorage")]
			string message
			,ILogger logger)
        {
			try 
			{
				var emailConfig = new EmailConfig()
				{
					Host = "smtp.gmail.com",
					Port = 587,
					Sender = "",
					Password = ""
				};

				// Deserialize the Json message into the Message model.
				var deserializedMessage = JsonConvert.DeserializeObject<Message>(message);
				// Create a new instance of the email handler
				var emailHandler = new EmailHandler(emailConfig);
				// Send the queued emails
				await emailHandler.SendEmail(deserializedMessage);
			}
			catch(Exception ex)
			{
				logger.LogError(ex, "Something bad happened");
				throw;
			}
        }
    }
}
