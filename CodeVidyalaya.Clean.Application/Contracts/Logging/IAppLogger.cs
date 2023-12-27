using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeVidyalaya.Clean.Application.Contracts.Logging
{
    public interface IAppLogger<T>
    {
        void LogWarning(string message, params object[] args);
        void LogInformation(string message, params object[] args);
    }
}
