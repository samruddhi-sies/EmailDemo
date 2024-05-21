namespace EmailDemo
{
	public interface IEmailSender
	{
		Task SendMyEmailAsync(string email);
	}
}
