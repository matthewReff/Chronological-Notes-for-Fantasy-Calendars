using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using ChronoCalendar;

namespace ChronoCalendar
{
    public class CalendarTileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CalendarTileViewModel(Timeline timeline)
        {
            TimelineField = timeline;
            //NoteCreateButtonClick = new BindableCommand(OnNoteCreateButtonClick);
        }

        #region Bindable Commands
        //public BindableCommand NoteCreateButtonClick { get; set; }
        #endregion

        #region Fields

        #region Backing Members

        private Timeline _timelineField = new Timeline();
        private int _selectedNoteIndex = -1;

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

        public Timeline TimelineField
        {
            get { return _timelineField; }
            set
            {
                if (_timelineField != value)
                {
                    _timelineField = value;
                    OnPropertyChanged();
                    OnPropertyChanged("ObservableTimelineField");
                }
            }
        }

        public List<Note> ObservableTimelineField
        {
            get
            {
                List<Note> tempCollection = new List<Note>();
                foreach(Note note in TimelineField)
                {
                    tempCollection.Add(note);
                }
                return tempCollection;
            }
           
        }

        public Date Date
        {
            get
            {
                if(ObservableTimelineField.Count != 0)
                {
                    return ObservableTimelineField[0].Date;
                }
                else
                {
                    return null;
                }
            }

        }
        #endregion

        #endregion

        protected void OnPropertyChanged([CallerMemberName]string obj = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(obj));
        }
    }
}
