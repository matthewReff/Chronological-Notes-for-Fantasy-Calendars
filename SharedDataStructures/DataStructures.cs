using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Unit Tests")]

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

        //public static bool operator ==(Time left, Time right)
        //{
        //    return (left.hours == right.hours &&
        //        left.minutes == right.minutes);
        //}

        //public static bool operator !=(Time left, Time right)
        //{
        //    return !(left.hours == right.hours &&
        //        left.minutes == right.minutes);
        //}

        //public override bool Equals(object obj)
        //{
        //    return this == (Time)obj;
        //}
        //public override int GetHashCode()
        //{
        //    return hours ^ minutes;
        //}
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

        public bool IsValidDate()
        {
            if (day <= 0)
            {
                return false;
            }
            else if (month <= 0)
            {
                return false;
            }
            else if (year <= 0)
            {
                return false;
            }
            else if (time.minutes < 0)
            {
                return false;
            }
            else if (time.hours < 0)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            string outputString = string.Empty;
            outputString += "Year: " + year.ToString();
            outputString += "\n";
            outputString += "Month: " + month.ToString();
            outputString += "\n";
            outputString += "Day: " + day.ToString();
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

        //public static bool operator ==(Date left, Date right)
        //{
        //    return (left.year == right.year &&
        //        left.month == right.month &&
        //        left.day == right.day && 
        //        left.time == right.time);
        //}

        //public static bool operator !=(Date left, Date right)
        //{
        //    return !(left.year == right.year &&
        //        left.month == right.month &&
        //        left.day == right.day &&
        //        left.time == right.time);
        //}

        //public override bool Equals(object obj)
        //{
        //    return this == (Date)obj;
        //}

        //public override int GetHashCode()
        //{
        //    return year ^ month ^ day ^ time.GetHashCode();
        //}
    }

    public class Note
    {
        public Date Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Note()
        {
            Date = new Date();
            Title = string.Empty;
            Content = string.Empty;
        }

        public Note(Date _date, string _title, string _content)
        {
            Date = _date;
            Title = _title;
            Content = _content;
        }

        public override string ToString()
        {
            string outputString = string.Empty;
            outputString += Date.ToString() + "\n";
            outputString += "Title: " + Title + "\n";
            outputString += "Content: " + Content;

            return outputString;
        }

        

        public static bool operator <(Note left, Note right)
        {
            return left.Date < right.Date;
        }

        public static bool operator >(Note left, Note right)
        {
            return left.Date > right.Date;
        }

        //public static bool operator ==(Note left, Note right)
        //{
        //    return left.Date == right.Date;
        //}
        //public static bool operator !=(Note left, Note right)
        //{
        //    return left.Date != right.Date;
        //}

        //public override bool Equals(object obj)
        //{
        //    return this == (Note)obj;
        //}

        //public override int GetHashCode()
        //{
        //    return Date.GetHashCode() ^ Title.GetHashCode() ^ Content.GetHashCode();
        //}

    }

    public class Timeline : IEnumerable, ICollection , INotifyCollectionChanged
    {

        private LinkedList<Note> _timelineList;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public int Count { get; private set; } = 0;

        public bool IsSynchronized
        {
            get
            {
                return true; //TODO
            }
        }

        public object SyncRoot => throw new NotImplementedException(); //TODO

        public IEnumerator GetEnumerator()
        {
            return new TimelineEnumerator(this);
        }

        public Timeline()
        {
            _timelineList = new LinkedList<Note>();
        }

        public bool Add(Note note)
        {
            bool additonIsValid = IsValidNote(note);
            LinkedListNode<Note> currentNode = _timelineList.First;
            
            if(additonIsValid)
            {
                if (Count == 0)
                {
                    _timelineList.AddFirst(note);
                }
                else
                {
                    while(currentNode != _timelineList.Last && note > currentNode.Value)
                    {
                         currentNode = currentNode.Next;
                    }
                    if (currentNode == _timelineList.Last && note > currentNode.Value)
                    {
                            _timelineList.AddLast(note);
                    }
                    else
                    {
                        _timelineList.AddBefore(currentNode, note);
                    }
                }
                Count++;
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)); //TODO
            }

            return additonIsValid;
        }

        public bool Remove(Note note)
        {
            if(Count == 0)
            {
                return false;
            }

            bool noteFound = false;
            LinkedListNode<Note> currentNode = _timelineList.First;
            int removedIndex = 0;

            foreach (Note listNote in _timelineList)
            {
                if(listNote == note)
                {
                    noteFound = true;
                }
                if(!noteFound)
                {
                    currentNode = currentNode.Next;
                    removedIndex++;
                }
            }

            if(noteFound)
            {
                _timelineList.Remove(currentNode);
                Count--;
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)); //TODO


            }

            return noteFound;
        }

        internal LinkedListNode<Note> Find(Note note)
        {
            return _timelineList.Find(note);
        }

        public bool IsValidNote(Note note)
        {
            if(!note.Date.IsValidDate())
            {
                return false;
            }
            
            else if (note.Title == string.Empty)
            {
                return false;
            }

            return true;
        }

        public void CopyTo(Array array, int index)
        {
            List<Note> noteList = new List<Note>();
            foreach(Note note in _timelineList)
            {
                noteList.Add(note);
            }
            noteList.ToArray().CopyTo(array, index);
        }

        public override string ToString()
        {
            string outputString = string.Empty;
            outputString += "Timeline:\n\n";
            foreach(Note note in _timelineList)
            {
                outputString += note.ToString() + "\n\n";
            }

            return outputString;
        }


        class TimelineEnumerator : IEnumerator
        {
            private LinkedList<Note> timeline;
            private LinkedList<Note>.Enumerator internalIterator;

            public TimelineEnumerator(Timeline timeline)
            {
                this.timeline = timeline._timelineList;
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
