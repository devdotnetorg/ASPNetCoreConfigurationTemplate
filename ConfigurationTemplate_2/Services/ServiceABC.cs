using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ConfigurationTemplate_2.Services
{
    public class ServiceABC
    {        
        private readonly IConfiguration _configuration;
        public string Title => _configuration["AppSettings:Parameter1"];        
        public ServiceABC(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public ServiceABC()
        {

        }
    }
}
