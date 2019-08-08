using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Unit Tests")]

namespace DataStructures
{
    public partial class Timeline : IEnumerable, ICollection, INotifyCollectionChanged
    {
        Timeline GetNotesFromDay(Date date)
        {
            Timeline returnTimeline = new Timeline();

            foreach(Note note in _timelineList)
            {
                if(date.year == note.Date.year && 
                    date.month == note.Date.month && 
                    date.day == note.Date.day)
                {
                    returnTimeline.Add(note);
                }
            }
            return new Timeline();
        }
    }
}