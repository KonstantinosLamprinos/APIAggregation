using AggregationService.Interfaces;
using static AggregationService.Enums.APIEnums;

namespace AggregationService.API
{
    public class OpenMeteoAPI : IAPI
    {
        private string source = "https://api.open-meteo.com/v1/forecast?latitude=37.9838&longitude=23.7278&hourly=temperature_2m,rain&timezone=Europe%2FBerlin";
        private string name = "Open-Meteo";

        public APIKind Kind => APIKind.OpenMeteo;



        public string GetName
        {
            get { return name; }
        }

        public string GetSource
        {
            get { return source; }
        }
    }
}
