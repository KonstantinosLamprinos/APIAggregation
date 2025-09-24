using AggregationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AggregationService.Enums.APIEnums;

namespace AggregationService
{
    public class APIFactory : IAPIFactory
    {
        private readonly IReadOnlyDictionary<APIKind, IAPI> _map;

        public APIFactory(IEnumerable<IAPI> apis)
        {
            if (apis is null) throw new ArgumentNullException(nameof(apis));
            _map = apis.ToDictionary(a => a.Kind);
        }

        public IAPI Resolve(APIKind key)
        {
            var result = _map.TryGetValue(key, out var api);
            if (result is false || api is null)
            {
                throw new ArgumentOutOfRangeException(nameof(key), $"Unknown API '{key}'.");
            }
            return api;
        }


    }
}
