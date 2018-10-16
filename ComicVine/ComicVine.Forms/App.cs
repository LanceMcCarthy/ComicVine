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