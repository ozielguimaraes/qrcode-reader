using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FomeLine.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace BarCodeReader
{
    public class App : Application
    {
        public App()
        {
            var re = GetGitHubAsync();
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        }
                    }
                }
            };
        }

        public async Task<List<Produto>> GetGitHubAsync()
        {
            try
            {
                var request = WebRequest.Create("http://localhost/Pizzaria/api/services/GetProdutos/1");

                var httpClient = new HttpClient { BaseAddress = request.RequestUri };

                var response = await httpClient.GetAsync(request.RequestUri);

                var content = await response.Content.ReadAsStringAsync();
                var rs = JsonConvert.DeserializeObject<List<Produto>>(content);
                return rs;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
                return null;
            }
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}