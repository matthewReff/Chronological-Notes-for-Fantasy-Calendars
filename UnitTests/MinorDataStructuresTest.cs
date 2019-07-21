using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace Tests
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
        }

    }
}
