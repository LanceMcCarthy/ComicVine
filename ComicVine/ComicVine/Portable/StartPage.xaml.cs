using System;
using ComicVine.Portable.Views;
using Xamarin.Forms;

namespace ComicVine.Portable
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private async void CharactersButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharactersPage());
        }

        private async void VideosButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VideosPage());
        }

        private async void AboutButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}