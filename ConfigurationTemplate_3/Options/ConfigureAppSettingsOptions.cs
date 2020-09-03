using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationTemplate_3.Options
{
    public class ConfigureAppSettingsOptions: IPostConfigureOptions<AppSettings>
    {
        public ConfigureAppSettingsOptions()
        { }
        public void PostConfigure(string name, AppSettings options)
        {            
            options.ClientConfigBuild();
        }
    }
}
