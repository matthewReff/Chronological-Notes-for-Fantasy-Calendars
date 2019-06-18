using DataStructures;
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
                string XmlDateString = DateToPeriodSeperatedString(thing.date);
                writer.WriteString(XmlDateString);
                writer.WriteEndElement();

                writer.WriteStartElement("title");
                writer.WriteString(thing.title);
                writer.WriteEndElement();

                writer.WriteStartElement("body");
                writer.WriteString(thing.content);
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
            XmlSchema schema = getSchema();

            settings.Schemas.Add(schema);

            reader = XmlReader.Create(FilePath, settings);

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
            Note generatedNote = new Note();
            Date tempDate = new Date();
            Time tempTime = new Time();
            List<string> nodeContents = new List<string>();

            for (int i = 0; i < noteNode.ChildNodes.Count; i++)
            {
                nodeContents.Add(noteNode.ChildNodes[i].InnerText);
            }

            string[] splitDateTime = nodeContents[0].Split('.');
            int year = int.Parse(splitDateTime[0]);
            int month = int.Parse(splitDateTime[1]);
            int day = int.Parse(splitDateTime[2]);
            int hours = int.Parse(splitDateTime[3]);
            int minutes = int.Parse(splitDateTime[4]);
            tempTime = new Time(hours, minutes);
            tempDate = new Date(year, month, day, tempTime);

            generatedNote.date = tempDate;
            generatedNote.title = nodeContents[1];
            generatedNote.content = nodeContents[2];

            return generatedNote;
        }

        private string DateToPeriodSeperatedString(Date date)
        {
            string returnString = String.Empty;

            returnString += date.year.ToString();
            returnString += ".";
            returnString += date.month.ToString();
            returnString += ".";
            returnString += date.day.ToString();
            returnString += ".";
            returnString += date.time.hours.ToString();
            returnString += ".";
            returnString += date.time.minutes.ToString();

            return returnString;
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
