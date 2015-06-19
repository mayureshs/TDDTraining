using AccountsPayable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AccountsPayableTest
{
    [TestClass]
    public class CalculatorTest
    {
        private Calculator _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new Calculator();
            var m = new Mock<IAdder>();
            m.Setup(a => a.Add(4, 5)).Returns(10);
            _sut.AddingMachine = m.Object;
        }

        [TestMethod]
        public void CanAddNumbers()
        {
            Assert.AreEqual(10, _sut.ComputeSum(4, 5));
        }
    }
}