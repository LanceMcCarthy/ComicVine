using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComicVine.Forms.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri((sender as Label)?.Text));
        }
    }
}