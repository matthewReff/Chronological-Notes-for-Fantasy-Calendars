using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class Note
    {
        public Date date;
        public string title;
        public string content;

        public Note()
        {
            date = new Date();
            title = string.Empty;
            content = string.Empty;
        }

        public Note(Date _date, string _title, string _content)
        {
            date = _date;
            title = _title;
            content = _content;
        }
    }
    
    public class Time
    {
        public int hours;
        public int minutes;
        
        public Time()
        {
            hours = int.MaxValue;
            minutes = int.MaxValue; ;
        }
        public Time( int _hours, int _minutes)
        {
            hours = _hours;
            minutes = _minutes;
        }

        public override string ToString()
        {
            string outputString = string.Empty;
            outputString += "Hours: " + hours.ToString();
            outputString += "\n";
            outputString += "Minutes: " + minutes.ToString();

            return outputString;
        }

    }
    
    public class Date
    {
        public int year;
        public int month;
        public int day;
        public Time time;

        public Date()
        {
            day = int.MaxValue;
            month = int.MaxValue;
            year = int.MaxValue;
            time = new Time();
        }
        public Date(int _year, int _month, int _day, Time _time)
        {
            day = _day;
            month = _month;
            year = _year;
            time = _time;
        }

        public override string ToString()
        {
            string outputString = string.Empty;
            outputString += "Day: " + day.ToString();
            outputString += "\n";
            outputString += "Month: " + month.ToString();
            outputString += "\n";
            outputString += "Year: " + year.ToString();
            outputString += "\n";
            outputString += time.ToString();

            return outputString;
        }

    }


    public class Timeline // : IEnumerable, ICollection
    {

        private LinkedList<Note> _timeLine;


        public Timeline()
        {
            _timeLine = new LinkedList<Note>();

        }

        bool Add(Note note)
        {
            return false;
        }

    }
}
