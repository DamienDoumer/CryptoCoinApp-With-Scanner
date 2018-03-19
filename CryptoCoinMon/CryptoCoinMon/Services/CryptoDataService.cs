using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CryptoCoinMon.Models;
using Newtonsoft.Json;

namespace CryptoCoinMon.Services
{
    public class CryptoDataService : ICryptoDataService
    {
        const string BASE_URL = "https://api.coinmarketcap.com/v1/ticker/";
        const string IMAGE_BASE_URL = "https://files.coinmarketcap.com/static/img/coins/32x32";
        HttpClient _httpClient;

        public CryptoDataService()
        {
            _httpClient = new HttpClient();
            _httpClient.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<CryptoCurrency>> GetCryptoCurrenciesInEuros()
        {
            List<CryptoCurrency> cryptoCoins = null;
            var Url = BASE_URL + "?convert=EUR";
            var uri = new Uri(Url);

            try
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    cryptoCoins = JsonConvert.DeserializeObject<List<CryptoCurrency>>(content);
                }
                else
                {
                    throw new Exception("Could not connect to internet");
                }
            }
            catch (Exception e)
            {
                throw;
            }

            List<CryptoCurrency> currencies = new List<CryptoCurrency>();
            foreach (var curr in cryptoCoins)
            {
                curr.ImageUrl = $"{IMAGE_BASE_URL}/{curr.Id}.png";
                curr.PriceUsd = $"€ {Decimal.Round(Convert.ToDecimal(curr.Price), 2)}";
                curr.PercentChange24h = curr.PercentChange24h + " %";
                if (curr.PercentChange24h.Contains("-"))
                {
                    curr.Color = "Red";
                }
                else
                {
                    curr.Color = "Green";
                }

                currencies.Add(curr);
            }
            return currencies;
        }

        public async Task<List<CryptoCurrency>> GetCryptoCurrenciesInDollars()
        {
            List<CryptoCurrency> cryptoCoins = null;
            var uri = new Uri(BASE_URL);

            try
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    cryptoCoins = JsonConvert.DeserializeObject<List<CryptoCurrency>>(content);
                }
                else
                {
                    throw new Exception("Could not connect to internet");
                }
            }
            catch (Exception e)
            {
                throw;
            }

            List<CryptoCurrency> currencies = new List<CryptoCurrency>();
            foreach(var curr in cryptoCoins)
            {
                curr.ImageUrl = $"{IMAGE_BASE_URL}/{curr.Id}.png";
                var priceDecimal = Convert.ToDecimal(curr.Price);
                curr.PriceUsd = $"$ {Decimal.Round(priceDecimal, 2)}";
                curr.PercentChange24h = curr.PercentChange24h + " %";
                if (curr.PercentChange24h.Contains("-"))
                {
                    curr.Color = "Red";
                }
                else
                {
                    curr.Color = "Green";
                }

                currencies.Add(curr);
            }
            return currencies;
        }
    }
}
