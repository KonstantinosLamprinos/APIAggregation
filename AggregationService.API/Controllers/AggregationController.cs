using AggregationService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AggregationService.Enums.APIEnums;

namespace AggregationService.API.Controllers
{
    [ApiController]
    [Route("api/aggregation")]
    public class AggregationController : ControllerBase
    {

        private readonly ILogger<AggregationController> _logger;
        private readonly IAPIAggregatorService _apiAggregatorService;

        public AggregationController(ILogger<AggregationController> logger, IAPIAggregatorService apiAggregatorService )
        {
            _logger = logger;
            _apiAggregatorService = apiAggregatorService;
        }

        //[Authorize]  // issue in Swagger authorization configuration 
        [HttpGet]
        public async Task<ActionResult<IDictionary<APIKind, object>>> Get([FromQuery] APIKind[] sources)
        {
            if (sources is null || sources.Length == 0)
                sources = new[] { APIKind.OpenMeteo };

            var result = await _apiAggregatorService.GetAggregatedAsync(sources);
            return Ok(result);
        }
    }
}
