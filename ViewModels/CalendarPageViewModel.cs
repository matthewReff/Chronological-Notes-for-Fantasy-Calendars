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
    public class CalendarPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CalendarPageViewModel()
        {
            DataAccessor temp = new DataAccessor("Calendar");
            temp.LoadTimeline(out _timelineField);
            //NoteCreateButtonClick = new BindableCommand(OnNoteCreateButtonClick);
        }

        #region Bindable Commands
        //public BindableCommand NoteCreateButtonClick { get; set; }
        #endregion

        #region Fields

        #region Backing Members

        private Timeline _timelineField = new Timeline();
        private Dictionary<Date, Timeline> _tileTimelines = new Dictionary<Date, Timeline>();
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
                    OnPropertyChanged("TileTimelines");
                }
            }
        }

        public List<Note> ObservableTimelineField
        {
            get
            {
                List<Note> tempCollection = new List<Note>();
                foreach (Note note in TimelineField)
                {
                    tempCollection.Add(note);
                }
                return tempCollection;
            }

        }

        public Dictionary<Date, Timeline> TileTimelines
        {
            get
            {
                return _tileTimelines;
            }

        }

        public Date Date
        {
            get
            {
                return ObservableTimelineField[0].Date;
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
