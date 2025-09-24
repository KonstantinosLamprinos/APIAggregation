using AggregationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static AggregationService.Enums.APIEnums;

namespace AggregationService.API
{
    public class RestCountriesAPI : IAPI
    {
        private string source = "https://restcountries.com/v3.1/independent?status=true";
        private string name = "REST Countries";

        public APIKind Kind => APIKind.RestCountries;
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
