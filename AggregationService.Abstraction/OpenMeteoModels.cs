namespace AggregationService.Abstraction
{
    public class OpenMeteoModels
    {
        public sealed record OpenMeteoForecast(
            double Latitude,
            double Longitude,
            string Timezone,
            Hourly Hourly
        );

        public sealed record Hourly(
            List<string> Time,
            List<decimal> Temperature_2m,
            List<decimal> Rain
        );
    }
}
