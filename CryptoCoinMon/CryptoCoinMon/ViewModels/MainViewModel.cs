using CryptoCoinMon.Helpers;
using CryptoCoinMon.Models;
using CryptoCoinMon.Services;
using CryptoCoinMon.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CryptoCoinMon.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private CryptoCurrency _selectedItem;
        public CryptoCurrency SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                if (value != null)
                {
                    CryptoDetailPage.Currency = value;
                    App.Current.MainPage.Navigation.PushModalAsync(new CryptoDetailPage());
                }
            }
        }

        public RelayCommand CallQRScannerCommand { get; private set; }
        public RelayCommand DollarCurrencyCommand { get; set; }
        public RelayCommand EuroCurrencyCommand { get; set; }

        ObservableCollection<CryptoCurrency> _cryptoCurrencies;
        public ObservableCollection<CryptoCurrency> CryptoCurrencies
        {
            get => _cryptoCurrencies;
            set
            {
                SetProperty(ref _cryptoCurrencies, value);
                IsRefreshing = false;
            }
        }
        public RelayCommand RefreshCommand { get; private set; }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }
        private CryptoDataService _cryptoDataService;

        public string DollarIcon { get; set; }
        public string EuroIcon { get; set; }
        public string MainIcon { get; set; }

        public MainViewModel()
        {
            MainIcon = "Logo.png";
            CryptoCurrencies = new ObservableCollection<CryptoCurrency>();
            RefreshCommand = new RelayCommand(async () => await RefreshList());
            _cryptoDataService = new CryptoDataService();
            DollarIcon = "Images.dolar.png";
            EuroIcon = "Images.euro.png";
            DollarCurrencyCommand = new RelayCommand(async () =>
            {
                Settings.PrefferedCurrency = "dollar";
                await LoadCrypto();
            });
            EuroCurrencyCommand = new RelayCommand(async () =>
            {
                Settings.PrefferedCurrency = "euro";
                await LoadCrypto();
            });
            CallQRScannerCommand = new RelayCommand(async () => await App.Current.MainPage.Navigation.PushAsync(new QRScannerPage()));
        }

        public async Task Initialize()
        {
            await LoadCrypto();

            //When internet connectivity changes, Fire this Event.
            //CrossConnectivity.Current.ConnectivityChanged += async (s, e) =>
            //{
            //    if (CrossConnectivity.Current.IsConnected)
            //    {
            //        await LoadCrypto();
            //    }
            //};
        }

        private async Task RefreshList()
        {
            await LoadCrypto();
        }

        private async Task LoadCrypto()
        {
            IsRefreshing = true;
            try
            {
                if (Settings.PrefferedCurrency.ToLower() == "euro")
                {
                    CryptoCurrencies = new ObservableCollection<CryptoCurrency>(await _cryptoDataService.GetCryptoCurrenciesInEuros());
                }
                else
                {
                    CryptoCurrencies = new ObservableCollection<CryptoCurrency>(await _cryptoDataService.GetCryptoCurrenciesInDollars());
                }
            }
            catch(Exception e)
            {
                var msg = e.Message;
                var mainPage = App.Current.MainPage;
                await mainPage.DisplayAlert("Problem Connecting to The Internet",
                    "Please Check your Internet Connection. Pull this list down when internet connection is available",
                    "OK");

                IsRefreshing = false;
            }
        }
    }
}
