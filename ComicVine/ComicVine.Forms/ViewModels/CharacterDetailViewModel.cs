using ComicVine.Forms.Models;
using CommonHelpers.Common;

namespace ComicVine.Forms.ViewModels
{
    public class CharacterDetailViewModel : ViewModelBase
    {
        private Character _selectedCharacter;

        public Character SelectedCharacter
        {
            get => _selectedCharacter;
            set => SetProperty(ref _selectedCharacter, value);
        }
    }
}