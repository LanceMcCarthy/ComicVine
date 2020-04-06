using System.Linq;
using ComicVine.Forms.ViewModels;
using Telerik.XamarinForms.DataGrid;
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

        private void MyDataGrid_OnSelectionChanged(object sender, DataGridSelectionChangedEventArgs e)
        {
            if (e.AddedItems?.Any() == true)
            {
                // put your selection logic in here
                var selectedItem = e.AddedItems.FirstOrDefault();


            }
        }
    }
}