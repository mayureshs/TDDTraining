using System;
using System.Collections.Generic;
using System.Linq;
using AccountsPayable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AccountsPayableTest
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        IEmployeeRepository empdb = null;
        Employee[] emps = null;


        [TestInitialize]
        public void Setup()
        {
            // need this so the mock can pass to Employee ctor
            Object[] parms = new Object[4];
            var emp1 = new Mock<Employee>(parms);
            var emp2 = new Mock<Employee>(parms);
            var emp3 = new Mock<Employee>(parms);

            emp1.Setup(e => e.TaxId).Returns("111-22-3333");
            emp1.Setup(e => e.FirstName).Returns("Hank");
            emp1.Setup(e => e.LastName).Returns("Hill");
            emp1.Setup(e => e.Salary).Returns(200);

            emp2.Setup(e => e.TaxId).Returns("111-22-4444");
            emp2.Setup(e => e.FirstName).Returns("Peggy");
            emp2.Setup(e => e.LastName).Returns("Hill");
            emp2.Setup(e => e.Salary).Returns(300);

            emp3.Setup(e => e.TaxId).Returns("000-00-0000");
            emp3.Setup(e => e.FirstName).Returns("Dale");
            emp3.Setup(e => e.LastName).Returns("Gribble");
            emp3.Setup(e => e.Salary).Returns(75);

            var mockCtx = new Mock<IApDataContext>();
            emps = new Employee[] { emp1.Object, emp2.Object, emp3.Object };

            mockCtx.Setup(c => c.Employees).Returns(emps);
            empdb = new EmployeeRepository();
            empdb.Context = mockCtx.Object;
        }

        [TestMethod]
        public void TestEmployeeRepositoryFindByLastName()
        {
            IEnumerable<Employee> results = empdb.GetEmployeesNamed("Hill");
            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public void TestEmployeeRepositoryFindBySSN()
        {
            Employee e = empdb.Get("111-22-4444");
            Assert.AreSame(emps[1], e);
        }

        [TestMethod]
        public void TestEmployeeRepositoryGetAll()
        {
            Assert.AreEqual(3, empdb.GetAll().Count());
        }

        [TestMethod]
        public void TestEmployeeRepositoryFindBySalaryGreater()
        {
            IEnumerable<Employee> results = empdb.GetEmployeesSalaryGreater(199);
            Assert.IsTrue(results.Contains(emps[0]));
            Assert.IsTrue(results.Contains(emps[1]));
            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public void TestEmployeeRepositoryFindByLess()
        {
            IEnumerable<Employee> results = empdb.GetEmployeesSalaryLess(100);
            Assert.IsTrue(results.Contains(emps[2]));
            Assert.AreEqual(1, results.Count());
        }
    }
}
