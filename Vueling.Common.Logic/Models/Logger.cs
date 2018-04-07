using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Interfaces;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace Vueling.Common.Logic.Models
{
    public sealed class Logger : ITargetAdapterForLogger
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private bool isInfoEnabled = true;
        private bool isWarnEnabled = true;
        private bool isDebugEnabled = true;
        private bool isErrorEnabled = true;
        private bool isFatalEnabled = true;

        public TimeSpan ExecutionTime { get; set; }
        public int Counter { get; set; }

        public Logger()
        {

        }

        public void Debug(Alumno alumno)
        {
            log.Debug(alumno.ToJson());
        }

        public void Debug(string message)
        {
            log.Debug(message);
        }

        public void Debug(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void EmailException(string message)
        {
            throw new NotImplementedException();
        }

        public void Error(string message)
        {
            log.Error(message);
        }

        public void Error(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Exception(string message)
        {
            throw new NotImplementedException();
        }

        public void Exception(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }

        public void Info(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Warn(string message)
        {
            throw new NotImplementedException();
        }

        public void Warn(string format, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
