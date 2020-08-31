using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ConfigurationTemplate_1.Services
{
    public class ServiceABC
    {
        public string Title;

        public ServiceABC(string title)
        {
            Title = title;
        }
        public ServiceABC()
        {
            
        }
    }
}
