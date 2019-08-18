using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using ChronoCalendar;

namespace tempDisplay
{
    class Program
    {
        static void Main()
        {
            string filePath = Console.ReadLine();

            DataAccessor dataAccessor1 = new DataAccessor(filePath);

            Timeline timeline = new Timeline();
            dataAccessor1.LoadTimeline(out timeline);
            dataAccessor1.SaveTimeline(timeline);
            Console.WriteLine(timeline.ToString());

            return;
        }
    }
}
