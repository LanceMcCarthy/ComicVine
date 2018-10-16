using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using ComicVine.Forms.Common;
using ComicVine.Forms.Models;
using ComicVine.Forms.Services;
using Xamarin.Forms;

namespace ComicVine.Forms.Converters
{
    internal class CustomImageSourceConverter : IValueConverter, IDisposable
    {
        // It's important to reuse the same HttpClient instance
        private readonly HttpClient client;

        public CustomImageSourceConverter()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", ApiKeys.UniqueUserAgentString);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // My demo uses a Character model that contains the image string and an ID property
            if (value is Character character)
            {
                // 
                var source = new CustomStreamImageSource
                {
                    // FFImageLoading uses a unique key value to cache the image, I use the data item's ID
                    Key = character.Id.ToString(),

                    // This is the Stream for the image, my model has a ThumbUrl string
                    Stream = (token) => Task.FromResult(client.GetStreamAsync(character.Image.ThumbUrl).Result)
                };
            
                // this will be returned to the CachedImage instance
                return source;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
