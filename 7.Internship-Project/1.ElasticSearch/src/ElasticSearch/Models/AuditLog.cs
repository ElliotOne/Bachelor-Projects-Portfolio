using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearch.Models
{
    /// <summary>
    /// Audit log model
    /// </summary>
    public class AuditLog
    {
        /// <summary>
        /// Type of event , known in ElasticSearch
        /// </summary>
        public string EventType { get; set; } = "defaultindex";
        /// <summary>
        /// Event data (json like format) dictionary
        /// </summary>
        public Dictionary<string, string> Data { get; set; }
    }
}
