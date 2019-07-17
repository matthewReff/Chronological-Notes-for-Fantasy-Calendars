using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace TimelineStructuresTests
{
    [TestClass]
    public class TimelineStructureTest
    {
        public TestContext TestContext { get; set; }
        private TestContext _testContext;

        #region Construct Notes

        Date dateInvalidTime;
        Date dateInvalidYear;
        Date dateInvalidMonth;
        Date dateInvalidDay;
        Date dateValidEarly;
        Date dateValidEarlyShort;
        Date dateValidMiddle;
        Date dateValidLate;

        string titleFull;
        string titleEmpty;

        string bodyFull;
        string bodyEmpty;


        Note noteValidEarly; 
        Note noteValidMiddle;
        Note noteValidLate;
        Note noteInvalidTime;
        Note noteInvalidDate;
        Note noteInvalidNoTitle;
        Note noteValidNoBody;
        Note noteValidShortDate;

        [TestInitialize]
        public void SetUp()
        { 
            dateInvalidTime = new Date(1, 1, 1, -1, 0);
            dateInvalidYear = new Date(-1, 1, 1, 0, 0);
            dateInvalidMonth = new Date(1, -1, 1, 0, 0);
            dateInvalidDay = new Date(1, 1, -1, 0, 0);
            dateValidEarly = new Date(1, 1, 1, 0, 0);
            dateValidEarlyShort = new Date(1, 1, 1);
            dateValidMiddle = new Date(2, 2, 2, 0, 0);
            dateValidLate = new Date(3, 3, 3, 0, 0);

            titleFull = "NON EMPTY TITLE";
            titleEmpty = string.Empty;

            bodyFull = "NON EMPTY CONTENT";
            bodyEmpty = string.Empty;


            noteValidEarly = new Note(dateValidEarly, titleFull, bodyFull);
            noteValidMiddle = new Note(dateValidMiddle, titleFull, bodyFull);
            noteValidLate = new Note(dateValidLate, titleFull, bodyFull);
            noteInvalidTime = new Note(dateInvalidTime, titleFull, bodyFull);
            noteInvalidDate = new Note(dateInvalidYear, titleFull, bodyFull);
            noteInvalidNoTitle = new Note(dateValidEarly, titleEmpty, bodyFull);
            noteValidNoBody = new Note(dateValidEarly, titleFull, bodyEmpty);
            noteValidShortDate = new Note(dateValidEarlyShort, titleFull, bodyFull);

        }

        #endregion

        [TestMethod]
        public void InitializeTimelineTest()
        {
            //arrange
            Timeline timeline = new Timeline();

            //act

            //assert
        }

        #region Add Tests

        [TestMethod]

        public void AddTimeline_ValidNormalTest()
        {
            //arrange
            Timeline timeline = new Timeline();

            //act
            bool succeded = timeline.Add(noteValidEarly);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.IsTrue(succeded);
        }

        [TestMethod]
        public void AddTimeline_ValidNoBodyTest()
        {
            //arrange
            Timeline timeline = new Timeline();

            //act
            bool succeded = timeline.Add(noteValidNoBody);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.IsTrue(succeded);
            Assert.AreEqual(1, timeline.Count);

        }

        [TestMethod]
        public void AddTimeline_ValidShortDateTest()
        {
            //arrange
            Timeline timeline = new Timeline();

            //act
            bool succeded = timeline.Add(noteValidShortDate);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.AreEqual(1, timeline.Count);
            Assert.IsTrue(succeded);
        }

        [TestMethod]
        public void AddTimeline_InsertFront_ValidTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            Note[] expected = new Note[] { noteValidEarly, noteValidMiddle } ;
            Note[] actual = new Note[2];

            //act
            timeline.Add(noteValidMiddle);
            timeline.Add(noteValidEarly);
            TestContext.WriteLine(timeline.ToString());


            //assert
            timeline.CopyTo(actual, 0);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTimeline_InsertBack_ValidTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            Note[] expected = new Note[] { noteValidMiddle, noteValidLate };
            Note[] actual = new Note[2];
            //act
            timeline.Add(noteValidMiddle);
            timeline.Add(noteValidLate);
            TestContext.WriteLine(timeline.ToString());


            //assert
            timeline.CopyTo(actual, 0);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTimeline3NotesType1_ValidTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            Note[] expected = new Note[] { noteValidEarly, noteValidMiddle, noteValidLate};
            Note[] actual = new Note[3];

            //act
            timeline.Add(noteValidEarly);
            timeline.Add(noteValidLate);
            timeline.Add(noteValidMiddle);
            TestContext.WriteLine(timeline.ToString());


            //assert
            timeline.CopyTo(actual, 0);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTimeline3NotesType2_ValidTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            Note[] expected = new Note[] { noteValidEarly, noteValidMiddle, noteValidLate };
            Note[] actual = new Note[3];

            //act
            timeline.Add(noteValidMiddle);
            timeline.Add(noteValidEarly);
            timeline.Add(noteValidLate);
            TestContext.WriteLine(timeline.ToString());


            //assert
            timeline.CopyTo(actual, 0);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTimelineMixedValid_ValidTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            
            //act
            timeline.Add(noteInvalidDate);
            timeline.Add(noteValidEarly);
            TestContext.WriteLine(timeline.ToString());


            //assert
            Assert.AreEqual(1, timeline.Count);
        }

        

        [TestMethod]
        public void AddTimeline_InvalidDateTest()
        {
            //arrange
            Timeline timeline = new Timeline();

            //act
            bool succeded = timeline.Add(noteInvalidDate);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.IsFalse(succeded);
        }

        [TestMethod]
        public void AddTimeline_InvalidTimeTest()
        {
            //arrange
            Timeline timeline = new Timeline();

            //act
            bool succeded = timeline.Add(noteInvalidTime);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.IsFalse(succeded);
        }

        [TestMethod]
        public void AddTimeline_InvalidNoTitleTest()
        {
            //arrange
            Timeline timeline = new Timeline();

            //act
            bool succeded = timeline.Add(noteInvalidNoTitle);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.IsFalse(succeded);
        }
        #endregion

        #region Remove Tests

        [TestMethod]
        public void RemoveTimeline_InvalidEmptyTimlineTest()
        {
            //arrange
            Timeline timeline = new Timeline();

            //act
            bool succeded = timeline.Remove(noteValidEarly);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.IsFalse(succeded);
        }

        [TestMethod]
        public void RemoveTimeline_ValidPresentNoteTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            timeline.Add(noteValidEarly);

            //act
            bool succeded = timeline.Remove(noteValidEarly);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.IsTrue(succeded);
        }

        [TestMethod]
        public void RemoveTimeline_UpdateCountSuccessTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            timeline.Add(noteValidEarly);

            //assert
            Assert.AreEqual(1, timeline.Count);

            //act
            timeline.Remove(noteValidEarly);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.AreEqual(0, timeline.Count);
        }

        [TestMethod]
        public void RemoveTimeline_RemoveDuplicatesTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            timeline.Add(noteValidEarly);
            timeline.Add(noteValidEarly);

            //act
            bool succeded = timeline.Remove(noteValidEarly);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.IsTrue(succeded);
            Assert.AreEqual(1, timeline.Count);
        }

        [TestMethod]
        public void RemoveTimeline_UpdateCountNoRemovalTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            timeline.Add(noteValidEarly);

            //assert
            Assert.AreEqual(1, timeline.Count);

            //act
            timeline.Remove(noteValidMiddle);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.AreEqual(1, timeline.Count);
        }

        [TestMethod]
        public void RemoveTimeline_InvalidNotPresentNoteTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            timeline.Add(noteValidEarly);

            //act
            bool succeded = timeline.Remove(noteValidMiddle);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.IsFalse(succeded);
        }

        #endregion

        #region Find Tests
        [TestMethod]
        public void FindTimeline_ValidNoteTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            timeline.Add(noteValidEarly);
            LinkedListNode<Note> foundNode = null;

            //act
            foundNode = timeline.Find(noteValidEarly);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.AreNotEqual(null, foundNode);
        }

        public void FindTimeline_InvalidNoteTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            timeline.Add(noteValidEarly);
            LinkedListNode<Note> foundNode = null;

            //act
            foundNode = timeline.Find(noteValidMiddle);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.AreEqual(null, foundNode);
        }
        #endregion
    }


}
