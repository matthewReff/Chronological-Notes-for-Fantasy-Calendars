using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Unit Tests")]

namespace ChronoCalendar
{
    public class Date
    {
        public int year;
        public int month;
        public int day;
        public int? hour;
        public int? minute;

        
        #region Constructors
        public Date(int _year, int _month, int _day, int? _hour, int? _minute)
        {
            day = _day;
            month = _month;
            year = _year;
            hour = _hour;
            minute = _minute;
        }

        public Date(int _year, int _month, int _day)
        {
            day = _day;
            month = _month;
            year = _year;
            hour = null;
            minute = null;
        }
        #endregion
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
            else if (minute < 0)
            {
                return false;
            }
            else if (hour < 0)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            string outputString = string.Empty;
            outputString += year.ToString();
            outputString += "/";
            outputString += month.ToString();
            outputString += "/";
            outputString += day.ToString();
            outputString += " ";
            outputString += hour.ToString();
            outputString += ":";
            outputString += minute.ToString();


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
                        if (left.hour == null && right.hour != null)
                        {
                            return true;
                        }
                        else if (left.hour != null && right.hour == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (left.hour == right.hour)
                            {
                                return left.minute < right.minute;
                            }
                        }
                    }
                    return left.day < right.day;
                }
                return left.month < right.month;
            }
            return left.year < right.year;
        }

        public static bool operator >(Date left, Date right) // null < value
        {
            if (left.year == right.year)
            {
                if (left.month == right.month)
                {
                    if (left.day == right.day)
                    {
                        if (left.hour == null && right.hour != null)
                        {
                            return false;
                        }
                        else if (left.hour != null && right.hour == null)
                        {
                            return true;
                        }
                        else
                        {
                            if (left.hour == right.hour)
                            {
                                return left.minute > right.minute;
                            }
                        }
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
                left.minute == right.minute && 
                left.hour == right.hour);
        }

        public static bool operator !=(Date left, Date right)
        {
            return !(left.year == right.year &&
                left.month == right.month &&
                left.day == right.day &&
                left.minute == right.minute &&
                left.hour == right.hour);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Date))
            {
                return false;
            }
            return this == (Date)obj;
        }
    }

    public class Note
    {
        public Date Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

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

        public static bool operator ==(Note left, Note right)
        {
            return left.Date == right.Date && 
                left.Title == right.Title &&
                left.Content == right.Content;
        }
        public static bool operator !=(Note left, Note right)
        {
            return !(left.Date == right.Date &&
                left.Title == right.Title &&
                left.Content == right.Content);
        }

        public override bool Equals(object obj)
        {
            if(obj.GetType() != typeof(Note) )
            {
                return false;
            }
            return this == (Note)obj;
        }
    }
}

