using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BarCodeReader
{
    public partial class CustomScanPage : ContentPage
    {
        private readonly ZXingScannerView _zxing;

        public CustomScanPage() : base()
        {
            _zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            _zxing.OnScanResult += (result) =>
                Device.BeginInvokeOnMainThread(async () => {

                    // Stop analysis until we navigate away so we don't keep reading barcodes
                    _zxing.IsAnalyzing = false;

                    // Show an alert
                    await DisplayAlert("Barcode", result.Text, "OK");

                    // Navigate away
                    await Navigation.PopAsync();
                });

            var overlay = new ZXingDefaultOverlay
            {
                TopText = "Segure o seu telefone em cima do código",
                BottomText = "O escaneamento será automaticamente",
                ShowFlashButton = _zxing.HasTorch,
            };
            overlay.FlashButtonClicked += (sender, e) => {
                _zxing.IsTorchOn = !_zxing.IsTorchOn;
            };
            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            grid.Children.Add(_zxing);
            grid.Children.Add(overlay);

            // The root page of your application
            Content = grid;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _zxing.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            _zxing.IsScanning = false;

            base.OnDisappearing();
        }

    }
}