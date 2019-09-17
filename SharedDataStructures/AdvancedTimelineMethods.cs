using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Unit Tests")]

namespace ChronoCalendar
{
    public partial class Timeline : IEnumerable, ICollection, INotifyCollectionChanged
    {
        public Timeline GetNotesFromDay(Date date)
        {
            Timeline returnTimeline = new Timeline();

            foreach(Note note in _timelineList)
            {
                if(date.Year == note.Date.Year && 
                    date.Month == note.Date.Month && 
                    date.Day == note.Date.Day)
                {
                    returnTimeline.Add(note);
                }
            }
            return returnTimeline;
        }
    }
}