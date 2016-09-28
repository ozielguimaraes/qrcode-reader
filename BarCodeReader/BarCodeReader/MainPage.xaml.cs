using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BarCodeReader
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private async void LerQRCode_OnClicked(object sender, EventArgs e)
        {
            var scanPage = new CustomScanPage();
            //var scanPage = new ZXingScannerPage();
            // Navigate to our scanner page
           await  Navigation.PushModalAsync(scanPage);
        }
    }
}