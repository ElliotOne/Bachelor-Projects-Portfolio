using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Serilog.Events;

namespace ElasticSearch.Models
{
    /// <summary>
    /// Log file model
    /// </summary>
    public class LogDetails
    {
        public LogDetails(SerilogLogLevel logLevel, string message)
        {
            LogLevel = logLevel;
            Message = message;
        }
        /// <summary>
        /// Log description
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// Log level in ElasticSearch
        /// </summary>
        public SerilogLogLevel LogLevel { get; private set; }
    }
}
