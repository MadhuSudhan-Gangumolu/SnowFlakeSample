using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFlake.Services.Interfaces
{
    public interface ICustomer
    {
        bool FetchData(ILogger logger);
    }
}
