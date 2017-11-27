using ComicVine.Portable.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComicVine.Portable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterDetailPage : ContentPage
    {
        public CharacterDetailPage()
        {
            InitializeComponent();
        }

        public CharacterDetailPage(Character character)
        {
            InitializeComponent();

            ViewModel.SelectedCharacter = character;
        }
    }
}