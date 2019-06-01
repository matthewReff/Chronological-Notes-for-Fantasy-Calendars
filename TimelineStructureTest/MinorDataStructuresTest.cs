using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace TimelineStructureTest
{
    class MinorDataStructuresTest
    {
        

        [TestClass]

        public class DateTests
        {
            public TestContext TestContext { get; set; }
            private TestContext _testContext;

            [TestMethod]
            public void BlankInitializeTime_InvalidValues()
            {
                //arrange
                Time time = new Time();

                //act
                TestContext.WriteLine(time.ToString());

                //assert
                Assert.IsTrue(time.hours < 0 || time.hours == int.MaxValue);
                Assert.IsTrue(time.minutes < 0 || time.minutes == int.MaxValue);
            }

            [TestMethod]
            public void ValuedInitializeTime_ValidValues()
            {
                //arrange
                Time time = new Time(0, 0);

                //act
                TestContext.WriteLine(time.ToString());

                //assert
                Assert.IsTrue(time.hours == 0);
                Assert.IsTrue(time.minutes == 0);
            }

            [TestMethod]
            public void BlankInitializeDate_InvalidValues()
            {
                //arrange
                Date date = new Date();

                //act
                TestContext.WriteLine(date.ToString());

                //assert
                Assert.IsTrue(date.day < 0 || date.day == int.MaxValue);
                Assert.IsTrue(date.month < 0 || date.month == int.MaxValue);
                Assert.IsTrue(date.year < 0 || date.year == int.MaxValue);
            }

            [TestMethod]
            public void ValuedInitializeDate_ValidValues()
            {
                //arrange
                Time time = new Time(0, 0);
                Date date = new Date(1, 1, 1, time);

                //act
                TestContext.WriteLine(date.ToString());

                //assert
                Assert.IsTrue(date.day == 1);
                Assert.IsTrue(date.month == 1 );
                Assert.IsTrue(date.year == 1 );
            }
        }
    }
}
