using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace Vueling.Common.Logic.Utils
{
    public sealed class AdapterLog4NetLogger : ILogger
    {
        private log4net.ILog log;


        public AdapterLog4NetLogger(Type typeDeclaring)
        {
            this.log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
            this.log.Info(message.ToString());
        }

        public void Warn(object message)
        {
            this.log.Warn(message.ToString());
        }
    }
}
