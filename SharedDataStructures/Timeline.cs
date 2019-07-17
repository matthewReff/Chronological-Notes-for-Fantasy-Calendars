using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Unit Tests")]

namespace DataStructures
{
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