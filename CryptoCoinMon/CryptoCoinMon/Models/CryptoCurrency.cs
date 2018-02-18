using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoCoinMon.Models
{
    public class CryptoCurrency
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("rank")]
        public string Rank { get; set; }
        [JsonProperty("price_usd")]
        public string PriceUsd { set => Price = value; }
        [JsonProperty("price_btc")]
        public string PriceBtc { get; set; }
        [JsonProperty("24h_volume_usd")]
        public string _24VolumeUsd { set => Volume24Hours = value; }
        [JsonProperty("market_cap_usd")]
        public string MarketCapUsd { set => MarketCap = value; }
        [JsonProperty("available_supply")]
        public string AvailableSupply { get; set; }
        [JsonProperty("total_supply")]
        public string TotalSupply { get; set; }
        [JsonProperty("percent_change_1h")]
        public string PercentageChange1h { get; set; }
        [JsonProperty("percent_change_24h")]
        public string PercentChange24h { get; set; }
        [JsonProperty("percent_change_7d")]
        public string PercentChange7d { get; set; }
        [JsonProperty("last_updated")]
        public string LastUpdated { get; set; }
        [JsonProperty("price_eur")]
        public string PriceEuro { set => Price = value; }
        [JsonProperty("24h_volume_eur")]
        public string Volume24HoursEuros { set => Volume24Hours = value; }
        [JsonProperty("market_cap_eur")]
        public string MarketCapEuros { set => MarketCap = value; }

        /// <summary>
        /// This is used to set the price No matter which Currency
        /// the User 
        /// Wants.
        /// </summary>
        [JsonIgnore]
        public string Price { get; set; }
        [JsonIgnore]
        public string Volume24Hours { get; set; }
        [JsonIgnore]
        public string MarketCap { get; set; }

        [JsonIgnore]
        public string ImageUrl { get; set; }
        /// <summary>
        /// THis represents the color of the Text Representation
        /// Depending on if the the %increased or Decreased
        /// </summary>
        [JsonIgnore]
        public string Color { get; set; }
    }
}
