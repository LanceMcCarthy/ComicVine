using ComicVine.Portable.Models;

namespace ComicVine.Portable.ViewModels
{
    public class CharacterDetailViewModel : ViewModelBase
    {
        private Character selectedCharacter;

        public CharacterDetailViewModel()
        {
            Title = "Character Details";
        }

        public Character SelectedCharacter
        {
            get => selectedCharacter;
            set => SetProperty(ref selectedCharacter, value);
        }
    }
}
