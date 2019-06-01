using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace TimelineStructureTest
{
    [TestClass]
    public class TimelineStructureTest
    {
        [TestMethod]
        public void InitializeTimelineTest()
        {
            //arrange
            Timeline timeLine = new Timeline();

            //act
            timeLine.ToString();
            //assert
        }

        [TestMethod]
        public void AddTimelineValidTest()
        {
            //arrange
            Timeline timeLine = new Timeline();

            //act
            timeLine.ToString();
            //assert
        }

        [TestMethod]
        public void AddTimelineInvalidTest()
        {
            //arrange
            Timeline timeLine = new Timeline();
            Time time = new Time(-1, -1);
            Date date = new Date(-1, -2, -3, time);
            Note note = new Note(date, "BBBBB", "CCCCCC");

            //act
            timeLine.ToString();
            //assert
        }
    }
}
