using ChronoCalendar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Unit Tests")]

namespace ChronoCalendar
{
    public class Date : IGetDateProperties
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int? Hour { get; set; }
        public int? Minute { get; set; }


        #region Constructors
        public Date(int _year, int _month, int _day, int? _hour, int? _minute)
        {
            Day = _day;
            Month = _month;
            Year = _year;
            Hour = _hour;
            Minute = _minute;
        }

        public Date(int _year, int _month, int _day)
        {
            Day = _day;
            Month = _month;
            Year = _year;
            Hour = null;
            Minute = null;
        }
        #endregion
        public bool IsValidDate()
        {
            if (Day <= 0)
            {
                return false;
            }
            else if (Month <= 0)
            {
                return false;
            }
            else if (Year <= 0)
            {
                return false;
            }
            else if (Minute < 0)
            {
                return false;
            }
            else if (Hour < 0)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            string outputString = string.Empty;
            outputString += Year.ToString();
            outputString += "/";
            outputString += Month.ToString();
            outputString += "/";
            outputString += Day.ToString();
            outputString += " ";
            outputString += Hour.ToString();
            outputString += ":";
            outputString += Minute.ToString();


            return outputString;
        }

        public static bool operator <(Date left, Date right)
        {
            if (left is null || right is null)
            {
                if (right != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (left.Year == right.Year)
            {
                if(left.Month == right.Month)
                {
                    if (left.Day == right.Day)
                    {
                        if (left.Hour == null && right.Hour != null)
                        {
                            return true;
                        }
                        else if (left.Hour != null && right.Hour == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (left.Hour == right.Hour)
                            {
                                return left.Minute < right.Minute;
                            }
                        }
                    }
                    return left.Day < right.Day;
                }
                return left.Month < right.Month;
            }
            return left.Year < right.Year;
        }

        public static bool operator >(Date left, Date right) // null < value
        {
            if(left is null || right is null)
            {
                if (left != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (left.Year == right.Year)
            {
                if (left.Month == right.Month)
                {
                    if (left.Day == right.Day)
                    {
                        if (left.Hour == null && right.Hour != null)
                        {
                            return false;
                        }
                        else if (left.Hour != null && right.Hour == null)
                        {
                            return true;
                        }
                        else
                        {
                            if (left.Hour == right.Hour)
                            {
                                return left.Minute > right.Minute;
                            }
                        }
                    }
                    return left.Day > right.Day;
                }
                return left.Month > right.Month;
            }
            return left.Year > right.Year;
        }

        public static bool operator ==(Date left, Date right)
        {
            if(left is null ^ right is null)
            {
                return false;
            }
            if(left is null && right is null)
            {
                return true;
            }
            return (left.Year == right.Year &&
                left.Month == right.Month &&
                left.Day == right.Day &&
                left.Minute == right.Minute && 
                left.Hour == right.Hour);
        }

        public static bool operator !=(Date left, Date right)
        {

            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if(obj is null)
            {
                return false;
            }
            if (obj.GetType() != typeof(Date))
            {
                return false;
            }
            return this == (Date)obj;
        }

        public override int GetHashCode()
        {
            //hash codes will not be used and warnings are annoying
            return 0;
        }
    }
}

