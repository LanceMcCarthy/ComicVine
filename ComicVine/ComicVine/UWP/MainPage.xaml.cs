using FFImageLoading.Forms.WinUWP;

namespace ComicVine.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            CachedImageRenderer.Init();
            LoadApplication(new Portable.App());
        }
    }
}
