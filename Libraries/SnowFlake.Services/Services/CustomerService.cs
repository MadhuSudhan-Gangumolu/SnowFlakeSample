using Microsoft.Extensions.Logging;
using Snowflake.Data.Client;
using SnowFlake.Services.Interfaces;
using SnowFlakeSample.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFlake.Services.Services
{
    public class CustomerService : BaseService, ICustomer
    {
        private IConfigurationService _configurationService;
        public CustomerService(IConfigurationService configService)
            :base(configService)
        {
            _configurationService = configService;
        }
        public bool FetchData(ILogger logger)
        {
            using (var connection = BuildConnection())
            {
                var command = connection.CreateCommand();
                
                command.CommandText = $"select * from {_configurationService.Database}" +
                    $".{_configurationService.Schema}.customers";

                using (var reader = command.ExecuteReader())
                {
                    List<CustomerModel> result = new List<CustomerModel>();
                    while (reader.Read())
                    {
                        result.Add(new CustomerModel
                        {
                            Id = reader.GetInt32("ID"),
                            FirstName = reader.GetString("FIRST_NAME")
                        });
                    }
                }
            }

            return true;
        }
    }
}
