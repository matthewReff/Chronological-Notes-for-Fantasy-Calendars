using DataAccessors;
using DataStructures;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModelHelpers;

namespace MainPageDisplayViewModelNamespace
{
    public class MainPageDisplayViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageDisplayViewModel()
        {
            NoteCreateButtonClick = new BindableCommand(OnNoteCreateButtonClick);
            LoadFileButtonClick = new BindableCommand(OnLoadFileButtonClick);
        }

        #region Bindable Commands
        public BindableCommand NoteCreateButtonClick { get; set; }
        public BindableCommand LoadFileButtonClick { get; set; }
        #endregion

        #region Fields

        #region Backing Members

        private string _titleField = string.Empty;
        private string _contentField = string.Empty;
        private string _dateField = string.Empty;
        private string _filePathField = string.Empty;
        private DataAccessor _dataAccessorField;
        private Timeline _timelineField = new Timeline();

        #endregion

        #region Properties

        public Timeline TimelineField
        {
            get { return _timelineField; }
            set
            {
                if (_timelineField != value)
                {
                    _timelineField = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Note> ObservableTimelineField
        {
            get
            {
                ObservableCollection<Note> tempCollection = new ObservableCollection<Note>();
                foreach(Note note in TimelineField)
                {
                    tempCollection.Add(note);
                }
                return tempCollection;
            }
           
        }

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

        public string FilePathField
        {
            get { return _filePathField; }
            set
            {
                if (_filePathField != value)
                {
                    _filePathField = value;
                    OnPropertyChanged();
                }
            }
        }

        public DataAccessor DataAccessorField
        {
            get { return _dataAccessorField; }
            set
            {
                if (_dataAccessorField != value)
                {
                    _dataAccessorField = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #endregion

        private void OnNoteCreateButtonClick()
        {
            //TempList.Add(new Note { Title = TitleField, Content = ContentField, Date = DataAccessor.PeriodSeperatedStringToDate(DateField);
            TimelineField.Add(new Note { Title = TitleField, Content = ContentField, Date = DataAccessor.PeriodSeperatedStringToDate(DateField) });
            OnPropertyChanged("ObservableTimelineField");
        }

        private void OnLoadFileButtonClick()
        {
            DataAccessor data = new DataAccessor(FilePathField);
            Timeline timeline = new Timeline();
            data.LoadTimeline(out timeline);
            TimelineField = timeline;
            OnPropertyChanged("ObservableTimelineField");

        }


        protected void OnPropertyChanged([CallerMemberName]string obj = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(obj));
        }
    }
}
