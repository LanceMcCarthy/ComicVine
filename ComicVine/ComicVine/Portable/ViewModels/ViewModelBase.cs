using ComicVine.Portable.Models;

namespace ComicVine.Portable.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private bool isBusy;
        private string isBusyMessage;
        private string title;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        public string IsBusyMessage
        {
            get => isBusyMessage;
            set => SetProperty(ref isBusyMessage, value);
        }
        
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
    }
}
