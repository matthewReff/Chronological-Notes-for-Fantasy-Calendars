using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using ChronoCalendar;

namespace UnitTests
{
    [TestClass]
    public class TimelineStructureTest
    {
        public TestContext TestContext { get; set; }
        private TestContext _testContext;

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
            bool succeded = timeline.Add(TestingObjects.NoteValidEarly);
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
            bool succeded = timeline.Add(TestingObjects.NoteValidNoBody);
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
            bool succeded = timeline.Add(TestingObjects.NoteValidLateShortDate);
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
            Note[] expected = new Note[] { TestingObjects.NoteValidEarly, TestingObjects.NoteValidMiddle } ;
            Note[] actual = new Note[2];

            //act
            timeline.Add(TestingObjects.NoteValidMiddle);
            timeline.Add(TestingObjects.NoteValidEarly);
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
            Note[] expected = new Note[] { TestingObjects.NoteValidMiddle, TestingObjects.NoteValidLate };
            Note[] actual = new Note[2];

            //act
            timeline.Add(TestingObjects.NoteValidMiddle);
            timeline.Add(TestingObjects.NoteValidLate);
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
            Note[] expected = new Note[] { TestingObjects.NoteValidEarly, TestingObjects.NoteValidMiddle, TestingObjects.NoteValidLate };
            Note[] actual = new Note[3];

            //act
            timeline.Add(TestingObjects.NoteValidEarly);
            timeline.Add(TestingObjects.NoteValidLate);
            timeline.Add(TestingObjects.NoteValidMiddle);
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
            Note[] expected = new Note[] { TestingObjects.NoteValidEarly, TestingObjects.NoteValidMiddle, TestingObjects.NoteValidLate };
            Note[] actual = new Note[3];

            //act
            timeline.Add(TestingObjects.NoteValidMiddle);
            timeline.Add(TestingObjects.NoteValidEarly);
            timeline.Add(TestingObjects.NoteValidLate);
            TestContext.WriteLine(timeline.ToString());


            //assert
            timeline.CopyTo(actual, 0);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTimeline2NotesMinuteOFf_ValidTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            Note[] expected = new Note[] { TestingObjects.NoteValidMiddle, TestingObjects.NoteValidOffMiddle };
            Note[] actual = new Note[2];

            //act
            timeline.Add(TestingObjects.NoteValidMiddle);
            timeline.Add(TestingObjects.NoteValidOffMiddle);
            TestContext.WriteLine(timeline.ToString());


            //assert
            timeline.CopyTo(actual, 0);
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void AddTimelineMixedDateTypes_HoldCorrectOrder()
        {
            //arrange
            Timeline timeline = new Timeline();
            Note[] expected = new Note[] { TestingObjects.NoteValidLateShortDate, TestingObjects.NoteValidLate };
            Note[] actual = new Note[2];

            //act
            timeline.Add(TestingObjects.NoteValidLateShortDate);
            timeline.Add(TestingObjects.NoteValidLate);
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
            timeline.Add(TestingObjects.NoteInvalidDate);
            timeline.Add(TestingObjects.NoteValidEarly);
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
            bool succeded = timeline.Add(TestingObjects.NoteInvalidDate);
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
            bool succeded = timeline.Add(TestingObjects.NoteInvalidTime);
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
            bool succeded = timeline.Add(TestingObjects.NoteInvalidNoTitle);
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
            bool succeded = timeline.Remove(TestingObjects.NoteValidEarly);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.IsFalse(succeded);
        }

        [TestMethod]
        public void RemoveTimeline_ValidPresentNoteTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            timeline.Add(TestingObjects.NoteValidEarly);

            //act
            bool succeded = timeline.Remove(TestingObjects.NoteValidEarly);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.IsTrue(succeded);
        }

        [TestMethod]
        public void RemoveTimeline_UpdateCountSuccessTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            timeline.Add(TestingObjects.NoteValidEarly);

            //assert
            Assert.AreEqual(1, timeline.Count);

            //act
            timeline.Remove(TestingObjects.NoteValidEarly);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.AreEqual(0, timeline.Count);
        }

        [TestMethod]
        public void RemoveTimeline_RemoveDuplicatesTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            timeline.Add(TestingObjects.NoteValidEarly);
            timeline.Add(TestingObjects.NoteValidEarly);

            //act
            bool succeded = timeline.Remove(TestingObjects.NoteValidEarly);
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
            timeline.Add(TestingObjects.NoteValidEarly);

            //assert
            Assert.AreEqual(1, timeline.Count);

            //act
            timeline.Remove(TestingObjects.NoteValidMiddle);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.AreEqual(1, timeline.Count);
        }

        [TestMethod]
        public void RemoveTimeline_InvalidNotPresentNoteTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            timeline.Add(TestingObjects.NoteValidEarly);

            //act
            bool succeded = timeline.Remove(TestingObjects.NoteValidMiddle);
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
            timeline.Add(TestingObjects.NoteValidEarly);
            LinkedListNode<Note> foundNode = null;

            //act
            foundNode = timeline.Find(TestingObjects.NoteValidEarly);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.AreNotEqual(null, foundNode);
        }

        public void FindTimeline_InvalidNoteTest()
        {
            //arrange
            Timeline timeline = new Timeline();
            timeline.Add(TestingObjects.NoteValidEarly);
            LinkedListNode<Note> foundNode = null;

            //act
            foundNode = timeline.Find(TestingObjects.NoteValidMiddle);
            TestContext.WriteLine(timeline.ToString());

            //assert
            Assert.AreEqual(null, foundNode);
        }
        #endregion
    }


}
