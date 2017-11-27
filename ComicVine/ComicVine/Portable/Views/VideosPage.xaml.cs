using ComicVine.Portable.Models;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComicVine.Portable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideosPage : ContentPage
    {
        public VideosPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel.Videos.Count == 0)
                ViewModel.LoadOnDemandCommand.Execute(null);
        }

        private async void ListView_OnItemTapped(object sender, ItemTapEventArgs e)
        {
            if (e.Item is Video video)
            {
                await Navigation.PushAsync(new VideoDetailPage(video));
            }
        }
    }
}