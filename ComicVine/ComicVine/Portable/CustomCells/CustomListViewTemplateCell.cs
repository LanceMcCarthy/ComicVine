using ComicVine.Portable.Models;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace ComicVine.Portable.CustomCells
{
    public class CustomListViewTemplateCell : Telerik.XamarinForms.DataControls.ListView.ListViewTemplateCell
    {
        private CachedImage cachedImage;
        private Label nameLabel;
        private Label descriptionLabel;

        public CustomListViewTemplateCell()
        {
            
        }

        protected override void OnBindingContextChanged()
        {
            if (BindingContext is Character character)
            {
                cachedImage = View.FindByName<CachedImage>("ThumbnailCachedImage");
                nameLabel = View.FindByName<Label>("NameLabel");
                descriptionLabel = View.FindByName<Label>("DecriptionLabel");

                cachedImage.Source = character.Image.ThumbUrl;
                nameLabel.Text = character.Name;
                descriptionLabel.Text = character.Deck;
            }
            
            base.OnBindingContextChanged();
        }
    }
}
