﻿using DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace DataAccessors
{
    public class DataAccessor
    {

        #region Properties

        private string _filePath;

        string FilePath
        {
            get
            {
                return _filePath;
            }
        }

        #endregion

        public DataAccessor(string filePath)
        {
            _filePath = filePath;
            
        }

        public bool SaveTimeline(Timeline timeline)
        {

            XmlWriter writer = XmlWriter.Create(FilePath);
            writer.WriteStartElement("Timeline");

            foreach (Note thing in timeline)
            {
                writer.WriteStartElement("note");

                writer.WriteStartElement("date");
                string XmlDateString = DateToPeriodSeperatedString(thing.Date);
                writer.WriteString(XmlDateString);
                writer.WriteEndElement();

                writer.WriteStartElement("title");
                writer.WriteString(thing.Title);
                writer.WriteEndElement();

                writer.WriteStartElement("body");
                writer.WriteString(thing.Content);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Close();

            return true;
        }

        public bool LoadTimeline(out Timeline timeline)
        {
            CreateBaseFileIfMissing();

            timeline = new Timeline();

            XmlReader reader;
            XmlReaderSettings settings = new XmlReaderSettings();
            XmlDocument doc = new XmlDocument();
            //XmlSchema schema = getSchema();

            //settings.Schemas.Add(schema);

            //reader = XmlReader.Create(FilePath, settings);

            reader = XmlReader.Create(FilePath);

            doc.Load(reader);

            //doc.Validate

            XmlNode root = doc.FirstChild;
            root = root.NextSibling;

            foreach (XmlNode noteNode in root.ChildNodes)
            {
                timeline.Add(ParseXmlNodeToNote(noteNode));
            }

            reader.Close();
            return true;
        }

        public XmlSchema getSchema()
        {
            XmlSchemaSet xs = new XmlSchemaSet();
            XmlSchema schema;

            schema = xs.Add("", "");

            return schema;
        }

        public Note ParseXmlNodeToNote(XmlNode noteNode)
        {
            List<string> nodeContents = new List<string>();

            for (int i = 0; i < noteNode.ChildNodes.Count; i++)
            {
                nodeContents.Add(noteNode.ChildNodes[i].InnerText);
            }

            Date convertedDate = DataAccessor.PeriodSeperatedStringToDate(nodeContents[0]);
            

            return new Note(convertedDate, nodeContents[1], nodeContents[2]);
        }

        
        public static Date PeriodSeperatedStringToDate(string dateString)
        {
            string[] splitDateTime = dateString.Split('.');
            int year;
            int month;
            int day;
            int? hour;
            int? minute;
            int numArguments = splitDateTime.Length;
            if(numArguments != 3 && numArguments != 5)
            {
                throw new Exception("Malformed date in conversion");
            }
            year = int.Parse(splitDateTime[0]);
            month = int.Parse(splitDateTime[1]);
            day = int.Parse(splitDateTime[2]);
            if (numArguments != 3)
            {
                hour = int.Parse(splitDateTime[3]);
                minute = int.Parse(splitDateTime[4]);
            }
            else
            {
                hour = null;
                minute = null;
            }

            return new Date(year, month, day, hour, minute);
        }

        public static string DateToPeriodSeperatedString(Date date)
        {
            string dateString = string.Empty;
            dateString += date.year.ToString();
            dateString += ".";
            dateString += date.month.ToString();
            dateString += ".";
            dateString += date.day.ToString();
            if (date.hour != null)
            {
                dateString += ".";
                dateString += date.hour.ToString();
            }
            if (date.minute != null)
            {
                dateString += ".";
                dateString += date.minute.ToString();
            }

            return dateString;
        }

        private bool CreateBaseFileIfMissing()
        {
            if (!File.Exists(FilePath))
            {
                try
                {
                    FileStream newFile = File.Create(FilePath);
                    newFile.Close();
                    SaveTimeline(new Timeline());
                }
                catch (UnauthorizedAccessException e)
                {
                    throw new Exception(); //todo
                }
            }

            return true;
        }

    }
}
