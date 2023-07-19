using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFlake.Services.Interfaces
{
    public interface IConfigurationService
    {
        string SnowFlakeConnection { get; }
        string Database { get; }
        string Schema { get; }
    }
}
