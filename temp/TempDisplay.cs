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

            DataAccessor dataClass = new DataAccessor();

            Timeline timeLine = new Timeline();

            Console.WriteLine(timeLine.ToString());


        }
    }
}
