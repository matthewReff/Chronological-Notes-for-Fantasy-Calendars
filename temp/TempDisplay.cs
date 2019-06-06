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

            Time time2 = new Time(1, 0);
            Date date2 = new Date(1, 1, 1, time2);
            string headline2 = "AAAAA";
            string body2 = "BBBBBBB";
            Note note2 = new Note(date2, headline2, body2);

            Timeline timeLine = new Timeline();

            timeLine.Add(note2);
            timeLine.Add(note);


            Console.WriteLine(timeLine.ToString());


        }
    }
}
