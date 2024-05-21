
namespace EmailDemo
{
	public class LogService : ILogService
	{
		private static List<Log> logs = new List<Log>();
		public void AddLog(Log log)
		{
			logs.Add(log);
		}
		public List<Log> GetLogList()
		{
			return logs;
		}
	}
}
