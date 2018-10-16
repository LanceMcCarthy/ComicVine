using System;
using System.Diagnostics;
using ComicVine.Forms.Services;
using CommonHelpers.Common;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace ComicVine.Forms.ViewModels
{
    public class CharactersViewModel : ViewModelBase
    {
        private int _currentCharactersCount;
        private int _totalCharactersCount;
        private bool _isCharactersLoadOnDemandActive;

        public CharactersViewModel()
        {
            Title = "Characters";
            
            Characters = new ListViewLoadOnDemandCollection((token) =>
            {
                try
                {
                    // Since the caller run this delegate in a separate task, we can use .Result here safely and it wont block UI thread
                    var apiResult = ApiService.GetCharactersAsync(CurrentCharactersCount, 50).Result;

                    if (apiResult != null)
                    {
                        // We need to marshal to UI thread to update these properties
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            CurrentCharactersCount = apiResult.Offset + apiResult.NumberOfPageResults;
                            TotalCharactersCount = apiResult.NumberOfTotalResults;
                        });

                        return apiResult.Results;
                    }
                }
                catch (Exception exception)
                {
                    Debug.WriteLine($"FetchMoreCharacters Exception: {exception}");
                }

                return null;
            });
        }

        #region ComicVine Related

        public ListViewLoadOnDemandCollection Characters { get; set; }

        public int CurrentCharactersCount
        {
            get => _currentCharactersCount;
            set => SetProperty(ref _currentCharactersCount, value);
        }

        public int TotalCharactersCount
        {
            get => _totalCharactersCount;
            set => SetProperty(ref _totalCharactersCount, value);
        }

        public bool IsCharactersLoadOnDemandActive
        {
            get => _isCharactersLoadOnDemandActive;
            set => SetProperty(ref _isCharactersLoadOnDemandActive, value);
        }
        

        #endregion
    }
}
