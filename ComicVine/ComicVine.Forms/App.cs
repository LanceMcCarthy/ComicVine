using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using ComicVine.Forms.Models;
using ComicVine.Forms.Services;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace ComicVine.Forms
{
    public class App : Application
    {
        public App()
        {
            var page = new NavigationPage(new StartPage());

            if(Device.RuntimePlatform == "iOS")
                page.Padding = new Thickness(0,20,0,0);

            MainPage = page;
        }

        protected override async void OnStart()
        {
            await LoadApiKeysAsync();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private async Task LoadApiKeysAsync()
        {
            try
            {
                var json = "";
                var fileName = "keys.json";
                var localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var filePath = Path.Combine(localFolder, fileName); ;

                var exists = File.Exists(filePath);

                if (!exists)
                {
                    // download and save file locally first
                    using (var client = new HttpClient())
                    {
                        json = await client.GetStringAsync("https://dvlup.blob.core.windows.net/general-app-files/JsonConfigs/comicvinekeys.json");
                        
                        File.WriteAllText(filePath, json);
                    }
                }
                else
                {
                    json = File.ReadAllText(filePath);
                }
                
                var result = JsonConvert.DeserializeObject<ApiKeyBase>(json);
                
                ApiKeys.ComicVineApiKey = result.ComicVineApiKey;
                ApiKeys.UniqueUserAgentString = result.UniqueUserAgentString;
            }
            catch (Exception ex)
            {
                // You can safely remove this method once you add your API keys into Services/ApiKeys.cs
                return;
            }
        }
    }
}