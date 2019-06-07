using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using DataAccessors;

namespace CSVDataAccessorTests
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

        }
    }
}
