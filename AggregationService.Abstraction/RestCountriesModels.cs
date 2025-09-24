using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AggregationService.Abstraction
{
    public class RestCountriesModels
    {
        public sealed record RestCountry(
            [property: JsonPropertyName("name")] Name Name,
            [property: JsonPropertyName("cca2")] string? Cca2,
            [property: JsonPropertyName("cca3")] string? Cca3,
            [property: JsonPropertyName("independent")] bool? Independent,
            [property: JsonPropertyName("unMember")] bool? UnMember,
            [property: JsonPropertyName("capital")] List<string>? Capital,
            [property: JsonPropertyName("region")] string? Region,
            [property: JsonPropertyName("subregion")] string? Subregion,
            [property: JsonPropertyName("population")] long? Population,
            [property: JsonPropertyName("languages")] Dictionary<string, string>? Languages,
            [property: JsonPropertyName("currencies")] Dictionary<string, Currency>? Currencies,
            [property: JsonPropertyName("flags")] Flags? Flags,
            [property: JsonPropertyName("area")] double? Area,
            [property: JsonPropertyName("latlng")] List<double>? LatLng,
            [property: JsonPropertyName("timezones")] List<string>? Timezones,
            [property: JsonPropertyName("borders")] List<string>? Borders,
            [property: JsonPropertyName("maps")] Maps? Maps,
            [property: JsonPropertyName("tld")] List<string>? Tld,
            [property: JsonPropertyName("idd")] Idd? Idd,
            [property: JsonPropertyName("car")] Car? Car,
            [property: JsonPropertyName("continents")] List<string>? Continents,
            [property: JsonPropertyName("status")] string? Status
        );

        public sealed record Name(
            [property: JsonPropertyName("common")] string Common,
            [property: JsonPropertyName("official")] string Official,
            [property: JsonPropertyName("nativeName")] Dictionary<string, Translation>? NativeName
        );

        public sealed record Translation(
            [property: JsonPropertyName("official")] string Official,
            [property: JsonPropertyName("common")] string Common
        );

        public sealed record Currency(
            [property: JsonPropertyName("name")] string Name,
            [property: JsonPropertyName("symbol")] string? Symbol
        );

        public sealed record Flags(
            [property: JsonPropertyName("png")] string? Png,
            [property: JsonPropertyName("svg")] string? Svg,
            [property: JsonPropertyName("alt")] string? Alt
        );

        public sealed record Maps(
            [property: JsonPropertyName("googleMaps")] string? GoogleMaps,
            [property: JsonPropertyName("openStreetMaps")] string? OpenStreetMaps
        );

        public sealed record Idd(
            [property: JsonPropertyName("root")] string? Root,
            [property: JsonPropertyName("suffixes")] List<string>? Suffixes
        );

        public sealed record Car(
            [property: JsonPropertyName("side")] string? Side,
            [property: JsonPropertyName("signs")] List<string>? Signs
        );
    }
}
