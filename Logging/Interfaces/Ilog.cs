using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Interfaces
{
    public interface Ilog
    {
        void LogException(string Message);
        void LogDebug(string Message);
        void LogInfo(string Message);
    }
}
