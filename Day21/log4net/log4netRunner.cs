using log4net;
using log4net.Config;

namespace Day21;

public class log4netRunner
{
	private static readonly log4net.ILog logger = LogManager.GetLogger(typeof(log4netRunner));
	public static void Run()
	{
		XmlConfigurator.Configure(new FileInfo("./log4net/log4net.config"));
		logger.Debug("Info");
		logger.Info("Info");
		logger.Warn("Warn");
		logger.Error("Error");
		logger.Fatal("Fatal");
		
	}
}
