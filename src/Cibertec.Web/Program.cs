using log4net;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Reflection;
using System.Xml;

namespace Cibertec.Web
{
    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            ConfigureLog4Net();
            host.Run();
        }

        private static void ConfigureLog4Net()
        {
            var log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));

            var repo = log4net.LogManager.CreateRepository(
            Assembly.GetEntryAssembly(),typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

            log.Info("Log4Net esta trabajando");
        }
    }
}
