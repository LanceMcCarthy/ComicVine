using ComicVine.Forms.Models;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace ComicVine.Forms.Views
{
    public partial class CharactersPage : ContentPage
    {
        public CharactersPage()
        {
            InitializeComponent();
        }

        private async void ListView_OnItemTapped(object sender, ItemTapEventArgs e)
        {
            if (e.Item is Character character)
            {
                await Navigation.PushAsync(new CharacterDetailPage(character));
            }
        }
    }
}