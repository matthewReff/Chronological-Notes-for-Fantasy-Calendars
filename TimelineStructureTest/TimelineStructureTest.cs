using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace TimelineStructureTest
{
    [TestClass]
    public class TimelineStructureTest
    {
        public TestContext TestContext { get; set; }
        private TestContext _testContext;

        #region Build Notes
        Time timeInvalidMinutes;
        Time timeInvalidMHours;
        Time timeValidEarly;
        Time timeValidLate;

        Date dateInvalidTime;
        Date dateInvalidYear;
        Date dateInvalidMonth;
        Date dateInvalidDay;
        Date dateValidEarly;
        Date dateValidLate;

        string titleFull;
        string titleEmpty;

        string bodyFull;
        string bodyEmpty;


        Note noteValidEarly; 
        Note noteValidLate;
        Note noteInvalidTime;
        Note noteInvalidDate;
        Note noteInvalidNoTitle;
        Note noteValidNoBody;


        [TestInitialize]
        public void SetUp()
        { 
            timeInvalidMinutes = new Time(-1, 0);
            timeInvalidMHours = new Time(0, -1);
            timeValidEarly = new Time(0, 0);
            timeValidLate = new Time(1, 1);

            dateInvalidTime = new Date(1, 1, 1, timeInvalidMinutes);
            dateInvalidYear = new Date(-1, 1, 1, timeValidEarly);
            dateInvalidMonth = new Date(1, -1, 1, timeValidEarly);
            dateInvalidDay = new Date(1, 1, -1, timeValidEarly);
            dateValidEarly = new Date(1, 1, 1, timeValidEarly);
            dateValidLate = new Date(2, 2, 2, timeValidEarly);

            titleFull = "NON EMPTY TITLE";
            titleEmpty = string.Empty;

            bodyFull = "NON EMPTY CONTENT";
            bodyEmpty = string.Empty;


            noteValidEarly = new Note(dateValidEarly, titleFull, bodyFull);
            noteValidLate = new Note(dateValidEarly, titleFull, bodyFull);
            noteInvalidTime = new Note(dateInvalidTime, titleFull, bodyFull);
            noteInvalidDate = new Note(dateInvalidYear, titleFull, bodyFull);
            noteInvalidNoTitle = new Note(dateValidEarly, titleEmpty, bodyFull);
            noteValidNoBody = new Note(dateValidEarly, titleFull, bodyEmpty);
        }

        #endregion

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
            Timeline timeLine = new Timeline();

            //act
            bool succeded = timeLine.Add(noteValidEarly);
            TestContext.WriteLine(noteValidEarly.ToString());

            //assert
            Assert.IsTrue(succeded);
        }

        [TestMethod]
        public void AddTimeline_ValidNoBodyTest()
        {
            //arrange
            Timeline timeLine = new Timeline();

            //act
            bool succeded = timeLine.Add(noteValidNoBody);
            TestContext.WriteLine(noteValidNoBody.ToString());

            //assert
            Assert.IsTrue(succeded);
        }


        [TestMethod]
        public void AddTimelineInOrder_ValidTest()
        {
            //arrange
            Timeline timeLine = new Timeline();
            

            //act
            timeLine.Add(noteValidEarly);
            timeLine.Add(noteValidLate);
            TestContext.WriteLine(noteValidEarly.ToString());
            TestContext.WriteLine(noteValidLate.ToString());

            //assert
        }

        [TestMethod]
        public void AddTimelineOutOrder_ValidTest()
        {
            //arrange
            Timeline timeLine = new Timeline();

            //act
            timeLine.Add(noteValidLate);
            timeLine.Add(noteValidEarly);
            TestContext.WriteLine(noteValidLate.ToString());
            TestContext.WriteLine(noteValidEarly.ToString());

            //assert
        }

        [TestMethod]
        public void AddTimeline_InvalidDateTest()
        {
            //arrange
            Timeline timeLine = new Timeline();

            //act
            bool succeded = timeLine.Add(noteInvalidDate);
            TestContext.WriteLine(noteInvalidDate.ToString());


            //assert
            Assert.IsFalse(succeded);
        }

        [TestMethod]
        public void AddTimeline_InvalidTimeTest()
        {
            //arrange
            Timeline timeLine = new Timeline();

            //act
            bool succeded = timeLine.Add(noteInvalidTime);
            TestContext.WriteLine(noteInvalidTime.ToString());

            //assert
            Assert.IsFalse(succeded);
        }

        [TestMethod]
        public void AddTimeline_InvalidNoTitleTest()
        {
            //arrange
            Timeline timeLine = new Timeline();

            //act
            bool succeded = timeLine.Add(noteInvalidNoTitle);
            TestContext.WriteLine(noteInvalidNoTitle.ToString());

            //assert
            Assert.IsFalse(succeded);
        }
    }
}
