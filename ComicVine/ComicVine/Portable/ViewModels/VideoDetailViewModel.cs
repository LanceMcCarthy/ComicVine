using ComicVine.Portable.Models;

namespace ComicVine.Portable.ViewModels
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
