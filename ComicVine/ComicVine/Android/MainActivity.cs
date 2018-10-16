using Android.App;
using Android.Content.PM;
using Android.OS;

namespace ComicVine.Android
{
    [Activity(Theme = "@style/MainTheme", Label = "ComicVine.Android", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            LoadApplication(new ComicVine.Forms.App());
        }
    }
}

