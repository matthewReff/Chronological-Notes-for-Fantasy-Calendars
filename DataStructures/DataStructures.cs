using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TimelineStructureTest")]

namespace DataStructures
{


    public class Time
    {
        public int hours;
        public int minutes;

        public Time()
        {
            hours = int.MaxValue;
            minutes = int.MaxValue; ;
        }
        public Time(int _hours, int _minutes)
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

        public static bool operator <(Time left, Time right)
        {
            if (left.hours == right.hours)
            {
                return left.minutes < right.minutes;
            }
            return left.hours < right.hours;
        }
        public static bool operator >(Time left, Time right)
        {
            if (left.hours == right.hours)
            {
                return left.minutes > right.minutes;
            }
            return left.hours > right.hours;
        }

        public static bool operator ==(Time left, Time right)
        {
            return (left.hours == right.hours &&
                left.minutes == right.minutes);
        }

        public static bool operator !=(Time left, Time right)
        {
            return !(left.hours == right.hours &&
                left.minutes == right.minutes);
        }

        public override bool Equals(object obj)
        {
            return this == (Time)obj;
        }
        public override int GetHashCode()
        {
            return hours ^ minutes;
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
        public static bool operator <(Date left, Date right)
        {
            if (left.year == right.year)
            {
                if(left.month == right.month)
                {
                    if (left.day == right.day)
                    {
                        return left.time < right.time;
                    }
                    return left.day < right.day;
                }
                return left.month < right.month;
            }
            return left.year < right.year;
        }

        public static bool operator >(Date left, Date right)
        {
            if (left.year == right.year)
            {
                if (left.month == right.month)
                {
                    if (left.day == right.day)
                    {
                        return left.time > right.time;
                    }
                    return left.day > right.day;
                }
                return left.month > right.month;
            }
            return left.year > right.year;
        }

        public static bool operator ==(Date left, Date right)
        {
            return (left.year == right.year &&
                left.month == right.month &&
                left.day == right.day && 
                left.time == right.time);
        }

        public static bool operator !=(Date left, Date right)
        {
            return !(left.year == right.year &&
                left.month == right.month &&
                left.day == right.day &&
                left.time == right.time);
        }

        public override bool Equals(object obj)
        {
            return this == (Date)obj;
        }

        public override int GetHashCode()
        {
            return year ^ month ^ day ^ time.GetHashCode();
        }
    }


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

        public override string ToString()
        {
            string outputString = string.Empty;
            outputString += date.ToString() + "\n";
            outputString += "Title: " + title + "\n";
            outputString += "Content: " + content;

            return outputString;
        }

        public static bool operator <(Note left, Note right)
        {
            return left.date < right.date;
        }

        public static bool operator >(Note left, Note right)
        {
            return left.date < right.date;
        }

        public static bool operator ==(Note left, Note right)
        {
            return left.date == right.date;
        }
        public static bool operator !=(Note left, Note right)
        {
            return left.date != right.date;
        }

        public override bool Equals(object obj)
        {
            return this == (Note)obj;
        }

        public override int GetHashCode()
        {
            return date.GetHashCode() ^ title.GetHashCode() ^ content.GetHashCode();
        }

    }

    public class Timeline : IEnumerable //, ICollection
    {

        private LinkedList<Note> timelineList;

        public IEnumerator GetEnumerator()
        {
            return new TimelineEnumerator(this);
        }

        public Timeline()
        {
            timelineList = new LinkedList<Note>();
        }

        public bool Add(Note note)
        {
            bool additonIsValid = IsValidNote(note);

            //big bad refactor later
            if(additonIsValid)
            {
                timelineList.AddFirst(note);
            }


            return additonIsValid;
        }

        protected bool IsValidNote(Note note)
        {
            if (note.date.day <= 0)
            {
                return false;
            }
            else if (note.date.month <= 0)
            {
                return false;
            }
            else if (note.date.year <= 0)
            {
                return false;
            }
            else if (note.date.time.minutes < 0)
            {
                return false;
            }
            else if (note.date.time.hours < 0)
            {
                return false;
            }
            else if (note.title == string.Empty)
            {
                return false;
            }

            return true;
        }



        class TimelineEnumerator : IEnumerator
        {
            private LinkedList<Note> timeline;
            private LinkedList<Note>.Enumerator internalIterator;

            public TimelineEnumerator(Timeline timeline)
            {
                this.timeline = timeline.timelineList;
                this.internalIterator = this.timeline.GetEnumerator();
            }

            public object Current => internalIterator.Current;

            public bool MoveNext()
            {
                return internalIterator.MoveNext();
            }

            public void Reset()
            {
                this.internalIterator = this.timeline.GetEnumerator();
            }
        }
    }
}
