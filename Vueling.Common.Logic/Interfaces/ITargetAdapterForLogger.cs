using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic.Interfaces
{
    public interface ITargetAdapterForLogger
    {
        TimeSpan ExecutionTime { get; set; }
        int Counter { get; set; }

        void Info(string message);
        void Info(string format, params object[] args);
        void Warn(string message);
        void Warn(string format, params object[] args);
        void Debug(Alumno alumno);
        void Debug(string format, params object[] args);
        void Error(string message);
        void Error(string format, params object[] args);
        void Fatal(string message);
        void Fatal(string format, params object[] args);
        void Exception(string message);
        void Exception(string format, params object[] args);
        void EmailException(string message);
    }
}
