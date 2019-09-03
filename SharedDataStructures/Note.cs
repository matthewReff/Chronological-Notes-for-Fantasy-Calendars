using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Unit Tests")]

namespace ChronoCalendar
{
    public class Note
    {
        public Date Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Note(Date _date, string _title, string _content = null)
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
            return left.Date < right.Date;
        }

        public static bool operator >(Note left, Note right)
        {
            if (left is null || right is null)
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
            return left.Date > right.Date;
        }

        public static bool operator ==(Note left, Note right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }
            if (left is null && right is null)
            {
                return true;
            }
            return left.Date == right.Date && 
                left.Title == right.Title &&
                left.Content == right.Content;
        }
        public static bool operator !=(Note left, Note right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if(obj is null)
            {
                return false;
            }
            if(obj.GetType() != typeof(Note) )
            {
                return false;
            }
            return this == (Note)obj;
        }

        public override int GetHashCode()
        {
            //hash codes will not be used and warnings are annoying
            return 0;
        }
    }
}

