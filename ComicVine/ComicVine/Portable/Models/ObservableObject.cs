using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ComicVine.Portable.Annotations;

namespace ComicVine.Portable.Models
{
    public class ObservableObject : INotifyPropertyChanged
    {
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;

            OnPropertyChanged(propertyName);

            return true;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
