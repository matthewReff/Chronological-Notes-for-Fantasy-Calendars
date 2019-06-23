﻿using DataAccessors;
using DataStructures;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
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
            SaveFileButtonClick = new BindableCommand(OnSaveFileButtonClick);
            EditNoteButtonClick = new BindableCommand(OnEditNoteButtonClick);
            RemoveNoteButtonClick = new BindableCommand(OnRemoveNoteButtonClick);
        }

        #region Bindable Commands
        public BindableCommand NoteCreateButtonClick { get; set; }
        public BindableCommand LoadFileButtonClick { get; set; }
        public BindableCommand SaveFileButtonClick { get; set; }
        public BindableCommand EditNoteButtonClick { get; set; }
        public BindableCommand RemoveNoteButtonClick { get; set; }

        #endregion

        #region Fields

        #region Backing Members

        private string _titleField = "The GM is angered";
        private string _contentField = "Rocks fall, and everyone dies.";
        private string _dateField = "1.1.2.3.1";
        private string _filePathField = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)  + "\\example";

        private DataAccessor _dataAccessorField;
        private Timeline _timelineField = new Timeline();
        private int _selectedNoteIndex = -1;
        private string _status = string.Empty;

        #endregion

        #region Properties

        public int SelectedNoteIndex
        {
            get { return _selectedNoteIndex; }
            set
            {
                if (_selectedNoteIndex != value)
                {
                    _selectedNoteIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

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

       

        private void OnLoadFileButtonClick()
        {
            if(!File.Exists(FilePathField))
            {
                Status = "File does not exist";
                return;
            }
            DataAccessor data = new DataAccessor(FilePathField);
            Timeline timeline = new Timeline();
            data.LoadTimeline(out timeline);
            TimelineField = timeline;
            Status = "File Loaded";
            OnPropertyChanged("ObservableTimelineField");
        }

        private void OnSaveFileButtonClick()
        {
            DataAccessor data = new DataAccessor(FilePathField);
            data.SaveTimeline(TimelineField);
            Status = "File Saved";
            OnPropertyChanged("ObservableTimelineField");

        }

        private void OnNoteCreateButtonClick()
        {
            if(TitleField == string.Empty)
            {
                Status = "Title is required";
                return;
            }
            else if(!DataAccessor.PeriodSeperatedStringToDate(DateField).IsValidDate())
            {
                Status = "Date is invalid";
                return;
            }
            TimelineField.Add(new Note { Title = TitleField, Content = ContentField, Date = DataAccessor.PeriodSeperatedStringToDate(DateField) });
            TitleField = string.Empty;
            ContentField = string.Empty;
            DateField = string.Empty;
            OnPropertyChanged("ObservableTimelineField");
        }

        private void OnEditNoteButtonClick()
        {
            if (SelectedNoteIndex >= 0)
            {
                Note thisNote = ObservableTimelineField[SelectedNoteIndex];
                TitleField = thisNote.Title;
                ContentField = thisNote.Content;
                DateField = DataAccessor.DateToPeriodSeperatedString(thisNote.Date);
                TimelineField.Remove(thisNote);
                OnPropertyChanged("ObservableTimelineField");
            }
        }
        private void OnRemoveNoteButtonClick()
        {
            if (SelectedNoteIndex >= 0)
            {
                Note thisNote = ObservableTimelineField[SelectedNoteIndex];
                TimelineField.Remove(thisNote);
                OnPropertyChanged("ObservableTimelineField");
            }
        }

        protected void OnPropertyChanged([CallerMemberName]string obj = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(obj));
        }
    }
}
