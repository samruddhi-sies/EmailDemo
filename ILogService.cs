namespace EmailDemo
{
	public interface ILogService
	{
		void AddLog(Log log);
		List<Log> GetLogList();
	}
}
