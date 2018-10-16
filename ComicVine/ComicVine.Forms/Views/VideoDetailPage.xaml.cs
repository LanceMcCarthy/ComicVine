using ComicVine.Forms.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComicVine.Forms.Views
{
    public partial class VideoDetailPage : ContentPage
    {
        public VideoDetailPage()
        {
            InitializeComponent();
        }

        public VideoDetailPage(Video video)
        {
            InitializeComponent();

            ViewModel.SelectedVideo = video;

            //VideoWebView.Source = new UrlWebViewSource
            //{
            //    Url = ViewModel.SelectedVideo.EmbedPlayer
            //};
        }
    }
}