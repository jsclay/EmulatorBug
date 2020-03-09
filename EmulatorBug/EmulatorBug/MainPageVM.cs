using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Internals;

namespace EmulatorBug
{
    [Preserve(AllMembers = true)]
    public class MainPageVM : INotifyPropertyChanged
    {
        private string _keyboardStatus = "null";
        public event PropertyChangedEventHandler PropertyChanged;

        public string KeyboardStatus
        {
            get => _keyboardStatus;
            set
            {
                _keyboardStatus = value;
                RaisePropertyChanged(nameof(KeyboardStatus));
            }
        }

        private void RaisePropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
