using AggregationService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AggregationService.Enums.APIEnums;

namespace AggregationService.Interfaces
{
    public interface IAPI
    {
        APIKind Kind { get; }

        string GetName { get; }
        string GetSource { get; }

    }
}
