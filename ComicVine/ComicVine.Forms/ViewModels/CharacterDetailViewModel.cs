using ComicVine.Forms.Models;
using CommonHelpers.Common;

namespace ComicVine.Forms.ViewModels
{
    public class CharacterDetailViewModel : ViewModelBase
    {
        private Character selectedCharacter;

        public Character SelectedCharacter
        {
            get => selectedCharacter;
            set => SetProperty(ref selectedCharacter, value);
        }
    }
}