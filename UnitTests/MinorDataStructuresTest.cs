using ChronoCalendar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    class MinorDataStructuresTest
    {
        

        [TestClass]

        public class DateTests
        {
            public TestContext TestContext { get; set; }

            [TestMethod]
            public void ValuedInitializeDate_AllValuesTest ()
            {
                //arrange
                Date date = new Date(1, 1, 1, 0, 0);

                //act
                TestContext.WriteLine(date.ToString());

                //assert
                Assert.IsTrue(date.Year == 1);
                Assert.IsTrue(date.Month == 1 );
                Assert.IsTrue(date.Day == 1 );
                Assert.IsTrue(date.Hour == 0);
                Assert.IsTrue(date.Minute == 0);

            }

            [TestMethod]
            public void ValuedInitializeDate_SomeValuesTest()
            {
                //arrange
                Date date = new Date(1, 1, 1);

                //act
                TestContext.WriteLine(date.ToString());

                //assert
                Assert.IsTrue(date.Day == 1);
                Assert.IsTrue(date.Month == 1);
                Assert.IsTrue(date.Year == 1);
            }

            #region DateCompareNullChecks
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
            public void DateGetHashCodeExists()
            {
                //arrange
                Date date = new Date(1, 1, 1);

                //act

                //assert
                date.GetHashCode();
            }
            #endregion

            #region NoteCompareNullChecks
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

            [TestMethod]
            public void NoteGreaterThanToNull_WillNotCrash()
            {
                //arrange
                Note note1 = new Note(new Date(1, 1, 1), "aaa");
                Note note2 = null;

                //act

                //assert
                Assert.IsTrue(note1 > note2);
            }

            [TestMethod]
            public void NoteLessThanToNull_WillNotCrash()
            {
                //arrange
                Note note1 = new Note(new Date(1, 1, 1), "aaa");
                Note note2 = null;

                //act

                //assert
                Assert.IsFalse(note1 < note2);
            }

            [TestMethod]
            public void NoteGetHashCodeExists()
            {
                //arrange
                Note note = new Note(new Date(1, 1, 1), "aaa");

                //act

                //assert
                note.GetHashCode();
            }
            #endregion
        }
    }
}
