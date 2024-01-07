using Audit.Core;
using AutoMapper;
using ElasticSearch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace ElasticSearch.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        //ASP.Net Core logger with Serilog configured options
        private readonly ILogger<LoggerController> _logger;
        private readonly IMapper _mapper;
        public LoggerController(ILogger<LoggerController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Log(LogDetails logDetails)
        {
            LogLevel logLevel = _mapper.Map<SerilogLogLevel, LogLevel>(logDetails.LogLevel);
            _logger.Log(logLevel, logDetails.Message);

            return new JsonResult(Ok());
        }

        [HttpPost]
        public IActionResult LogAudit(AuditLog auditLog)
        {
            //AuditScope.Log("defaultindex",
            //    new
            //    {
            //        MyProperty = "MyPropertyValue",
            //        MyProperty2 = "MyPropertyValue2",
            //        MyProperty3 = "MyPropertyValue3",
            //    });

            //log audit
            AuditScope.Log("defaultindex",
                new
                {
                    Data = auditLog.Data
                });


            return new JsonResult(Ok());
        }
    }
}
