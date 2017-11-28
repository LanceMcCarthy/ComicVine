using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ComicVine.Portable.Models;
using ComicVine.Portable.Services;
using Xamarin.Forms;

namespace ComicVine.Portable.ViewModels
{
    public class CharactersViewModel : ViewModelBase
    {
        private int currentItemCount;
        private int totalItemCount;
        private bool isLoadOnDemandActive;

        public CharactersViewModel()
        {
            Title = "Characters";

            LoadOnDemandCommand = new Command(async ()=> await GetItemsAsync());
        }

        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();

        public int CurrentItemCount
        {
            get => currentItemCount;
            set => SetProperty(ref currentItemCount, value);
        }

        public int TotalItemCount
        {
            get => totalItemCount;
            set => SetProperty(ref totalItemCount, value);
        }

        public bool IsLoadOnDemandActive
        {
            get => isLoadOnDemandActive;
            set => SetProperty(ref isLoadOnDemandActive, value);
        }

        public Command LoadOnDemandCommand { get; set; }

        public async Task GetItemsAsync()
        {
            try
            {
                IsBusy = true;
                IsBusyMessage = "Getting Characters from API...";
                
                var apiResult = await ApiService.GetCharactersAsync(CurrentItemCount);

                if (apiResult == null)
                    return;

                CurrentItemCount = apiResult.Offset + apiResult.NumberOfPageResults;
                TotalItemCount = apiResult.NumberOfTotalResults;

                foreach (var character in apiResult.Results)
                {
                    Characters.Add(character);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"CharactersViewModel GetItemsAsync Exception: {exception}");
            }
            finally
            {
                IsLoadOnDemandActive = false;
                IsBusy = false;
                IsBusyMessage = "";
            }
        }
    }
}
