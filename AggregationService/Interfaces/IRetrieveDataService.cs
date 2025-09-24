using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationService.Interfaces
{
    public interface IRetrieveDataService
    {
        Task<object?> RetrieveDataAsync(IAPI api);
    }
}
