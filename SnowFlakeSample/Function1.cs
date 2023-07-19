using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Snowflake.Data.Client;
using SnowFlakeSample.Models;

namespace SnowFlakeSample
{
    public class Function1
    {
        [FunctionName("Function1")]
        public static async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            string connectionString = Environment.GetEnvironmentVariable("SnowFlakeConnection");

            try
            {
                using (var connection = new SnowflakeDbConnection())
                {
                    connection.ConnectionString = connectionString;
                    await connection.OpenAsync();

                    var command = connection.CreateCommand();
                    command.CommandText = "select * from Raw.jaffle_shop.customers";
                    
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var customerModel = new CustomerModel
                            {
                                Id = reader.GetInt32(nameof(CustomerModel.Id)),
                                FirstName = reader.GetString("FIRST_NAME")
                            };
                            // Process each row of the result
                            var columnValue = reader.GetString(0);
                            log.LogInformation($"Column Value: {columnValue}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error retrieving data from Snowflake.");
                
            }
        }
    }

    
}
