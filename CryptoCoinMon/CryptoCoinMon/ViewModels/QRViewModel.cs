using CryptoCoinMon.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using ZXing.Net.Mobile.Forms;

namespace CryptoCoinMon.ViewModels
{
    public class QRViewModel : BindableBase
    {
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
            ScannQR = new RelayCommand(async () =>
            {
                IsScanning = true;
                var expectedFormat = ZXing.BarcodeFormat.QR_CODE;
                var opts = new ZXing.Mobile.MobileBarcodeScanningOptions
                {
                    PossibleFormats = new List<ZXing.BarcodeFormat> { expectedFormat }
                };

                _scannerPage = new ZXingScannerPage(opts);

                _scannerPage.OnScanResult += (result) =>
                {
                    _scannerPage.IsScanning = false;
                    IsScanning = false;
                    ScannedCode = result.Text;
                };
            });
        }
    }
}
