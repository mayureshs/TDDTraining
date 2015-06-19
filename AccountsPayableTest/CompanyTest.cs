using AccountsPayable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AccountsPayableTest
{
    [TestClass]
    public class CompanyTest
    {
        private Company _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new Company("Acme", "75-1234567");
        }

        [TestMethod]
        public void CanGetCompanyName()
        {
            Assert.AreEqual("Acme", _sut.Name);
        }

        [TestMethod]
        public void CanGetCompanyTaxId()
        {
            Assert.AreEqual("75-1234567", _sut.TaxId);
        }

        [TestMethod]
        public void CanGetCompanyPay()
        {
            Assert.AreEqual(0, _sut.Pay());
        }

        [TestMethod]
        public void CanGetCompanyHire()
        {
            _sut.Hire(new Employee("Hank","Hill","123-45-6789", 100));
            _sut.Hire(new Employee("Peggy", "Hill", "123-45-6700", 100));
            Assert.AreEqual(2, _sut.Employees.Count());
        }

        [TestMethod]
        public void CanGetEmployeePay()
        {
            _sut.Hire(new Employee("Hank","Hill","123-45-6789", 100));
            _sut.Hire(new Employee("Peggy", "Hill", "123-45-6700", 100));
            Assert.AreEqual(184.70, _sut.Pay(), .001);
        }
    }
}