using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly IEmailSender _emailSender;
		//private readonly ILogger<HomeController> _logger;
		private readonly ILogService _logService;
		public HomeController(IEmailSender emailSender, ILogService logService)
		{
			_emailSender = emailSender;
			_logService = logService;
		}

		[HttpPost("{receiver}")]
		public async Task<IActionResult> Index(string receiver)
		{

			await _emailSender.SendMyEmailAsync(receiver);
			return Ok("Email sent");
		}
		[HttpGet("track/{receiver}")]
		public async Task<IActionResult> Check(string receiver)
		{
			//Console.WriteLine("Email opened at: "+DateTime.Now);
			
			var trackingInfo = new Log()
			{
				ReceiverEmail = receiver,
				TimeStamp = DateTime.Now
			};
			_logService.AddLog(trackingInfo);

			var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/pic.jpg");
			var image = await System.IO.File.ReadAllBytesAsync(imagePath);
			return File(image, "image/jpg");
		}
		[HttpGet("logs")]
		public IActionResult GetLogs()
		{
			List<Log> logs = new List<Log>();
			logs = _logService.GetLogList();
			return Ok(logs);
		}
	}
}
