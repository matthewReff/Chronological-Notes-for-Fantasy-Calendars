using System;

namespace DataStructures
{
    class Note
    {
        Date date;
        string title;
        string content;
        public Note()
        {
            date = new Date();
            string title = string.Empty;
            string content = string.Empty;
        }

        public Note(Date _date, string _title, string _content)
        {
            date = _date;
            title = _title;
            content = _content;
        }
    }

    class Date
    {
        int day;
        int month;
        int year;
        public Date()
        {
            day = int.MaxValue;
            month = int.MaxValue;
            year = int.MaxValue;
        }

        public Date(int _day, int _month, int _year)
        {
            day = _day;
            month = _month;
            year = _year;
        }
    }
}
