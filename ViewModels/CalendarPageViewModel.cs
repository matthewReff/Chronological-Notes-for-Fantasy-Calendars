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
        public event EventHandler CalendarDateChanged;

        public CalendarPageViewModel(Timeline parentTimeline, CalendarConfiguration config, Date initialDate)
        {
            _timelineField = parentTimeline;
            _config = config;
            _advancedDate = new AdvancedDate(initialDate, config);
            MoveCalendarForwardClick = new BindableCommand(OnMoveCalendarForwardButtonClick);
            MoveCalendarBackwardClick = new BindableCommand(OnMoveCalendarBackwardClick);
        }

        #region Bindable Commands
        #endregion

        #region Fields

        #region Backing Members

        private Timeline _timelineField = new Timeline();
        private CalendarConfiguration _config;
        private AdvancedDate _advancedDate;
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

        public string TitleDateDisplayString
        {
            get
            {
                Date temp2 = _advancedDate.Date;
                return temp2.ToString();
            }
        }
        public AdvancedDate Date { get { return _advancedDate; } }

        public CalendarConfiguration Config { get { return _config; } }

        #endregion

        #endregion

        private void OnMoveCalendarForwardButtonClick()
        {
            _advancedDate.AddMonths(1);
            OnPropertyChanged("Date");
            OnPropertyChanged("DisplayDate");
            CalendarDateChanged?.Invoke(this, new EventArgs());
        }
        private void OnMoveCalendarBackwardClick()
        {
            _advancedDate.AddMonths(-1);
            OnPropertyChanged("Date");
            OnPropertyChanged("DisplayDate");
            CalendarDateChanged?.Invoke(this, new EventArgs());
        }

        public BindableCommand MoveCalendarForwardClick { get; set; }
        public BindableCommand MoveCalendarBackwardClick { get; set; }


        protected void OnPropertyChanged([CallerMemberName]string obj = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(obj));
        }
    }
}
