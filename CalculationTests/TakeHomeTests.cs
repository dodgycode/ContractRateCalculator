using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculationTests
{
    [TestClass]
    public class TakeHomeTests
    {
        TestObjects testObjSource = new TestObjects();

        [TestMethod]
        public void TestScenario1()
        {
           var obj= testObjSource.GetTest1();
           var result = obj.TotalIncludingPension;
        }
    }
}
