using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using DataAccessors;
using System.Reflection;
using System.IO;

namespace CSVDataAccessorTests
{
    class XMLDataAccessorTest
    {

        [TestClass]

        public class XMLDataAccessorTests
        {
            public TestContext TestContext { get; set; }
            private TestContext _testContext;
            Assembly asm = Assembly.GetExecutingAssembly();

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
                Stream stream = asm.GetManifestResourceStream(@"XML_Test_Files\validNormalTestData.xml");
                StreamReader reader = new StreamReader(stream);
                string file = reader.ReadToEnd();
                DataAccessor dataAccessor = new DataAccessor(file);
                Timeline timeline = new Timeline();

                //act
                dataAccessor.LoadTimeline(out timeline);

                //assert

            }
        }
    }
}
