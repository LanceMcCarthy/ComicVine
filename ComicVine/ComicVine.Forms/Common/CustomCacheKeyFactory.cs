using FFImageLoading.Forms;
using Xamarin.Forms;

namespace ComicVine.Forms.Common
{
    public class CustomCacheKeyFactory : ICacheKeyFactory
    {
        public string GetKey(ImageSource imageSource, object bindingContext)
        {
            return (imageSource as CustomStreamImageSource)?.Key;
        }
    }
}
