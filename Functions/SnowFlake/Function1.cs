using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Snowflake.Data.Client;
using SnowFlake.Services.Interfaces;
using SnowFlakeSample.Models;

namespace SnowFlake
{
    public class Function1
    {
        private static ICustomer CustomerServices { get; set; }

        public Function1(ICustomer customerService)
        {
            CustomerServices = customerService;
        }
        [FunctionName("Function1")]
        public void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, 
            ILogger log)
        {
            try
            {
                CustomerServices.FetchData(log);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error retrieving data from Snowflake.");

            }
        }

        [FunctionName("Function2")]
        public void Trigger2([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer,
            ILogger log)
        {
            try
            {
                CustomerServices.FetchData(log);
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error retrieving data from Snowflake.");

            }
        }
    }


}
