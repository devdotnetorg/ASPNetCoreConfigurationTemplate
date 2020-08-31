using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationTemplate_5
{
    public class ClientConfig
    {
        private string _parameter1;
        private string _parameter2;
        public string Value => _parameter1 + " " + _parameter2;
        public ClientConfig(ClientConfigOptions configOptions)
        {
            _parameter1 = configOptions.Parameter1;
            _parameter2 = configOptions.Parameter2;
        }
    }

    public class ClientConfigOptions
    {
        public string Parameter1;
        public string Parameter2;
    }
}