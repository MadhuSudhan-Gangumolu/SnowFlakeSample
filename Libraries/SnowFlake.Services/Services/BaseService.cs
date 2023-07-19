using Snowflake.Data.Client;
using SnowFlake.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFlake.Services.Services
{
    public class BaseService
    {
        private IConfigurationService _configuration { get; set; }
        public BaseService(IConfigurationService configuration) 
        { 
            _configuration = configuration;
        }
        public SnowflakeDbConnection BuildConnection()
        {
            var instance = Activator.CreateInstance(typeof(SnowflakeDbConnection)) as SnowflakeDbConnection ?? new SnowflakeDbConnection();
            instance.ConnectionString = _configuration.SnowFlakeConnection;
            instance.Open();
            return instance;
        }
    }
}
