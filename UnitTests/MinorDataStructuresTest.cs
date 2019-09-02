using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChronoCalendar;

namespace UnitTests
{
    class MinorDataStructuresTest
    {
        

        [TestClass]

        public class DateTests
        {
            public TestContext TestContext { get; set; }
            private TestContext _testContext;

            [TestMethod]
            public void ValuedInitializeDate_AllValuesTest ()
            {
                //arrange
                Date date = new Date(1, 1, 1, 0, 0);

                //act
                TestContext.WriteLine(date.ToString());

                //assert
                Assert.IsTrue(date.year == 1);
                Assert.IsTrue(date.month == 1 );
                Assert.IsTrue(date.day == 1 );
                Assert.IsTrue(date.hour == 0);
                Assert.IsTrue(date.minute == 0);

            }

            [TestMethod]
            public void ValuedInitializeDate_SomeValuesTest()
            {
                //arrange
                Date date = new Date(1, 1, 1);

                //act
                TestContext.WriteLine(date.ToString());

                //assert
                Assert.IsTrue(date.day == 1);
                Assert.IsTrue(date.month == 1);
                Assert.IsTrue(date.year == 1);
            }

            [TestMethod]
            public void DateEqualsToNull_WillNotCrash()
            {
                //arrange
                Date date1 = new Date(1, 1, 1);
                Date date2 = null;

                //act

                //assert
                Assert.IsFalse(date1 == date2);
            }

            [TestMethod]
            public void DateNotEqualToNull_WillNotCrash()
            {
                //arrange
                Date date1 = new Date(1, 1, 1);
                Date date2 = null;

                //act

                //assert
                Assert.IsTrue(date1 != date2);
            }

            [TestMethod]
            public void DateGreaterThanToNull_WillNotCrash()
            {
                //arrange
                Date date1 = new Date(1, 1, 1);
                Date date2 = null;

                //act

                //assert
                Assert.IsTrue(date1 > date2);
            }

            [TestMethod]
            public void DateLessThanToNull_WillNotCrash()
            {
                //arrange
                Date date1 = new Date(1, 1, 1);
                Date date2 = null;

                //act

                //assert
                Assert.IsFalse(date1 < date2);
            }
            [TestMethod]
            public void NoteEqualsToNull_WillNotCrash()
            {
                //arrange
                Note note1 = new Note(new Date(1, 1, 1), "aaa");
                Note note2 = null;

                //act

                //assert
                Assert.IsFalse(note1 == note2);
            }

            [TestMethod]
            public void NoteNotEqualToNull_WillNotCrash()
            {
                //arrange
                Note note1 = new Note(new Date(1, 1, 1), "aaa");
                Note note2 = null;

                //act

                //assert
                Assert.IsTrue(note1 != note2);
            }
        }

    }
}
