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
            var calculator = new Calculator(new Dependency());

            int result = calculator.Do(0);

            Assert.IsTrue(result == 10);
        }

        [TestMethod]
        public void TestShim()
        {
            var calculator = new Calculator(new Dependency());
            int result = calculator.Do(0);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void TestCurrentYear()
        {
            var calculator = new Calculator(new Dependency());
            int result = calculator.GetCurrentYear();
            Assert.AreEqual(DateTime.Today.Year, result);
        }
    }
}
