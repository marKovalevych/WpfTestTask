using System;
using System.Text.Json.Serialization;

namespace Entity
{
    public class CryptoCurrency
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("symbol")]
        public string CurrencyId { get; set; }

        [JsonPropertyName("priceUsd")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double Price { get; set; }

        [JsonPropertyName("supply")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double Volume { get; set; }

        [JsonPropertyName("changePercent24Hr")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double PriceChange { get; set; }
    }
}
