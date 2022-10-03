using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace Entity
{
    public class CryptoCurrency
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("symbol")]
        public string Code { get; set; }

        [JsonPropertyName("priceUsd")]
        public string Price { get; set; }

        [JsonPropertyName("supply")]
        public string Volume { get; set; }

        [JsonPropertyName("changePercent24Hr")]
        public string PriceChange { get; set; }

        [JsonPropertyName("explorer")]
        public string Market { get; set; }
    }
}
