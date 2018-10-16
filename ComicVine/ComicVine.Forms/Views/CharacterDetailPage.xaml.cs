using ComicVine.Forms.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComicVine.Forms.Views
{
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