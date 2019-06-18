using DataStructures;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MainPageDisplayViewModelNamespace
{
    public class MainPageDisplayViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _titleField;
        private string _contentField;
        private string _dateField;
        
        public Timeline Timeline { get; set; }
        public string TitleField
        {
            get { return _titleField; }
            set
            {
                if (_titleField != value)
                {
                    _titleField = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ContentField
        {
            get { return _contentField; }
            set
            {
                if (_contentField != value)
                {
                    _contentField = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DateField
        {
            get { return _dateField; }
            set
            {
                if (_dateField != value)
                {
                    _dateField = value;
                    OnPropertyChanged();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName]string obj = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(obj));
        }
    }
}
