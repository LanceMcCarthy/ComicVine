using ComicVine.Forms.Models;
using CommonHelpers.Common;

namespace ComicVine.Forms.ViewModels
{
    public class VideoDetailViewModel : ViewModelBase
    {
        private Video _selectedVideo;

        public VideoDetailViewModel()
        {
            Title = "Video Details";
        }

        public Video SelectedVideo
        {
            get => _selectedVideo; 
            set => SetProperty(ref _selectedVideo, value);
        }
    }
}
