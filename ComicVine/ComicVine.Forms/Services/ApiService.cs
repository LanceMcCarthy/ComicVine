using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using ComicVine.Forms.Models;
using FFImageLoading.Config;
using Newtonsoft.Json;

namespace ComicVine.Forms.Services
{
    public static class ApiService
    {
        // USE YOUR API KEY HERE - To get your own API key go here (it's free) https://comicvine.gamespot.com/api/
        // SET A CUSTOMER USER AGENT HERE - Use a unique identifier for your app (e.g. "MyAwesomeComicVineApp"), otherwise the service WILL THINK YOU ARE A BOT AND RETURN A 403.
        public static string ComicVineApiKey = "";
        public static string UniqueUserAgentString = "";
        
        private static readonly HttpClient Client;
        private static string ApiRoot = "https://comicvine.gamespot.com/api/";

        static ApiService()
        {
            // I load my keys from a json file, you can just hard-code your valuse above
            LoadKeysFromJsonFile();

            var handler = new HttpClientHandler { AllowAutoRedirect = false };

            Client = new HttpClient(handler);
            Client.DefaultRequestHeaders.Add("User-Agent", UniqueUserAgentString);

            // This sets the HttpClient instance that FFImageLoading will use to fetch images, it's helpful when you have authentication or special headers
            FFImageLoading.ImageService.Instance.Initialize(new Configuration
            {
                HttpClient = Client
            });
        }

        public static async Task<CharactersResult> GetCharactersAsync(int offset, int limit = 25)
        {
            var query = $"{ApiRoot}characters?format=json" +
                        $"&api_key={ComicVineApiKey}" +
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
                        $"&api_key={ComicVineApiKey}" +
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
        

        // NOT NEEDED
        // Only used to load my private API strings from a json file. You can delete this one you hard code your strings above.
        private static void LoadKeysFromJsonFile()
        {
            if (!string.IsNullOrEmpty(ComicVineApiKey))
            {
                return;
            }

            var fileName = "keys.json";

            try
            {
                var stream = typeof(ApiService).GetTypeInfo().Assembly.GetManifestResourceStream($"ComicVine.Forms.{fileName}");

                if (stream == null)
                    return;

                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();

                    var result = ApiKeyBase.FromJson(json);

                    ComicVineApiKey = result.ProtectedValues.ComicVineApiKey;
                    UniqueUserAgentString = result.ProtectedValues.UniqueUserAgentString;
                }
            }
            catch (Exception)
            {
                // You can safely remove this method once you add your API key at the top of this class
                return;
            }
            
        }
    }
}
