using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace TimelineStructureTest
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
            Timeline timeLine = new Timeline();

            //act

            //assert
        }

        [TestMethod]
        public void AddTimeline_ValidNormalTest()
        {
            //arrange
            Time time = new Time(0, 0);
            Date date = new Date(1, 1, 1, time);
            string headline = "AAAAA";
            string body = "BBBBBBB";
            Note note = new Note(date, headline, body);
            Timeline timeLine = new Timeline();

            //act
            bool succeded = timeLine.Add(note);
            TestContext.WriteLine(note.ToString());

            //assert
            Assert.IsTrue(succeded);
        }

        [TestMethod]
        public void AddTimeline_ValidNoBodyTest()
        {
            //arrange
            Time time = new Time(0, 0);
            Date date = new Date(1, 1, 1, time);
            string headline = "AAAAA";
            string body = "";
            Note note = new Note(date, headline, body);
            Timeline timeLine = new Timeline();

            //act
            bool succeded = timeLine.Add(note);
            TestContext.WriteLine(note.ToString());

            //assert
            Assert.IsTrue(succeded);
        }


        [TestMethod]
        public void AddTimelineInOrder_ValidTest()
        {
            //arrange
            Timeline timeLine = new Timeline();
            Time time1 = new Time(0, 0);
            Date date1 = new Date(1, 1, 1, time1);
            string headline1 = "AAAAAAAAA";
            string body1 = "CCCCCC";
            Note note1 = new Note(date1, headline1, body1);

            Time time2 = new Time(1, 1);
            Date date2 = new Date(1, 1, 1, time2);
            string headline2 = "AAAAA";
            string body2 = "CCCCCC";
            Note note2 = new Note(date2, headline2, body2);

            //act
            timeLine.Add(note1);
            timeLine.Add(note2);
            TestContext.WriteLine(note1.ToString());
            TestContext.WriteLine(note2.ToString());

            //assert
        }

        [TestMethod]
        public void AddTimelineOutOrder_ValidTest()
        {
            //arrange
            Timeline timeLine = new Timeline();
            Time time1 = new Time(0, 0);
            Date date1 = new Date(1, 1, 1, time1);
            string headline1 = "AAAAAAAAA";
            string body1 = "CCCCCC";
            Note note1 = new Note(date1, headline1, body1);

            Time time2 = new Time(1, 1);
            Date date2 = new Date(1, 1, 1, time2);
            string headline2 = "AAAAA";
            string body2 = "CCCCCC";
            Note note2 = new Note(date2, headline2, body2);

            //act
            timeLine.Add(note2);
            timeLine.Add(note1);
            TestContext.WriteLine(note2.ToString());
            TestContext.WriteLine(note1.ToString());

            //assert
        }

        [TestMethod]
        public void AddTimeline_InvalidDateTest()
        {
            //arrange
            Timeline timeLine = new Timeline();
            Time time = new Time(0, 0);
            Date date = new Date(-1, -2, -3, time);
            string headline = "BBBBB";
            string body = "CCCCCC";
            Note note = new Note(date, headline, body);

            //act
            bool succeded = timeLine.Add(note);
            TestContext.WriteLine(note.ToString());


            //assert
            Assert.IsFalse(succeded);
        }

        [TestMethod]
        public void AddTimeline_InvalidTimeTest()
        {
            //arrange
            Timeline timeLine = new Timeline();
            Time time = new Time(0, 0);
            Date date = new Date(-1, -2, -3, time);
            string headline = "BBBBB";
            string body = "CCCCCC";
            Note note = new Note(date, headline, body);


            //act
            bool succeded = timeLine.Add(note);
            TestContext.WriteLine(note.ToString());

            //assert
            Assert.IsFalse(succeded);
        }

        [TestMethod]
        public void AddTimeline_InvalidNoTitleTest()
        {
            //arrange
            Timeline timeLine = new Timeline();
            Time time = new Time(0, 0);
            Date date = new Date(1, 1, 1, time);
            string headline = "";
            string body = "CCCCCC";
            Note note = new Note(date, headline, body);

            //act
            bool succeded = timeLine.Add(note);
            TestContext.WriteLine(note.ToString());

            //assert
            Assert.IsFalse(succeded);
        }
    }
}
