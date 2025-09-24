using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AggregationService.Enums.APIEnums;

namespace AggregationService.Interfaces
{
    public interface IAPIAggregatorService
    {
        Task<IDictionary<APIKind, object>> GetAggregatedAsync(IEnumerable<APIKind> kinds);
    }
}
