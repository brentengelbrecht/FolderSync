using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSync
{
    public interface ILogger
    {
        void LogToInfo(String message);
        void LogToWarning(String message);
        void LogToError(String message);
    }
}
