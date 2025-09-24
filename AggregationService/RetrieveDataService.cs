using AggregationService.Abstraction;
using AggregationService.API;
using AggregationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static AggregationService.Abstraction.OpenMeteoModels;
using static AggregationService.Abstraction.RestCountriesModels;
using static AggregationService.Enums.APIEnums;

namespace AggregationService
{
    public class RetrieveDataService : IRetrieveDataService
    {

        private static readonly JsonSerializerOptions _json = new()
        {
            PropertyNameCaseInsensitive = true
        };
        private readonly HttpClient _httpClient;
        private readonly IAPI _API;

        public RetrieveDataService(HttpClient httpClient, IAPI  api) 
        {
            _httpClient = httpClient;
            _API = api;
        }

        public async Task<object?> RetrieveDataAsync(IAPI api)
        {
            using var response = await _httpClient.GetAsync(api.GetSource);
            response.EnsureSuccessStatusCode();

            await using var stream = await response.Content.ReadAsStreamAsync();
            //var model = await JsonSerializer.DeserializeAsync<T>(stream, _json);


            //return model ?? throw new InvalidOperationException($"{api.GetName} returned empty body.");

            return api.Kind switch
            {
                APIKind.OpenMeteo => await JsonSerializer.DeserializeAsync<OpenMeteoForecast>(stream, _json),
                APIKind.RestCountries => await JsonSerializer.DeserializeAsync<List<RestCountry>>(stream, _json),
                // APIKind.SpaceX => await JsonSerializer.DeserializeAsync<SpaceXLaunches>(stream, _jsonOptions, ct),
                _ => throw new NotSupportedException($"No model for {api.Kind}")
            };
        }
    }
}
