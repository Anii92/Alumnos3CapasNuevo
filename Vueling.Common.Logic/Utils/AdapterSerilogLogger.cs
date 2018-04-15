using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Utils
{
    public class AdapterSerilogLogger : Vueling.Common.Logic.Interfaces.ILogger
    {
        private static readonly string pathLog = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\LogSerilog.txt";
        private readonly Serilog.ILogger log;

        public AdapterSerilogLogger(Type typeDeclaring)
        {
            this.log = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.RollingFile(pathLog)
                        .WriteTo.Console()
                        .CreateLogger();
        }

        public void Debug(object message)
        {
            this.log.Debug(message.ToString());
        }

        public void Error(object message)
        {
            this.log.Error(message.ToString());
        }

        public void Fatal(object message)
        {
            this.log.Fatal(message.ToString());
        }

        public void Info(object message)
        {
            this.log.Information(message.ToString());
        }

        public void Warn(object message)
        {
            this.log.Warning(message.ToString());
        }
    }
}
