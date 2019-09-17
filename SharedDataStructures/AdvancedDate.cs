using ChronoCalendar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Unit Tests")]

namespace ChronoCalendar
{
    public class CalendarConfiguration
    {
        private int _yearDays = 360;
        private int _weekDays = 9;
        private int _monthDays = 18;
        private int _monthsInYear = 18/9 ;
        public CalendarConfiguration()
        {

        }

        public int YearDays
        {
            get { return _yearDays; }
        }
        public int WeekDays
        {
            get { return _weekDays; }
        }
        public int MonthDays
        {
            get { return _monthDays; }
        }
        public int MonthsInYear
        {
            get { return _monthsInYear; }
        }
    }
    public class AdvancedDate : INotifyPropertyChanged, IGetDateProperties
    {
        private Date _date;
        private CalendarConfiguration _config;

        public event PropertyChangedEventHandler PropertyChanged;

        public AdvancedDate(Date initalDate, CalendarConfiguration config)
        {
            _date = initalDate;
            _config = config;
        }

        public Date Date
        {
            get { return _date; }
        }

        public int Year
        {
            get { return _date.Year; }
            set { _date.Year = value; }
        }
            
        public int Month { get { return _date.Month; } }

        public int Day { get { return _date.Day; } }

        public int? Hour { get { return _date.Hour; } }

        public int? Minute { get { return _date.Minute; } }


        public void AddYears(int numYears)
        {
            Year += numYears;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Date")); //TODO
        }

        public void AddMonths(int numMonths)
        {
            if(Date.Month + numMonths > _config.MonthsInYear)
            {
                int months = Date.Month + numMonths;
                int newYears = (Date.Month + numMonths) / _config.MonthsInYear;
                AddYears(newYears);
                Date.Month = months - (newYears * _config.MonthsInYear);
            }
            else
            {
                Date.Month += numMonths;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Date")); //TODO
        }
    }
}

