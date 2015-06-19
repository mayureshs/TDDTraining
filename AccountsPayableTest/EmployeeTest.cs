using System;
using AccountsPayable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace AccountsPayableTest
{
    [TestClass]
    public class EmployeeTest
    {
        private const string EFNAME = "Ronald";
        private const string ELNAME = "McDonald";
        private const string TID = "123-45-6789";
        private const int ESALARY = 100;
        private Employee _emp;

        [TestInitialize]
        public void Setup()
        {
            _emp = new Employee (EFNAME, ELNAME, TID, ESALARY);
        }

        [TestMethod]
        public void CanGetFirstName()
        {
            Assert.AreEqual(EFNAME, _emp.FirstName);
        }

        [TestMethod]
        public void CanGetLastName()
        {
           Assert.AreEqual(ELNAME, _emp.LastName);
        }

        [TestMethod]
        public void CanGetFullName()
        {
            Assert.AreEqual("McDonald, Ronald", _emp.FullName);
        }

        [TestMethod]
        public void CanGetTaxId()
        {
            Assert.AreEqual(TID, _emp.TaxId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CanNotSetNullFirstName()
        {
            _emp.FirstName = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CanNotSetNullLastName()
        {
            _emp.LastName = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CanNotSetNullTaxId()
        {
            _emp.TaxId = null;
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CanNotSetInvalidFirstName()
        {
            _emp.FirstName = "Mayur$esh";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CanNotSetInvalidLastName()
        {
            _emp.LastName = "Sawarde%kar";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CanNotSetInvalidTaxId()
        {
            _emp.TaxId = "45-fg-3233";
        }

        [TestMethod]
        public void CanGetSalary()
        {
            _emp.Salary = ESALARY;
            Assert.AreEqual(100.0, _emp.Salary, .001);
        }

        public TestContext TestContext { get; set; }

        [DataSource("System.Data.SqlClient",
            @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\_Code\TDDTraining\Database\EmployeeData.mdf;Integrated Security=True;Connect Timeout=30",
            "PayData", DataAccessMethod.Sequential
            )]
        [TestMethod]
        public void TestEmployeePay()
        {
            float gross = (float) (double) TestContext.DataRow["Gross"];
            float net = (float) (double) TestContext.DataRow["Net"];
            Employee t = new Employee("Test", "Employee", "123-45-6655", gross);
            Assert.AreEqual(net, t.Pay(), .01);

            //_emp.Salary = 100;
            //float net = _emp.Pay();
            //Assert.AreEqual(92.35, net, .001);
            //Assert.AreEqual(100, _emp.YtdGross, .001);
            //Assert.AreEqual(7.65, _emp.YtdTax, .001);
            //_emp.Pay();
            //Assert.AreEqual(200, _emp.YtdGross, .001);

        }


    }

}
