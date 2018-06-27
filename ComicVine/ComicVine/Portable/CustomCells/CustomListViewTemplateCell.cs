using System;
using ComicVine.Portable.Models;
using FFImageLoading.Forms;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace ComicVine.Portable.CustomCells
{
    public class CustomListViewTemplateCell : ListViewTemplateCell
    {
        private CachedImage cachedImage;
        private Label nameLabel;
        private Label descriptionLabel;
        
        protected override void OnBindingContextChanged()
        {
            if (BindingContext is Video video)
            {
                cachedImage = View.FindByName<CachedImage>("ScreenCachedImage");
                nameLabel = View.FindByName<Label>("NameLabel");
                descriptionLabel = View.FindByName<Label>("LengthOfVideoLabel");

                cachedImage.Source = video.Image.ScreenUrl;
                nameLabel.Text = video.Name;
                descriptionLabel.Text = TimeSpan.FromSeconds(video.LengthSeconds).ToString("g");
            }
            
            base.OnBindingContextChanged();
        }
    }
}