using AggregationService.Interfaces;
using static AggregationService.Enums.APIEnums;

namespace AggregationService
{
    public class APIAggregatorService : IAPIAggregatorService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAPIFactory _apiFactory;
        private readonly IRetrieveDataService _retrieveDataService;

        public APIAggregatorService(IHttpClientFactory httpClientFactory, IAPIFactory factory, IRetrieveDataService retrieveDataService)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _apiFactory = factory ?? throw new ArgumentNullException(nameof(factory));
            _retrieveDataService = retrieveDataService;
        }

        public async Task<IDictionary<APIKind, object>> GetAggregatedAsync(IEnumerable<APIKind> kinds)
        {
            var tasks = kinds.Select(async kind =>
            {
                var api = _apiFactory.Resolve(kind);
                var result = await _retrieveDataService.RetrieveDataAsync(api);
                return new KeyValuePair<APIKind, object>(kind, result);
            });

            var results = await Task.WhenAll(tasks);
            return results.ToDictionary(x => x.Key, x => x.Value);
        }

    }
}
