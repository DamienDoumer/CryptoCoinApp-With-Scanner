using CryptoCoinMon.Helpers;
using CryptoCoinMon.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace CryptoCoinMon.ViewModels
{
    public class QRViewModel : BindableBase
    {
        /// <summary>
        /// Fake service to send QRCode to an API
        /// </summary>
        IQRCodeGetterAPI _qRCodeGetterAPI = new QRCodeGetterAPI();

        private ZXingScannerPage _scannerPage;
        private bool _isScanning;
        public bool IsScanning
        {
            get => _isScanning; 
            set =>SetProperty(ref _isScanning, value);
        }

        private string _scannedCode;
        public string ScannedCode
        {
            get => _scannedCode;
            set => SetProperty(ref _scannedCode, value);
        }
        
        public RelayCommand ScannQR { get; private set; }

        public QRViewModel()
        {
            ScannQR = new RelayCommand(() =>
            {
                IsScanning = true;
                var expectedFormat = ZXing.BarcodeFormat.QR_CODE;
                var opts = new ZXing.Mobile.MobileBarcodeScanningOptions
                {
                    PossibleFormats = new List<ZXing.BarcodeFormat> { expectedFormat }
                };

                _scannerPage = new ZXingScannerPage(opts);
                //_scannerPage.

                _scannerPage.OnScanResult += (result) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        _scannerPage.IsScanning = false;
                        IsScanning = false;
                        ScannedCode = result.Text;
                        await _qRCodeGetterAPI.SendQRCode(ScannedCode);
                    });
                };

                Application.Current.MainPage.Navigation.PushAsync(_scannerPage);
            });
        }
    }
}
