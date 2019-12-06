using PopulateQueue.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TestFunctions.EmailHandler
{
	/// <summary>
	/// Responsible for creating a new SMTP client and sending
	/// the messages stored within the queue to the appropriate 
	/// recipients
	/// </summary>
	public class EmailHandler
	{
		private readonly EmailConfig _emailConfig;
		
		public EmailHandler(EmailConfig emailConfig)
		{
			_emailConfig = emailConfig;
		}

		/// <summary>
		/// Responsible for creating a new SMTP client and sending
		/// the messages stored within the queue to the appropriate 
		/// recipients
		/// </summary>
		/// <param name="messageContent"> The queued Message in Azure</param>
		public async Task SendEmail(Message messageContent)
		{
			// Create a new mail client
			using (var emailClient = new SmtpClient(_emailConfig.Host, _emailConfig.Port))
			{
				emailClient.Credentials = new NetworkCredential(_emailConfig.Sender, _emailConfig.Password);
				emailClient.EnableSsl = true;
				emailClient.UseDefaultCredentials = false;

				// Create a new Message to send from the client
				using (var message = new MailMessage(_emailConfig.Sender
						, messageContent.Recipient
						, messageContent.Subject
						, messageContent.Body))
				{
					await emailClient.SendMailAsync(message);
				}
			}
		}
	}
}
