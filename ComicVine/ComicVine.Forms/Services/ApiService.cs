using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ComicVine.Forms.Models;
using FFImageLoading.Config;
using Newtonsoft.Json;

namespace ComicVine.Forms.Services
{
    public static class ApiService
    {
        private static readonly HttpClient Client;
        private static string ApiRoot = "https://comicvine.gamespot.com/api/";

        static ApiService()
        {
            var handler = new HttpClientHandler { AllowAutoRedirect = false };

            Client = new HttpClient(handler);
            Client.DefaultRequestHeaders.Add("User-Agent", ApiKeys.UniqueUserAgentString);

            // This sets the HttpClient instance that FFImageLoading will use to fetch images, it's helpful when you have authentication or special headers
            FFImageLoading.ImageService.Instance.Initialize(new Configuration
            {
                HttpClient = Client
            });
        }

        public static async Task<CharactersResult> GetCharactersAsync(int offset, int limit = 25)
        {
            var query = $"{ApiRoot}characters?format=json" +
                        $"&api_key={ApiKeys.ComicVineApiKey}" +
                        $"&offset={offset}" +
                        $"&limit={limit}";

            try
            {
                // This is necessary because the API does a redirect
                using (var response = await Client.GetAsync(query))
                {
                    if (response.StatusCode == HttpStatusCode.Redirect || response.StatusCode == HttpStatusCode.MovedPermanently)
                    {
                        using (var fallbackResponseMessage = await Client.GetAsync(response.Headers.Location))
                        using (var streamResult = await fallbackResponseMessage.Content.ReadAsStreamAsync())
                        using (var reader = new StreamReader(streamResult))
                        {
                            var jsonResult = await reader.ReadToEndAsync();

                            return JsonConvert.DeserializeObject<CharactersResult>(jsonResult);
                        }
                    }
                    else
                    {
                        var jsonResult = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<CharactersResult>(jsonResult);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"ApiService GetCharactersAsync Exception: {e}");
#if DEBUG
                // did you forget to add your API key (see the top of this class)?
                throw;
#else
                return null;
#endif
            }
        }
        
        public static async Task<VideosResult> GetVideosAsync(int offset, int limit = 25)
        {
            var query = $"{ApiRoot}videos?format=json" +
                        $"&api_key={ApiKeys.ComicVineApiKey}" +
                        $"&offset={offset}" +
                        $"&limit={limit}";

            try
            {
                using (var response = await Client.GetAsync(query))
                {
                    if (response.StatusCode == HttpStatusCode.Redirect || response.StatusCode == HttpStatusCode.MovedPermanently)
                    {
                        using (var fallbackResponseMessage = await Client.GetAsync(response.Headers.Location))
                        using (var streamResult = await fallbackResponseMessage.Content.ReadAsStreamAsync())
                        using (var reader = new StreamReader(streamResult))
                        {
                            var jsonResult = await reader.ReadToEndAsync();

                            return JsonConvert.DeserializeObject<VideosResult>(jsonResult);
                        }
                    }
                    else
                    {
                        var jsonResult = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<VideosResult>(jsonResult);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"ApiService GetVideosAsync Exception: {e}");

#if DEBUG
                // did you forget to add your API key (see the top of this class)?
                throw;
#else
                return null;
#endif
            }
        }
    }
}
