using System;
using ComicVine.Forms.Models;
using FFImageLoading.Forms;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace ComicVine.Forms.CustomCells
{
    public class CustomListViewTemplateCell : ListViewTemplateCell
    {
        private CachedImage _cachedImage;
        private Label _nameLabel;
        private Label _descriptionLabel;
        
        protected override void OnBindingContextChanged()
        {
            if (BindingContext is Video video)
            {
                _cachedImage = View.FindByName<CachedImage>("ScreenCachedImage");
                _nameLabel = View.FindByName<Label>("NameLabel");
                _descriptionLabel = View.FindByName<Label>("LengthOfVideoLabel");

                _cachedImage.Source = video.Image.ScreenUrl;
                _nameLabel.Text = video.Name;
                _descriptionLabel.Text = TimeSpan.FromSeconds(video.LengthSeconds).ToString("g");
            }
            
            base.OnBindingContextChanged();
        }
    }
}