using SnowFlake.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFlake.Services.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public string SnowFlakeConnection { get => Environment.GetEnvironmentVariable("SnowFlakeConnection"); }
        public string Database { get => Environment.GetEnvironmentVariable("Database"); }
        public string Schema { get => Environment.GetEnvironmentVariable("Schema"); }
    }
}
