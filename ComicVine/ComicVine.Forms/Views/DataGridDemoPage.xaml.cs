using ComicVine.Forms.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComicVine.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataGridDemoPage : ContentPage
    {
        public DataGridDemoPage()
        {
            InitializeComponent();
            BindingContext = new DataGridDemoViewModel();
        }
    }
}