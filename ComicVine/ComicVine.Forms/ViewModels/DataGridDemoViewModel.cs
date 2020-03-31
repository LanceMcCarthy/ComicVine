using System;
using System.Diagnostics;
using ComicVine.Forms.Models;
using ComicVine.Forms.Services;
using Telerik.XamarinForms.Common;
using Xamarin.Forms;

namespace ComicVine.Forms.ViewModels
{
    public class DataGridDemoViewModel : NotifyPropertyChangedBase
    {
        private int _currentCharactersCount;
        private int _totalCharactersCount;

        public DataGridDemoViewModel()
        {
            Characters = new LoadOnDemandCollection<Character>((token) =>
            {
                try
                {
                    // Make the call to your HTTPS REST API and get the appropriate items. 
                    var apiResult = ApiService.GetCharactersAsync(CurrentCharactersCount, 50).Result;

                    if (apiResult != null)
                    {
                        // since this task is run on another thread, we need
                        // to use BeginInvokeOnMainThread to update these view model properties
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            CurrentCharactersCount = apiResult.Offset + apiResult.NumberOfPageResults;
                            TotalCharactersCount = apiResult.NumberOfTotalResults;
                        });

                        // return the new set of items that will get added to the list
                        return apiResult.Results;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Get next characters error: {ex}");
                }

                return null;
            });
        }

        public LoadOnDemandCollection<Character> Characters { get; set; }

        public int CurrentCharactersCount
        {
            get => _currentCharactersCount;
            set => UpdateValue(ref _currentCharactersCount, value);
        }

        public int TotalCharactersCount
        {
            get => _totalCharactersCount;
            set => UpdateValue(ref _totalCharactersCount, value);
        }
    }
}
