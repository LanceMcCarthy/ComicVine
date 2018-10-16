using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ComicVine.Forms.Models;
using ComicVine.Forms.Services;
using CommonHelpers.Common;
using Xamarin.Forms;

namespace ComicVine.Forms.ViewModels
{
    public class VideosViewModel : ViewModelBase
    {
        private int _currentItemCount;
        private int _totalItemCount;
        private bool _isLoadOnDemandActive;

        public VideosViewModel()
        {
            Title = "Videos";

            LoadOnDemandCommand = new Command(async () => await GetItemsAsync());
        }

        public ObservableCollection<Video> Videos { get; set; } = new ObservableCollection<Video>();

        public int CurrentItemCount
        {
            get => _currentItemCount;
            set => SetProperty(ref _currentItemCount, value);
        }

        public int TotalItemCount
        {
            get => _totalItemCount;
            set => SetProperty(ref _totalItemCount, value);
        }

        public bool IsLoadOnDemandActive
        {
            get => _isLoadOnDemandActive;
            set => SetProperty(ref _isLoadOnDemandActive, value);
        }

        public Command LoadOnDemandCommand { get; set; }

        public async Task GetItemsAsync()
        {
            try
            {
                IsBusy = true;
                IsBusyMessage = "Getting Videos from API...";
                
                var apiResult = await ApiService.GetVideosAsync(CurrentItemCount);

                if (apiResult == null)
                    return;

                CurrentItemCount = apiResult.Offset + apiResult.NumberOfPageResults;
                TotalItemCount = apiResult.NumberOfTotalResults;

                foreach (var character in apiResult.Results)
                {
                    Videos.Add(character);
                }
                
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"VideosViewModel GetItemsAsync Exception: {exception}");
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
