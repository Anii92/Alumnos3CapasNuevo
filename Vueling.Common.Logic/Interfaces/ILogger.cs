using System;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic.Interfaces
{
    public interface ILogger
    {
        void Info(Object message);
        void Warn(Object message);
        void Debug(Object alumno);
        void Error(Object message);
        void Fatal(Object message);
    }
}
