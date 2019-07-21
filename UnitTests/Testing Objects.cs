﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using DataAccessors;
using System.Reflection;
using System.IO;
using System;

namespace Tests
{
    public static class TestingObjects
    {

        static Date dateInvalidTime = new Date(1, 1, 1, -1, 0);
        static Date dateInvalidYear = new Date(-1, 1, 1, 0, 0);
        static Date dateInvalidMonth = new Date(1, -1, 1, 0, 0);
        static Date dateInvalidDay = new Date(1, 1, -1, 0, 0);
        static Date dateValidEarly = new Date(1, 1, 1, 0, 0);
        static Date dateValidEarlyShort = new Date(1, 1, 1);
        static Date dateValidMiddle = new Date(2, 2, 2, 0, 0);
        static Date dateValidLate = new Date(3, 3, 3, 0, 0);

        static string titleFull = "NON EMPTY TITLE";
        static string titleEmpty = string.Empty;

        static string bodyFull = "NON EMPTY CONTENT";
        static string bodyEmpty = string.Empty;


        public static Note NoteValidEarly
        {
            get { return new Note(dateValidEarly, titleFull, bodyFull); }
        }
        public static Note NoteValidMiddle
        {
            get { return new Note(dateValidMiddle, titleFull, bodyFull); }
        }
        public static Note NoteValidLate
        {
            get { return new Note(dateValidLate, titleFull, bodyFull); }
        }
        public static Note NoteInvalidTime
        {
            get { return new Note(dateInvalidTime, titleFull, bodyFull); }
        }
        public static Note NoteInvalidDate
        {
            get { return new Note(dateInvalidYear, titleFull, bodyFull); }
        }
        public static Note NoteInvalidNoTitle
        {
            get { return new Note(dateValidEarly, titleEmpty, bodyFull); }
        }
        public static Note NoteValidNoBody
        {
            get { return new Note(dateValidEarly, titleFull, bodyEmpty); }
        }
        public static Note NoteValidShortDate
        {
            get { return new Note(dateValidEarlyShort, titleFull, bodyFull); }
        }
    }
}
