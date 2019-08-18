using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;
using System;
using ChronoCalendar;

namespace UnitTests
{
    class XMLDataAccessorTest
    {

        [TestClass]

        public class XMLDataAccessorTests
        {
            public TestContext TestContext { get; set; }
            private TestContext _testContext;

            [TestMethod]
            public void DataAccessorExists_Test()
            {
                //arrange
                DataAccessor dataAccessor = new DataAccessor("DummyPath");

                //act

                //assert
               
            }

            
            [TestMethod]
            public void DataAccessorCanLoad_Test()
            {
                //arrange
                string testProjectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
                string testFileFolder = Path.Combine(testProjectDirectory, "XML_Test_Files");
                string specificTestFile = Path.Combine(testFileFolder, "validNormalTestData.xml");
                DataAccessor dataAccessor = new DataAccessor(specificTestFile);

                Timeline timeline = new Timeline();

                //act
                dataAccessor.LoadTimeline(out timeline);

                //assert
                Assert.AreEqual(timeline.Count, 3);
            }

            [TestMethod]
            public void DataAccessorLoadsCorrectData_Test()
            {
                //arrange
                string testProjectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
                string testFileFolder = Path.Combine(testProjectDirectory, "XML_Test_Files");
                string specificTestFile = Path.Combine(testFileFolder, "testingObjectsData.xml");
                DataAccessor dataAccessor = new DataAccessor(specificTestFile);
                Note[] expected = new Note[] {
                    TestingObjects.NoteValidEarlyShortDate,
                    TestingObjects.NoteValidEarly,
                    TestingObjects.NoteValidLateShortDate,
                    TestingObjects.NoteValidLate };

                Note[] actual = new Note[4];

                Timeline timeline = new Timeline();

                //act
                dataAccessor.LoadTimeline(out timeline);
                timeline.CopyTo(actual, 0);

                //assert
                CollectionAssert.AreEqual(expected, actual);
            }
        }
    }
}
