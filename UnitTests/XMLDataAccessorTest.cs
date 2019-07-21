using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using DataAccessors;
using System.Reflection;
using System.IO;
using System;

namespace Tests
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

            
            [TestMethod]
            public void DataAccessorLoad_Test()
            {
                //arrange
                string testProjectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
                string testFileFolder = Path.Combine(testProjectDirectory, "XML_Test_Files");
                string specificTestFile = Path.Combine(testFileFolder, "validNormalTestData.xml");
                DataAccessor dataAccessor = new DataAccessor(specificTestFile);

                Timeline timeline = new Timeline();

                //act
                dataAccessor.LoadTimeline(out timeline);

                //assert
                Assert.AreEqual(timeline.Count, 3);
            }
            
        }
    }
}
