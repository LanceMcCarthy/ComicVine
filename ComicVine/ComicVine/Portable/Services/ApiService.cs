using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ComicVine.Portable.Models;
using FFImageLoading.Config;
using Newtonsoft.Json;

namespace ComicVine.Portable.Services
{
    public static class ApiService
    {
        private static HttpClient _client;
        private static string ApiRoot = "https://comicvine.gamespot.com/api/";

        static ApiService()
        {
            var handler = new HttpClientHandler { AllowAutoRedirect = false };

            _client = new HttpClient(handler);
            _client.DefaultRequestHeaders.Add("User-Agent", ApiKeys.UniqueUserAgentString);

            // IMPORTANT
            // This sets the HttpClient instance that FFImageLoading will use to fetch images, 
            // It's helpful when you have authentication or special headers
            FFImageLoading.ImageService.Instance.Initialize(new Configuration
            {
                HttpClient = _client
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
                // This is neccessary because the API does a redirect
                using (HttpResponseMessage response = await _client.GetAsync(query))
                {
                    if (response.StatusCode == HttpStatusCode.Redirect || response.StatusCode == HttpStatusCode.MovedPermanently)
                    {
                        using (HttpResponseMessage fallbackResponseMessage = await _client.GetAsync(response.Headers.Location))
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
                // did you forget to add the information to ApiKeys.cs ?
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
                using (HttpResponseMessage response = await _client.GetAsync(query))
                {
                    if (response.StatusCode == HttpStatusCode.Redirect || response.StatusCode == HttpStatusCode.MovedPermanently)
                    {
                        using (HttpResponseMessage fallbackResponseMessage = await _client.GetAsync(response.Headers.Location))
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
                // did you forget to add the information to ApiKeys.cs ?
                throw;
#else
                return null;
#endif
            }
        }

        public static async Task<MemoryStream> GetImageAsync(string url)
        {
            try
            {
                using (HttpResponseMessage response = await _client.GetAsync(url))
                {
                    var ms = new MemoryStream();
                    await response.Content.CopyToAsync(ms);
                    ms.Position = 0;
                    return ms;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine($"ApiService GetCharactersAsync Exception: {e}");
#if DEBUG
                // did you forget to add the information to ApiKeys.cs ?
                throw;
#else
                return null;
#endif
            }
        }
    }
}
