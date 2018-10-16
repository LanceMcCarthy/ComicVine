using ComicVine.Forms.Models;
using CommonHelpers.Common;

namespace ComicVine.Forms.ViewModels
{
    public class VideoDetailViewModel : ViewModelBase
    {
        private Video selectedVideo;

        public VideoDetailViewModel()
        {
            Title = "Video Details";
        }

        public Video SelectedVideo
        {
            get => selectedVideo; 
            set => SetProperty(ref selectedVideo, value);
        }
    }
}
