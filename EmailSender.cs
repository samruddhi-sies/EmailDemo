using System.Net;
using System.Net.Mail;

namespace EmailDemo
{
	public class EmailSender : IEmailSender
	{
		public async Task SendMyEmailAsync(string email)
		{
			string trackingUrl = "https://emaildemo20240521164515.azurewebsites.net/api/Home/track/" + email;
			string trackingPixel = $"<img src={trackingUrl} alt='tracking pixel' />";

			var mailMessage = new MailMessage()
			{
				From = new MailAddress("vivacious.queen@gmail.com"),
				Subject = "Email Tracker",
				Body = $"<h1 style=color:red>Welcome to Email Tracking</h1><p>{trackingPixel}</p>",
				IsBodyHtml = true
			};
			mailMessage.To.Add(email);

			var client = new SmtpClient("smtp.gmail.com")
			{
				Port=587,
				EnableSsl = true,
				Credentials = new NetworkCredential("vivacious.queen@gmail.com", "bpcjqcyahaxvriiw")
			};

			await client.SendMailAsync(mailMessage);
		}
	}
}
