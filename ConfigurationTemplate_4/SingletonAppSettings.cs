using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationTemplate_4
{
    public class SingletonAppSettings
    {
        public AppSettings appSettings;
        //
        private static readonly Lazy<SingletonAppSettings> lazy = new Lazy<SingletonAppSettings>(() => new SingletonAppSettings());
        private SingletonAppSettings()
        {
        }
        public static SingletonAppSettings Instance => lazy.Value;
    }
}
