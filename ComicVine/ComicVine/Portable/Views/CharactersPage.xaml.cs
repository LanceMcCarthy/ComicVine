using ComicVine.Portable.Models;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComicVine.Portable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharactersPage : ContentPage
    {
        public CharactersPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel.Characters.Count == 0)
                ViewModel.LoadOnDemandCommand.Execute(null);
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