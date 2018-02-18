using CryptoCoinMon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CryptoCoinMon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CryptoDetailPage : ContentPage
    {
        public static CryptoCurrency Currency;

        public CryptoDetailPage()
        {
            Title = Currency.Name;
            CurrencyIcon.Source = ImageSource.FromUri(new Uri(Currency.ImageUrl));
            Name.Text = Currency.Name;
            Rank.Text = Currency.Rank;
            Symbol.Text = Currency.Symbol;
            PriceUSD.Text = Currency.Price;
            PriceBTC.Text = Currency.PriceBtc + " BTC";
            _24VolUSD.Text = Currency.Volume24Hours;
            MarketCapUSD.Text = "$ " + Currency.MarketCap;
            AvailableSup.Text = "$ " + Currency.AvailableSupply;
            TotalSupply.Text = "$ " + Currency.TotalSupply;

            Change1h.Text = "$ " + Currency.PercentageChange1h;
            if (Change1h.Text.Contains("-")) { Change1h.TextColor = Color.Red; } else { Change1h.TextColor = Color.Green; }

            Change24h.Text = "$ " + Currency.PercentChange24h;
            if (Change24h.Text.Contains("-")) { Change24h.TextColor = Color.Red; } else { Change24h.TextColor = Color.Green; }

            Change7d.Text = "$ " + Currency.PercentChange7d;
            if (Change7d.Text.Contains("-")) { Change7d.TextColor = Color.Red; } else { Change7d.TextColor = Color.Green; }
        }
    }
}