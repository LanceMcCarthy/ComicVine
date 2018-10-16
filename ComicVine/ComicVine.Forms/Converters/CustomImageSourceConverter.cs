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
        private readonly HttpClient _client;

        public CustomImageSourceConverter()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("User-Agent", ApiKeys.UniqueUserAgentString);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Character character)
            {
                var source = new CustomStreamImageSource
                {
                    // FFImageLoading uses a unique key value to cache the image, I use the data item's ID
                    Key = character.Id.ToString(),
                    
                    Stream = (token) => Task.FromResult(_client.GetStreamAsync(character.Image.ThumbUrl).Result)
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
            _client?.Dispose();
        }
    }
}
