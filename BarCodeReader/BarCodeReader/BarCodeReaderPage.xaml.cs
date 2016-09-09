using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BarCodeReader
{
    public partial class BarCodeReaderPage : ContentPage
    {
        public BarCodeReaderPage()
        {
            InitializeComponent();
            var scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };

            // Navigate to our scanner page
            Navigation.PushAsync(scanPage);
        }
        
    }
}