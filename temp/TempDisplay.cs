using DataAccessors;
using DataStructures;
using System;
using System.IO;

namespace tempDisplay
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = args[0];
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found");
                return;
            }

            DataAccess dataClass = new DataAccess();
            Time time = new Time(0, 0);
            Date date = new Date(1, 1, 1, time);
            string headline = "AAAAA";
            string body = "BBBBBBB";
            Note note = new Note(date, headline, body);
            Timeline timeLine = new Timeline();

            timeLine.Add(note);

            foreach( Note thing in timeLine)
            {
                Console.WriteLine(thing);
            }


        }
    }
}
