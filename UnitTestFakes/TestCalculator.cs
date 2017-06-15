using System;
using System.Runtime.Remoting.Messaging;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFakes;

namespace UnitTestFakes
{
    [TestClass]
    public class TestCalculator
    {
        [TestMethod]
        public void TestStub()
        {
            IDependency fakeDependency = new TestFakes.Fakes.StubIDependency()
            {
                DoInt32 = (start)=> start
            };
            var calculator = new Calculator(fakeDependency);

            int result = calculator.Do(10);

            Assert.IsTrue(result == 10);
        }

        [TestMethod]
        public void TestShim()
        {
            using (ShimsContext.Create())
            {
                TestFakes.Fakes.ShimDependency.CountGet = () => { return 1; };

                var calculator = new Calculator(new Dependency());
                int result = calculator.Do(0);
                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void TestCurrentYear()
        {
            int fixedYear = 2000;

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.TodayGet =
                () =>
                { return new DateTime(fixedYear, 1, 1); };

                var calculator = new Calculator(new Dependency());
                int result = calculator.GetCurrentYear();
                Assert.AreEqual(fixedYear, result);
            }
        }
    }
}
