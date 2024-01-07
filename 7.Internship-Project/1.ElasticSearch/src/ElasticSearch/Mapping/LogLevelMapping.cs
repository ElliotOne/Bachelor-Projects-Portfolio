using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ElasticSearch.Models;
using Microsoft.Extensions.Logging;

namespace ElasticSearch.Mapping
{
    public class LogLevelMapping : Profile
    {
        public LogLevelMapping()
        {
            CreateMap<SerilogLogLevel,LogLevel>();
        }
    }
}
