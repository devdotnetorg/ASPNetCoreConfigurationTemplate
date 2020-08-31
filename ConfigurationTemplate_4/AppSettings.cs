using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationTemplate_4
{
    /// <summary>
    /// Настройки приложения.
    /// </summary>
    public class AppSettings
    {        
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }        
        public ClientConfig clientConfig;
        public void ClientConfigBuild()
        {
            clientConfig = new ClientConfig(new ClientConfigOptions()
            {
                Parameter1 = this.Parameter1,
                Parameter2 = this.Parameter2
            }
            );
        }
    }
}